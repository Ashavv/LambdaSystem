using Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BatchLayer
{
    public class SalesBatchDB
    {
        private string datasystemConnection = ConfigurationManager.ConnectionStrings["lambdadb"].ConnectionString;

        //INSERT NEW SALE TO MASTER DATASET
        public void HandleNewSale(SalesOrderHeader sale)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    using (SqlConnection connection = new SqlConnection(datasystemConnection))
                    {
                        int orderHeaderId = 0;

                        connection.Open();
                        using (SqlCommand command = connection.CreateCommand())
                        {

                            command.CommandText = "INSERT INTO [Master].[SalesOrderHeader](OrderDate) OUTPUT INSERTED.SalesOrderID VALUES(@orderDate)";
                            command.Parameters.AddWithValue("@orderDate", sale.OrderDate);

                            orderHeaderId = (int)command.ExecuteScalar();
                        }

                        foreach (SalesOrderDetail orderDetail in sale.OrderDetails)
                        {
                            using (SqlCommand command = connection.CreateCommand())
                            {
                                command.CommandText = "INSERT INTO [Master].[SalesOrderDetail](SalesOrderID, OrderQty, ProductID) VALUES(@salesOrderID, @orderQty, @productID)";
                                command.Parameters.AddWithValue("@salesOrderID", orderHeaderId);
                                command.Parameters.AddWithValue("@orderQty", orderDetail.Quantity);
                                command.Parameters.AddWithValue("@productId", orderDetail.ProductId);
                                int result = command.ExecuteNonQuery();
                            }
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

        //COMPUTE BATCH VIEW OF SALES FOR EVERY YEAR
        public void ComputeSalesByYearBatchView()
        {

            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    using (SqlConnection connection = new SqlConnection(datasystemConnection))
                    {
                        connection.Open();

                        SnapshotMasterSet(connection);

                        using (SqlCommand command = connection.CreateCommand())
                        {
                            Dictionary<int, int> counts = new Dictionary<int, int>();


                            //GET DATA FROM MASTERSET SNAPSHOT
                            command.CommandText = "SELECT Year(OrderDate) As [Year], Count(*) As [Count] from [DataSystem].[Copy].SalesOrderHeader GROUP BY Year(OrderDate) ORDER BY Year(OrderDate)";
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    while (reader.Read())
                                    {
                                        int year = reader.GetInt32(reader.GetOrdinal("Year"));
                                        int count = reader.GetInt32(reader.GetOrdinal("Count"));

                                        counts.Add(year, count);
                                    }
                                }
                            }

                            //CREATE NEW TABLE TO INSERT BATCH VIEW TO
                            command.CommandText = "CREATE TABLE [BatchViews].SalesByYearNew (ID int Identity(1,1) PRIMARY KEY, SalesYear int NOT NULL, NoOfSales int NOT NULL)";
                            command.ExecuteNonQuery();

                            //INSERT BATCH VIEW TO NEW TABLE
                            foreach (KeyValuePair<int, int> count in counts)
                            {
                                using (SqlCommand insertCommand = connection.CreateCommand())
                                {
                                    insertCommand.CommandText = "INSERT INTO [BatchViews].SalesByYearNew (SalesYear, NoOfSales) VALUES(@year, @counts)";
                                    insertCommand.Parameters.AddWithValue("@year", count.Key);
                                    insertCommand.Parameters.AddWithValue("@counts", count.Value);
                                    insertCommand.ExecuteNonQuery();
                                }
                            }
                        }

                        //INSERT NEW BATCH VIEWS
                        InsertNewBatchView(connection);

                        //DELETE SNAPSHOT
                        DeleteSnapshot(connection);
                    }
                    scope.Complete();
                }
            }
            catch (TransactionAbortedException)
            {

                throw;
            }
        }

        private void DeleteSnapshot(SqlConnection connection)
        {
            using (SqlCommand command = connection.CreateCommand())
            {
                command.CommandText = "DROP TABLE [DataSystem].[Copy].SalesOrderDetail";
                command.ExecuteNonQuery();

                command.CommandText = "DROP TABLE [DataSystem].[Copy].SalesOrderHeader";
                command.ExecuteNonQuery();

                command.CommandText = "DROP TABLE [DataSystem].[Copy].Product";
                command.ExecuteNonQuery();
            }
        }

        private void SnapshotMasterSet(SqlConnection connection)
        {
            using (SqlCommand command = connection.CreateCommand())
            {
                command.CommandText = "SELECT * INTO [DataSystem].[Copy].SalesOrderDetail FROM [DataSystem].[Master].[SalesOrderDetail]";
                command.ExecuteNonQuery();

                command.CommandText = "SELECT * INTO [DataSystem].[Copy].SalesOrderHeader FROM [DataSystem].[Master].[SalesOrderHeader]";
                command.ExecuteNonQuery();

                command.CommandText = "SELECT * INTO [DataSystem].[Copy].Product FROM [DataSystem].[Master].[Product]";
                command.ExecuteNonQuery();
            }
        }

        private void InsertNewBatchView(SqlConnection connection)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {

                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "DROP TABLE [BatchViews].SalesByYear";

                        command.ExecuteNonQuery();
                    }

                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "EXEC sp_rename '[BatchViews].[SalesByYearNew]', 'SalesByYear'";
                        command.ExecuteNonQuery();
                    }

                    scope.Complete();
                }
                catch (SqlException)
                {
                    throw;
                }
            }
        }
    }
}
