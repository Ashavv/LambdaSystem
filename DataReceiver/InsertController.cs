using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataReceiver
{
    public class InsertController
    {
        public void insertSale(SalesOrderHeader sale)
        {
            BatchServiceReference.IBatchService batchService = new BatchServiceReference.BatchServiceClient();
            SpeedServiceReference.ISpeedService speedService = new SpeedServiceReference.SpeedServiceClient();

            batchService.HandleNewSale(sale);
            speedService.HandleNewSale(sale);
        }

    }
}
