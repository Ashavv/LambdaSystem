using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryLayer
{
    public class SalesController
    {
        private String datasystemConnection = ConfigurationManager.ConnectionStrings["lambdadb"].ConnectionString;

        public int GetNoOfSalesByYear(int year)
        {

            int batchResult = 0;
            int realtimeResult = 0;

            using (SqlConnection connection = new SqlConnection(datasystemConnection))
            {
                connection.Open();

                //GET BATCH VIEW
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT NoOfSales FROM [DataSystem].[BatchViews].[SalesByYear] WHERE [SalesByYear].SalesYear = @year";
                    command.Parameters.AddWithValue("@year", year);

                    var result = command.ExecuteScalar();

                    if (result != null)
                    {
                        batchResult = (int)result;
                    }
                }

                //GET REALTIME VIEW
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT NoOfSales FROM [DataSystem].[RealtimeViews].[SalesByYear] WHERE [SalesByYear].SalesYear = @year";
                    command.Parameters.AddWithValue("@year", year);

                    var result = command.ExecuteScalar();

                    if (result != null)
                    {
                        realtimeResult = (int)result;
                    }
                }
            }
            return batchResult + realtimeResult;
        }
    }
}
