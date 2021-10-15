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

            IEnumerable<string> neighborhood = root.features.Select(Feature => Feature.properties.neighborhood);

            int neighborhoodCount = neighborhood.Count();

            Console.WriteLine($"{neighborhoodCount} neighborhoods.");

            Console.WriteLine();

            IEnumerable<string> noNameNeighbor = neighborhood.Where(neighborhood =>
                    neighborhood != "");

            int noNeighborCount = noNameNeighbor.Count();

            Console.WriteLine($"{noNeighborCount} of those neighborhoods have a name.");
            Console.WriteLine();


            var noDuplicates = noNameNeighbor.Distinct();

            int zeroDuplicates = noDuplicates.Count();

            Console.WriteLine($"Only {zeroDuplicates} neighborhoods are not duplicates.");
            Console.WriteLine();

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
