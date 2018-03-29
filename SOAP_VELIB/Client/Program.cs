using Client.ServiceReference1;
using System;
namespace Client
{
    class Program
    {

        static VelibOperationClient service;
        
        static void Main(string[] args)
        {
            service = new VelibOperationClient();
            Display_main_menu();
            bool is_finish = false;
            while (!is_finish)
            {
                int choise = int.Parse(Console.ReadLine());
                switch (choise)
                {
                    case 0:
                        PrintVelibStationThanksToCityName();
                        break;
                    case 1:
                        City city = getChosenCity();
                        Station station = getChosenStation(city);
                        Console.WriteLine("Nombre de vélibs disponibles pour la station :" + station.Name);
                        Console.WriteLine("====> " + station.Available_Velib + " vélibs disponibles\n\n");
                        break;
                    case 2:
                        Display_help();
                        break;
                    case 3:
                        is_finish = true;
                        break;
                    default:
                        Console.WriteLine("Vous vous êtes trompés de touche");
                        Display_help();
                        break;
                }
                Display_main_menu();                
            }            
        }

        static void Display_help()
        {
            Console.WriteLine("Pour faire vos choix dans les menu, veuillez rentrer le numéro inscrit au début de la ligne, dans la console puis taper sur entrer.");
        }

        static void Display_main_menu()
        {
            Console.WriteLine("Vous voici sur le WS Client, veuillez choisir quelle requête vous voulez faire !");
            Console.WriteLine("0 - Accéder à une liste de station de vélib en donnant un nom de ville.");
            Console.WriteLine("1 - Accéder aux nombres de velibs disponibles en donnant un nom de station.");
            Console.WriteLine("2 - Help");
            Console.WriteLine("3 - Quitter l'application");
        }

        static City getChosenCity()
        {
            City[] cities = service.GetCities();            
            int city_id = 0;
            foreach (City city in cities)
            {
                Console.WriteLine("" + city_id++ + " - " + city.Name);
            }
            Console.WriteLine("\n\n");
            Console.WriteLine("Choisissez l'une des villes disponibles précédentes.");
            int choise = int.Parse(Console.ReadLine());
            return cities[choise];
        }

        static void PrintVelibStationThanksToCityName()
        {
            City city = getChosenCity();
            Station[] stations = service.GetVelibStations(city);
            foreach (Station station in stations)
            {
                Console.WriteLine("Nom de la station : " + station.Name + ", nom du contrat : " + station.Contract_Name);
            }
            Console.WriteLine("\n\n");
        }

        static Station getChosenStation(City city)
        {
            Station[] stations = service.GetVelibStations(city);
            int station_iterator = 0;
            foreach (Station station in stations)
            {
                Console.WriteLine(station_iterator++ + " - Nom de la station : " + station.Name + ", nom du contrat : " + station.Contract_Name);
            }
            Console.WriteLine("\n\n");
            Console.WriteLine("Choisissez l'une des stations disponibles précédentes.");
            int choise = int.Parse(Console.ReadLine());
            return stations[choise];
        }
    }
}
