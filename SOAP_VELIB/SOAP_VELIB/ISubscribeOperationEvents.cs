using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SOAP_VELIB
{   

    interface ISubscribeOperationEvents
    {
        [OperationContract(IsOneWay = true)]
        void getStation(string stationName,Station station);

        [OperationContract(IsOneWay = true)]
        void getStationFinished();
    }
}
