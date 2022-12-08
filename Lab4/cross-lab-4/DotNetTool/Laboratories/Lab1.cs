using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using static System.Console;

namespace DotNetTool.Laboratories;

public class Lab1
{
    private readonly string _inputFileName;
    private readonly string _outputFileName;
    public Lab1(string inputFileName, string outputFileName)
    {
        _outputFileName = outputFileName;
        _inputFileName = inputFileName;
    }

    public void Main()
    {
        OutputEncoding = Encoding.UTF8;
        Console.WriteLine("Bortkevych Petro, SE-42, FIT KNU, Crossplatform programming");
        Console.WriteLine($"Practical Task #1\n");

        if (File.Exists(_inputFileName) == false)
        {
            Console.WriteLine($"input.txt was not found at \n{_inputFileName}");
            Environment.Exit(1);
        }

        var fileContents = File.ReadAllLines(_inputFileName);

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

    public void CreateInputFile(string[] inputLines)
    {
        if (File.Exists(this._inputFileName))
        {
            File.Delete(this._inputFileName);
        }

        File.WriteAllLines(this._inputFileName, inputLines); ;
    }
}