using System;
using System.IO;

namespace linq
{
    class Program
    {
        static void Main(string[] args)
        {
            string json = File.ReadAllText("data.json");
            Console.WriteLine($"{json}");
        }
    }
}
