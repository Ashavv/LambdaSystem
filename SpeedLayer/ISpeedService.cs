using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SpeedLayer
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ISpeedService" in both code and config file together.
    [ServiceContract]
    public interface ISpeedService
    {
        [OperationContract]
        String DoWork();

        [OperationContract]
        void HandleNewSale(SalesOrderHeader sale);

        [OperationContract]
        void ExpireSalesRealtimeView();
    }
}
