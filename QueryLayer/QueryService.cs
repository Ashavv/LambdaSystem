using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace QueryLayer
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "QueryService" in both code and config file together.
    public class QueryService : IQueryService
    {
        private SalesController salesController = new SalesController();

        public String DoWork()
        {
            return " QueryServive responded ";
        }

        public int GetNoOfSalesByYear(int year)
        {
            return salesController.GetNoOfSalesByYear(year);
        }
    }
}
