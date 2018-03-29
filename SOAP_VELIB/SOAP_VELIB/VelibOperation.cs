using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace SOAP_VELIB
{
    public class VelibOperation : IVelibOperation
    {

        private string apikey = "4c69e62923a5ff9ac8bf30ce6f52db8d9f11a121";

        public string Get(string url)
        {
            WebRequest request = WebRequest.Create(url+"apiKey="+apikey);
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string answer = reader.ReadToEnd();
            reader.Close();
            response.Close();
            return answer;
        }

        public List<City> GetCities()
        {
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
            return cities;
        }     

        public List<Station> GetVelibStations(City city)
        {
            string response = Get(@"https://api.jcdecaux.com/vls/v1/stations?contract="+city.ContractName+"&");
            JArray responseJson = JArray.Parse(response);
            List<Station> stations = new List<Station>();
            foreach(JObject json in responseJson)
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
            return stations;
        }
    }
}
