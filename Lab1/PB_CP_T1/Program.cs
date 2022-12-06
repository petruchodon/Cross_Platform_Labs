using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using static System.Console;

namespace PB_CP_T1
{
    static class Program
    {
        public static void Main(string[] args)
        {
            OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Bortkevych Petro, SE-42, FIT KNU, Crossplatform programming");
            Console.WriteLine($"Practical Task #1\n");

            var fullPath = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + "input.txt";

            if (File.Exists(fullPath) == false)
            {
                Console.WriteLine($"input.txt was not found at \n{fullPath}");
                Environment.Exit(1);
            }

            var fileContents = File.ReadAllLines(fullPath);

            foreach (var line in fileContents)
            {
                var variables = Array.ConvertAll(line.Split(" "), int.Parse);
                long s = 0;

                for (var i = 1; i != variables[0] + 1; ++i)
                {
                    for (var j = 1; j != variables[1] + 1; ++j)
                    {
                        s += i * j;
                    }
                }
                
                Console.WriteLine($"Result is now: {s}");
            }
        }
    }
}