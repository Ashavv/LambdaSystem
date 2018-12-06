using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace QueryLayer
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IQueryService" in both code and config file together.
    [ServiceContract]
    public interface IQueryService
    {
        [OperationContract]
        String DoWork();

        [OperationContract]
        int GetNoOfSalesByYear(int year);

    }
}
