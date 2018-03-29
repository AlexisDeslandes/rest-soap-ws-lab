using System;
using System.Collections.Generic;
using System.Net;

namespace SOAP_VELIB
{
    class MonitoringOperation : IMonitoringOperation
    {

        public static List<double> delays = new List<double>();
        public static List<string> ips = new List<string>();
        public static int request_service_count = 0;
        public static int request_count = 0;

        public double getAverageDelayForResponse()
        {
            request_count++;
            double average_delay = 0;            
            foreach (double delay in delays){
                average_delay += delay;
            }
            return average_delay / delays.Count;
        }

        public int getClientCount()
        {
            request_count++;
            return ips.Count;
        }

        public string[] getIPClientsConnected()
        {
            request_count++;
            return ips.ToArray();
        }

        public int getNumberOfRequestForWSVelib()
        {
            return request_service_count;
        }

        public int getNumberOfRequestSinceStart()
        {
            return ++request_count;
        }
    }
}
