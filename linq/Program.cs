using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace linq
{
    class Program
    {
        static void Main(string[] args)
        {
            RootObject root = ReadJson();

            var neighborhood = root.features.Select(Feature => Feature.properties.neighborhood);

            int neighborhoodCount = neighborhood.Count();

            Console.WriteLine("1. Output all of the Manhattan neighborhoods in the data list.");
            Console.WriteLine();
            Console.WriteLine($"--- {neighborhoodCount} neighborhoods.");
            Console.WriteLine();

            var noNameNeighbor = neighborhood.Where(neighborhood =>
                    neighborhood != "");

            int noNeighborCount = noNameNeighbor.Count();

            Console.WriteLine("2. Filter out all the neighborhoods that do not have any names.");
            Console.WriteLine();
            Console.WriteLine($"--- {noNeighborCount} of the neighborhoods have a name.");
            Console.WriteLine();

            var noDuplicates = noNameNeighbor.Distinct();

            int zeroDuplicates = noDuplicates.Count();

            Console.WriteLine("3. Remove any duplicates from the list of neighborhoods.");
            Console.WriteLine();
            Console.WriteLine($"--- {zeroDuplicates} neighborhoods are not duplicates.");
            Console.WriteLine();


            var manhattan =
                root.features
                .Select(Feature => Feature.properties.neighborhood);
                neighborhood.Where(neighborhood => neighborhood != "");
                noNameNeighbor.Distinct();

            Console.WriteLine($"All in one: {manhattan.Count()}");

        }

        private static RootObject ReadJson()
        {
            string json = File.ReadAllText("data.json");

            //Proof of life that we can get the data.json from file
            //Console.WriteLine($"{json}");

            RootObject root = JsonConvert.DeserializeObject<RootObject>(json);
            return root;
        }
    }
}
