using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class SalesOrderHeader
    {
        private List<SalesOrderDetail> orderDetails;

        public SalesOrderHeader()
        {
            orderDetails = new List<SalesOrderDetail>();
        }
        public List<SalesOrderDetail> OrderDetails
        {
            get { return orderDetails; }
            set { orderDetails = value; }
        }

        public DateTime OrderDate { get; set; }
    }
}
