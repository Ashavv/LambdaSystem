using Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace SpeedLayer
{
    public class SalesRealtimeDB
    {
        private string datasystemConnection = ConfigurationManager.ConnectionStrings["lambdadb"].ConnectionString;

        public void HandleNewSale(SalesOrderHeader sale)
        {
            //NEED TO KEEP TWO VERSIONS OF REALTIME VEIWS
            Dictionary<int, String> realtimeViewTables = new Dictionary<int, string>();
            realtimeViewTables.Add(0, "[SalesByYear] ");
            realtimeViewTables.Add(1, "[SalesByYear2] ");

            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(datasystemConnection))
            {
                connection.Open();

                foreach (KeyValuePair<int, String> table in realtimeViewTables)
                {
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "UPDATE[DataSystem].[RealtimeViews]." + table.Value + "SET NoOfSales = NoOfSales + 1 WHERE SalesYear = @year";
                        command.Parameters.AddWithValue("@year", sale.OrderDate.Year);
                        command.Parameters.AddWithValue("@db", "SalesByYear");
                        rowsAffected = command.ExecuteNonQuery();
                    }

                    //IF there's not already a bucket for that year, create one
                    if (rowsAffected == 0)
                    {
                        using (SqlCommand command = connection.CreateCommand())
                        {
                            command.CommandText = "INSERT INTO[DataSystem].[RealtimeViews]." + table.Value + "(SalesYear, NoOfSales) VALUES(@year, 1)";
                            command.Parameters.AddWithValue("@year", sale.OrderDate.Year);
                            command.ExecuteNonQuery();

                        }
                    }
                }      
            }
        }

        public void ExpireSalesByYearView()
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    using (SqlConnection connection = new SqlConnection(datasystemConnection))
                    {
                        connection.Open();
                        using (SqlCommand command = connection.CreateCommand())
                        {
                            //DROP CURRENT REALTIME VIEW
                            command.CommandText = "DROP TABLE IF EXISTS [RealtimeVIews].SalesByYear";
                            command.ExecuteNonQuery();
                        
                            //CHECK IF THERES IS SECOND REALTIMEVIEW
                            command.CommandText = "SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'SalesByYear2'";
                            int result = (int)command.ExecuteScalar();

                            //RENAME SECOND REALTIME TABLE TO MAKE IT ACTIVE REALTIME VIEW
                            if (result != 0)
                            {
                                command.CommandText = "EXEC sp_rename '[RealtimeViews].[SalesByYear2]', 'SalesByYear'";
                                command.ExecuteNonQuery();
                            }
                        
                            //CREATE A NEW SECOND TABLE 
                            command.CommandText = "CREATE TABLE RealtimeViews.SalesByYear2 (ID int Identity(1,1) PRIMARY KEY, SalesYear int NOT NULL, NoOfSales int NOT NULL)";
                            command.ExecuteNonQuery();
                        }
                    }
                    scope.Complete();
                }
            }
            catch (TransactionAbortedException)
            {
                throw;
            }
        }
    }
}
