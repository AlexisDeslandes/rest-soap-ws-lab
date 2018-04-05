using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.ServiceReference1;

namespace Client
{
    class CallbaclSink : ServiceReference1.IVelibOperationCallback
    {
        public void getStation(string stationName, Station station)
        {
            Console.WriteLine("Station : " + station.Name);
            Console.WriteLine("Station : velo = " + station.Available_Velib);
        }

        public void getStationFinished()
        {
            Console.WriteLine("Successfull callback");
        }
    }
}
