using Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataReceiver
{
    public class FeedSimulator
    {
        private string datasystemConnection = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=DataSystem;Integrated Security=SSPI";

        public void FeedNewSale()
        {
            InsertController insertController = new InsertController();
            SalesOrderHeader sale = GenerateSale();
            insertController.insertSale(sale);
        }

        //Generates a (kind of) random SalesHeaderOrder object
        public SalesOrderHeader GenerateSale()
        {

            int randomProduct = GetRandomProduct();
            int randomQuantity = new Random().Next(1, 6);
            

            SalesOrderHeader sale = new SalesOrderHeader
            {
                OrderDate = DateTime.Now
            };

            SalesOrderDetail orderDetail = new SalesOrderDetail
            {
                ProductId = randomProduct,
                Quantity = randomQuantity
            };

            sale.OrderDetails.Add(orderDetail);

            return sale;
        }


        public int GetRandomProduct()
        {
            int randomProductId = 0;

            using (SqlConnection connection = new SqlConnection(datasystemConnection))
            {
                connection.Open();

                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT TOP (1) [Master].[Product].ProductId FROM Master.Product ORDER BY NEWID()";

                    randomProductId = (int)command.ExecuteScalar();

                }
            }
            return randomProductId;
        }
    }
}
