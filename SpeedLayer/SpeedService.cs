using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SpeedLayer
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SpeedService" in both code and config file together.
    public class SpeedService : ISpeedService
    {
        private SalesController salesController = new SalesController();

        public String DoWork()
        {
            return " SpeedService responded ";
        }

        public void HandleNewSale(SalesOrderHeader sale)
        {
            salesController.HandleNewSale(sale);
        }

        public void ExpireSalesRealtimeView()
        {
            salesController.ExpireSalesRealtimeView();
        }
    }
}
