using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatchLayer
{
    public class SalesController
    {
        SalesBatchDB salesdb = new SalesBatchDB();

        public void HandleNewSale(SalesOrderHeader sale)
        {
            salesdb.HandleNewSale(sale);
        }

        public void ComputeSalesByYearBatchView()
        {
            salesdb.ComputeSalesByYearBatchView();
        }
    }
}
