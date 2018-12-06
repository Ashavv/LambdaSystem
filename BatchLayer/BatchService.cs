using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BatchLayer
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "BatchService" in both code and config file together.
    public class BatchService : IBatchService
    {
        SalesController salesController = new SalesController();


        public String DoWork()
        {
            SpeedServiceReference.ISpeedService speedService = new SpeedServiceReference.SpeedServiceClient();
            return speedService.DoWork();
        }

        public void HandleNewSale(SalesOrderHeader sale)
        {
            salesController.HandleNewSale(sale);
        }

        public void ComputeSalesByYearBatchView()
        {
            salesController.ComputeSalesByYearBatchView();

            //When batch computation is done, expire out dated realtime views
            SpeedServiceReference.ISpeedService speedService = new SpeedServiceReference.SpeedServiceClient();
            speedService.ExpireSalesRealtimeView();
        }
    }
}
