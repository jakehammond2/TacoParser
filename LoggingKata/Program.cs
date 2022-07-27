using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";
        const double metersToMiles = 0.00062137; 

        static void Main(string[] args)
        {
            
            logger.LogInfo("Log initialized");

            var lines = File.ReadAllLines(csvPath);

            logger.LogInfo($"Lines: {lines[0]}");


            ITrackable tacoBellA = null;
            ITrackable tacoBellB = null;
            double LargestDistance = 0; 
            double testDistance = 0;
            var locationA = new GeoCoordinate();
            var locationB = new GeoCoordinate();

            var parser = new TacoParser();


            //Everytime you call this Parse method (TacoParser.Parse) for each one of strings inside the string array called lines,
            //it then Parses out each individual line and puts it in a object and sets it all correctly.

            //This new variable locations which is an ITrackable array transforms
            //each line (string) to an ITrackable object (location) and saves it to the locations array
            var locations = lines.Select(parser.Parse).ToArray();                       
                                                                    
            for (int i = 0; i < locations.Length; i++)                
                                                                    
            {                                                       
                locationA.Latitude = locations[i].Location.Latitude;                //setting the values into my first geocoordinate object
                locationA.Longitude = locations[i].Location.Longitude; 
                
                for (int j = 1; j < locations.Length; j++)                          // It is comparing the first locationA to everyone of location B, then moves to the second location A and repeats
                {   
                    locationB.Latitude = locations[j].Location.Latitude;            // now setting the values into second geocoordinate object  
                    locationB.Longitude = locations[j].Location.Longitude;


                    testDistance = locationA.GetDistanceTo(locationB);              // Gets distance from locationA to location B

                    if (LargestDistance < testDistance)
                    {
                        LargestDistance = testDistance;                             // If Largest Distance < test, then you update the ITrackable locations
                        tacoBellA = locations[i];
                        tacoBellB = locations[j];
                    }
                }
            }
            
            Console.WriteLine($"The two furthest {tacoBellA.GetType().Name}'s are {tacoBellA.Name} and {tacoBellB.Name}");
            Console.WriteLine($"The total distance is {Math.Round((LargestDistance * metersToMiles), 2)} miles.");


        }
    }
}
