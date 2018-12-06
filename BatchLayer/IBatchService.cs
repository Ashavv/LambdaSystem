using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BatchLayer
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IBatchService" in both code and config file together.
    [ServiceContract]
    public interface IBatchService
    {
        [OperationContract]
        String DoWork();

        [OperationContract]
        void HandleNewSale(SalesOrderHeader sale);

        [OperationContract]
        void ComputeSalesByYearBatchView();
    }
}
