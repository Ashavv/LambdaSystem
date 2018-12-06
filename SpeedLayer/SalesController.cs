using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedLayer
{
    public class SalesController
    {
        private SalesRealtimeDB salesRealtimeDB = new SalesRealtimeDB();

        public void HandleNewSale(SalesOrderHeader sale)
        {
            salesRealtimeDB.HandleNewSale(sale);
        }

        public void ExpireSalesRealtimeView()
        {
            salesRealtimeDB.ExpireSalesByYearView();
        }
    }
}
