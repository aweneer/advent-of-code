using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Reflection;
using System.Diagnostics;

namespace CodeRunner
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choose year and puzzle to proceed. (e.g. 2023-07, or only \"07\" if you want current year.)");
            string year = "2023";
            string puzzle = "08";

            while (true)
            {
                break;
                var userInput = Console.ReadLine();

                var matchFull = Regex.Match(userInput, @"^(\d{4})-(\d{2})$");
                if (matchFull.Success)
                {
                    year = matchFull.Groups[1].Value;
                    puzzle = matchFull.Groups[2].Value;
                    break;
                }

                var matchPuzzleOnly = Regex.Match(userInput, @"^(\d{1,2})$");
                if (matchPuzzleOnly.Success)
                {
                    year = DateTime.UtcNow.Year.ToString();
                    puzzle = matchPuzzleOnly.Groups[0].Value;
                    if (puzzle.Length == 1)
                        puzzle = puzzle.Insert(0, "0");
                    break;
                }
                Console.WriteLine("Choose year and puzzle to proceed. (e.g. 2023-07, or only \"07\" if you want current year.)");
            }

            var selectedType = $"Advent._{year}.Code{puzzle}";
            var selectedYearAssembly = $"Advent.{year}.dll";

            Assembly assembly = Assembly.LoadFrom(selectedYearAssembly);
            Type? typeToCall = assembly.GetType(selectedType);

            if (typeToCall == null)
                Console.WriteLine($"Error: type '{selectedType}' not found in assembly '{selectedYearAssembly}'.");

            var firstPuzzleMethod = typeToCall.GetMethod("FirstPuzzle");
            var secondPuzzleMethod = typeToCall.GetMethod("SecondPuzzle");

            var exampleFile = $@"..\..\..\..\Advent.{year}\examples\example{puzzle}.txt";
            var secondExampleFile = $@"..\..\..\..\Advent.{year}\examples\example{puzzle}b.txt";
            var thirdExampleFile = $@"..\..\..\..\Advent.{year}\examples\example{puzzle}c.txt";
            var inputFile = $@"..\..\..\..\Advent.{year}\inputs\input{puzzle}.txt";

            // TODO make dynamic by prefix
            string[] exampleFileContents = Array.Empty<string>();
            if (File.Exists(exampleFile))
            {
                exampleFileContents = File.ReadAllLines($@"..\..\..\..\Advent.{year}\examples\example{puzzle}.txt");
            }

            string[] secondExampleFileContents = Array.Empty<string>();
            if (File.Exists(secondExampleFile))
            {
                secondExampleFileContents = File.ReadAllLines($@"..\..\..\..\Advent.{year}\examples\example{puzzle}b.txt");
            }


            string[] thirdExampleFileContents = Array.Empty<string>();
            if (File.Exists(thirdExampleFile))
            {
                thirdExampleFileContents = File.ReadAllLines($@"..\..\..\..\Advent.{year}\examples\example{puzzle}c.txt");
            }

            string[] inputFileContents = Array.Empty<string>();
            if (File.Exists(inputFile))
            {
                inputFileContents = File.ReadAllLines($@"..\..\..\..\Advent.{year}\inputs\input{puzzle}.txt");
            }

            Stopwatch stopwatch = new Stopwatch();

            // FirstPuzzle
            stopwatch.Start();
            PrintResult(firstPuzzleMethod.Invoke(firstPuzzleMethod.GetParameters(), new object[] { exampleFileContents }), "Example");
            PrintResult(firstPuzzleMethod.Invoke(firstPuzzleMethod.GetParameters(), new object[] { secondExampleFileContents }), "Example B");
            PrintResult(firstPuzzleMethod.Invoke(firstPuzzleMethod.GetParameters(), new object[] { inputFileContents }), "Input");
            stopwatch.Stop();
            PrintElapsedTime(selectedType, firstPuzzleMethod.Name, stopwatch);

            // SecondPuzzle
            stopwatch.Restart();
            PrintResult(secondPuzzleMethod.Invoke(secondPuzzleMethod.GetParameters(), new object[] { thirdExampleFileContents }), "Example C");
            PrintResult(secondPuzzleMethod.Invoke(secondPuzzleMethod.GetParameters(), new object[] { inputFileContents }), "Input");
            stopwatch.Stop();
            PrintElapsedTime(selectedType, secondPuzzleMethod.Name, stopwatch);
        }

        private static void PrintElapsedTime(string selectedType, string methodName, Stopwatch stopwatch)
        {
            Console.WriteLine($"Elapsed time of {selectedType}.{methodName} is {(stopwatch.ElapsedMilliseconds < 1000? stopwatch.ElapsedMilliseconds + " ms" : stopwatch.ElapsedMilliseconds / 1000 + " s, (" + stopwatch.ElapsedMilliseconds + " ms)")}");
        }

        private static void PrintResult(object? result, string type)
        {
            Console.WriteLine($"{type} result:\t{result}");
        }
    }
}