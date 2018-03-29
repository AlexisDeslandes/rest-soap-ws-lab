using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SOAP_VELIB
{
    [ServiceContract]
    interface IMonitoringOperation
    {
        [OperationContract]
        int getClientCount();

        [OperationContract]
        int getNumberOfRequestSinceStart();

        [OperationContract]
        int getNumberOfRequestForWSVelib();

        [OperationContract]
        double getAverageDelayForResponse();

        [OperationContract]
        string[] getIPClientsConnected();
    }
}
