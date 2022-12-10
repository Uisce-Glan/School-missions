using System;
using System.Collections.Generic;

namespace Travel_the_world_map
{
    internal class Program
    {
        class Location
        {
            public string Name;
            public string Description;
        }

        static void Main(string[] args)
        {
            var locations = new List<Location>();

            var winterfell = new Location
            {
                Name = "winterfell",
                Description = "the capital of the Kingdom of the North"
            };

            locations.Add(winterfell);



            var pyke = new Location
            {
                Name = "Pyke",
                Description = "the stronghold and seat of House Greyjoy"
            };


            var riverrun = new Location
            {
                Name = "Riverrun",
                Description = "a large castle located in the central-western part of the Riverlands"
            };

            locations.Add(riverrun);


            locations.Add(new Location
            {
                Name = "The Trident",
                Description = "one of the largest and most well-known rivers on the continent of Westeros"
            });

            var kingsLanding = new Location
            {
                Name = "King's Landing",
                Description = "the capital, and largest city, of the Seven Kingdoms"
            };

            locations.Add(kingsLanding);

            var highgarden = new Location
            {
                Name = "Highgarden",
                Description = "the seat of House Tyrell and the regional capital of the Reach"
            };

            locations.Add(highgarden);

            var currentLocation = pyke;
            Console.WriteLine($"You are currently at {currentLocation.Name}, {currentLocation.Description}.");
            Console.ReadLine();
        }
    }
}
