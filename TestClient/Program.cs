using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestClient
{
    class Program
    {
        static void Main(string[] args)
        {
           
            Console.WriteLine("STARTET TEST CLIENT" );
            ConnectionTest();
            InsertSaleRealtimeTest();
            //ExpireViewTest();
            InsertSaleBatchTest();
            ComputeSalesByYearBatchViewTest();
            GetNoOfSalesTest();
        }

        private static void ConnectionTest()
        {
            Console.WriteLine("STARTET CONNECTION TEST");

            BatchServiceReference.IBatchService batchService = new BatchServiceReference.BatchServiceClient();
            SpeedServiceReference.ISpeedService speedService = new SpeedServiceReference.SpeedServiceClient();
            QueryServiceReference.IQueryService queryService = new QueryServiceReference.QueryServiceClient();


            Console.WriteLine(batchService.DoWork() + speedService.DoWork() + queryService.DoWork());
            Console.ReadKey();
        }


        private static void InsertSaleBatchTest()
        {
            Console.WriteLine("STARTET INSERT SALE TEST BATCH LAYER");

            SalesOrderDetail orderDetail = new SalesOrderDetail
            {
                ProductId = 577,
                Quantity = 7
            };

            SalesOrderHeader sale = new SalesOrderHeader
            {
                OrderDate = new DateTime(2023, 01, 01)
            };

            sale.OrderDetails.Add(orderDetail);

            BatchServiceReference.IBatchService batchService = new BatchServiceReference.BatchServiceClient();

            batchService.HandleNewSale(sale);
            Console.ReadKey();

        }

        private static void ComputeSalesByYearBatchViewTest()
        {
            Console.WriteLine("STARTET COMPUTE SALES BY YEAR BATCH VIEWS");
            BatchServiceReference.IBatchService batchService = new BatchServiceReference.BatchServiceClient();
            batchService.ComputeSalesByYearBatchView();
            Console.ReadKey();
        }

        private static void InsertSaleRealtimeTest()
        {
            Console.WriteLine("STARTET INSERT SALE TEST SPEEDLAYER");

            SalesOrderDetail orderDetail = new SalesOrderDetail
            {
                ProductId = 577,
                Quantity = 7
            };

            SalesOrderHeader sale = new SalesOrderHeader
            {
                OrderDate = new DateTime(2023, 01, 01)
            };

            sale.OrderDetails.Add(orderDetail);

            SpeedServiceReference.ISpeedService speedService = new SpeedServiceReference.SpeedServiceClient();

            speedService.HandleNewSale(sale);
            Console.ReadKey();
        }

        private static void ExpireViewTest()
        {
            Console.WriteLine("STARTET EXPIRING VIEW");
            SpeedServiceReference.ISpeedService speedService = new SpeedServiceReference.SpeedServiceClient();
            speedService.ExpireSalesRealtimeView();
            Console.ReadKey();
        }

        private static void GetNoOfSalesTest()
        {
            Console.WriteLine("STARTET GETTING NO OF SALES");
            QueryServiceReference.IQueryService queryService = new QueryServiceReference.QueryServiceClient();
            Console.WriteLine(queryService.GetNoOfSalesByYear(2023));
            Console.ReadKey();
        }

    }
}
