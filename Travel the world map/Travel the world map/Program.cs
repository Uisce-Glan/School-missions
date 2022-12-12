using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Threading;

namespace Travel_the_world_map
{
    internal class Program
    {
        class Location
        {
            public override string ToString()
            {
                return Name;
            }
        
            public string Name;
            public string Description;
            public List<Location> Neighbors = new List<Location>();
        }
        static void ConnectLocations(Location a, Location b)
        {
            
            a.Neighbors.Add(b);
            b.Neighbors.Add(a);
        }

            static void Main(string[] args)
        {
            var locations = new List<Location>();



            #region Creating Locations

            var winterfell = new Location
            {
                Name = "Winterfell",
                Description = "the capital of the Kingdom of the North",
                Neighbors = new List<Location>()
            };
            locations.Add(winterfell);


            var pyke = new Location
            {
                Name = "Pyke",
                Description = "the stronghold and seat of House Greyjoy",
                Neighbors = new List<Location>()
            };
            locations.Add(pyke);


            var riverrun = new Location
            {
                Name = "Riverrun",
                Description = "a large castle located in the central-western part of the Riverlands",
                Neighbors = new List<Location>()
            };
            locations.Add(riverrun);


            var theTrident = new Location
            {
                Name = "The Trident",
                Description = "one of the largest and most well-known rivers on the continent of Westeros",
                Neighbors = new List<Location>()
            };
            locations.Add(theTrident);


            var kingsLanding = new Location
            {
                Name = "King's Landing",
                Description = "the capital, and largest city, of the Seven Kingdoms",
                Neighbors = new List<Location>()
            };
            locations.Add(kingsLanding);


            var highgarden = new Location
            {
                Name = "Highgarden",
                Description = "the seat of House Tyrell and the regional capital of the Reach",
                Neighbors = new List<Location>()
            };
            locations.Add(highgarden);
            #endregion Creating Locations 
            
            #region Connecting locations
            ConnectLocations(highgarden, kingsLanding);
            ConnectLocations(highgarden, pyke);
            ConnectLocations(highgarden, riverrun);
            ConnectLocations(theTrident, kingsLanding);
            ConnectLocations(riverrun, kingsLanding);
            ConnectLocations(winterfell, theTrident);
            ConnectLocations(winterfell, pyke);
            ConnectLocations(riverrun, pyke);
            #endregion  Connecting locations

            var currentLocation = kingsLanding;

            for (int i = 5; i > 0; i--) // Gives 5 (Counting started) locations you can visit before you run out of time
            {
                Console.WriteLine($"You are currently at {currentLocation.Name}, {currentLocation.Description}.");
                if (i > 1)
                {
                    var counter = 1; // Counter created here so I can actually increase it in the foreach loop (took me 20 mins to figure out, oops)
                    Console.WriteLine($"\nYou can visit {i -1} more locations today.\n");
                    Console.WriteLine($"Nearby locations are:\n");
                    foreach (var neighbor in currentLocation.Neighbors)
                    {
                        Console.WriteLine($"{counter} {neighbor}");
                        counter++;
                    }
                    Console.WriteLine("\nWhere do you wish to travel?\n");
                }
                else
                {
                    Console.WriteLine("\nYou can't travel more today, take a good rest.");
                }
                var destination = Console.ReadLine(); // This part is so that the location is moved.
                var destinationToInt = Convert.ToInt32(destination);
                currentLocation = currentLocation.Neighbors[destinationToInt -1];
                Console.Clear();
            }
        }
    }
}
