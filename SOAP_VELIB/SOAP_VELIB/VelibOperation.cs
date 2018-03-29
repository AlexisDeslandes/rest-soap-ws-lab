using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Web;

namespace SOAP_VELIB
{
    public class VelibOperation : IVelibOperation
    {

        private string apikey = "4c69e62923a5ff9ac8bf30ce6f52db8d9f11a121";

        public string Get(string url)
        {            
            DateTime begin = DateTime.UtcNow;
            MonitoringOperation.request_count++;
            MonitoringOperation.request_service_count++;            
            WebRequest request = WebRequest.Create(url+"apiKey="+apikey);
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string answer = reader.ReadToEnd();
            reader.Close();
            response.Close();
            MonitoringOperation.delays.Add((DateTime.UtcNow - begin).TotalMilliseconds);
            return answer;
        }        

        public List<City> GetCities()
        {
            addIp();
            DateTime begin = DateTime.UtcNow;
            MonitoringOperation.request_count++;
            MonitoringOperation.request_service_count++;
            string response = Get(@"https://api.jcdecaux.com/vls/v1/contracts?");
            JArray responseJson = JArray.Parse(response);
            List<City> cities = new List<City>();
            foreach (JObject o in responseJson)
            {
                JArray cities_request = (JArray) o["cities"];
                string contract_name = (string)o["name"];
                foreach(string city in cities_request)
                {
                    City city_object = new City();
                    city_object.Name = city;
                    city_object.ContractName = contract_name;
                    cities.Add(city_object);
                }
            }
            MonitoringOperation.delays.Add((DateTime.UtcNow - begin).TotalMilliseconds);
            return cities;
        }

        public List<Station> GetVelibStations(City city)
        {
            addIp();
            DateTime begin = DateTime.UtcNow;
            MonitoringOperation.request_count++;
            MonitoringOperation.request_service_count++;
            string response = Get(@"https://api.jcdecaux.com/vls/v1/stations?contract=" + city.ContractName + "&");
            JArray responseJson = JArray.Parse(response);
            List<Station> stations = new List<Station>();
            foreach (JObject json in responseJson)
            {
                Station station = new Station();
                station.Available_Velib = (int)json["available_bikes"];
                station.Contract_Name = (string)json["contract_name"];
                station.Name = (string)json["name"];
                station.Station_Number = (int)json["number"];
                station.Longitude = (double)json["position"]["lng"];
                station.Latitude = (double)json["position"]["lat"];
                stations.Add(station);
            }
            MonitoringOperation.delays.Add((DateTime.UtcNow - begin).TotalMilliseconds);
            return stations;
        }  
        
        private void addIp()
        {
            OperationContext context = OperationContext.Current;
            //Getting Incoming Message details   
            MessageProperties prop = context.IncomingMessageProperties;
            //Getting client endpoint details from message header   
            RemoteEndpointMessageProperty endpoint = prop[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;                    
            string ip = endpoint.Address;                                            
            if (!MonitoringOperation.ips.Contains(ip)){
                MonitoringOperation.ips.Add(ip);
            }                       
        }
    }
}
