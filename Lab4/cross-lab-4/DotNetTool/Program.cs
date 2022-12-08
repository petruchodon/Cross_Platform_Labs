using System;
using DotNetTool.Laboratories;
using McMaster.Extensions.CommandLineUtils;

namespace DotNetTool;

class Program
{
    public static int Main(string[] args)
    {
        var app = new CommandLineApplication
        {
            Name = "Lab Works",
            Description = "",
        };

        app.HelpOption(inherited: true);
        app.Command("run", configCmd =>
        {
            configCmd.OnExecute(() =>
            {
                Console.WriteLine("Specify a lab work");
                configCmd.ShowHelp();
                return 1;
            });

            // ./DotNetTool run lab1 -I "dataIn.txt" -O "dataOut.txt"
            configCmd.Command("lab1", setCmd =>
            {
                setCmd.Description = "Laboratory work 1";
                var folder = getPathToFile();
                var input = setCmd.Option("-I|--input <INPUT>", "Input file path", CommandOptionType.SingleValue);
                var output = setCmd.Option("-O|--output <OUTPUT>", "Output file path", CommandOptionType.SingleValue);
                input.DefaultValue = $"{folder}/dataIn.txt";
                output.DefaultValue = $"{folder}/dataOut.txt";
                setCmd.OnExecute(() =>
                {
                    Console.WriteLine($"Set input file path: {input.Value()}");
                    Console.WriteLine($"Set output file path: {output.Value()}");
                    var app = new Lab1(input.Value(), output.Value());
                    string[] lines =
                    {
                        "1 1\n2 1\n2 2",
                    };
                    app.CreateInputFile(lines);
                    app.Main();
                });
            });

            // ./DotNetTool run lab2 -I "dataIn.txt" -O "dataOut.txt"
           

            // ./DotNetTool run lab3 -I "dataIn.txt" -O "dataOut.txt"
            configCmd.Command("lab3", setCmd =>
            {
                setCmd.Description = "Laboratory work 3";
                var folder = getPathToFile();
                var input = setCmd.Option("-I|--input <INPUT>", "Input file path", CommandOptionType.SingleValue);
                var output = setCmd.Option("-O|--output <OUTPUT>", "Output file path", CommandOptionType.SingleValue);
                input.DefaultValue = $"{folder}/dataIn.txt";
                output.DefaultValue = $"{folder}/dataOut.txt";
                setCmd.OnExecute(() =>
                {
                    Console.WriteLine($"Set input file path: {input.Value()}");
                    Console.WriteLine($"Set output file path: {output.Value()}");
                    var app = new Lab3(input.Value(), output.Value());
                    string[] lines =
                    {
                        "8\n3 6\n1 1 2 4 5 1 1",
                    };
                    app.CreateInputFile(lines);
                    app.Main();
                });
            });
        });

        app.Command("version", configCmd =>
        {
            configCmd.OnExecute(() =>
            {
                System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
                System.Diagnostics.FileVersionInfo fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
                string version = fvi.FileVersion;
                Console.WriteLine("Version: {0}", version);
            });
        });

        app.OnExecute(() =>
        {
            Console.WriteLine("Specify aplication:");
            app.ShowHelp();
            return 1;
        });

        return app.Execute(args);
    }

    private static string getPathToFile()
    {
        string labPath = Environment.GetEnvironmentVariable("LAB_PATH") ?? "";
        if (labPath.Length > 0) return labPath;
        else return Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
    }
}