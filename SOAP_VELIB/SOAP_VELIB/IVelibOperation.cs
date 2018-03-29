using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SOAP_VELIB
{
    [ServiceContract]
    public interface IVelibOperation
    {
        [OperationContract]
        List<Station> GetVelibStations(City city);

        [OperationContract]
        List<City> GetCities();      
    }
}
