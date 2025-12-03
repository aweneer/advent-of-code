using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Advent._2023
{
    public static class Code08
    {
        public static double FirstPuzzle(string[] input)
        {
            double result = 0;

            var map = new Dictionary<string, (string, string)>();
            var instructions = input[0];

            PrepareMap(input, map);

            string location = "AAA";
            while ( location != "ZZZ")
            {
                foreach (var instruction in instructions)
                {
                    location = instruction == 'L' ? map[location].Item1 : map[location].Item2;
                    result++;

                    if (location == "ZZZ")
                        return result;
                }
            }

            return result;
        }

        public static double SecondPuzzle(string[] input)
        {
            double result = 0;

            var map = new Dictionary<string, (string, string)>();
            var instructions = input[0];

            PrepareMap(input, map);

            var locationsEndingWithA = map.Where(n => n.Key.EndsWith('A')).ToArray();

            var locations = new Locations();

            foreach (var startingLocation in locationsEndingWithA)
            {
                locations.CurrentByStarting.Add(startingLocation.Key, startingLocation.Key);
            }
            
            while (!locations.IsFinished())
            {
                Console.WriteLine(result);
                foreach (var instruction in instructions) 
                {
                    foreach (var startingLocation in locations.CurrentByStarting)
                    {
                        locations.CurrentByStarting[startingLocation.Key] = instruction == 'L' ? map[startingLocation.Value].Item1 : map[startingLocation.Value].Item2;
                    }
                    result++;


                    if (locations.IsFinished())
                    {
                        break;
                    }
                }
            }

            

            return result;
        }

        public static void PrepareMap(string[] input, Dictionary<string, (string, string)> map)
        {
            foreach (string line in input)
            {
                var matches = Regex.Matches(line, @"\w{3}").Cast<Match>().Select(m => m.Value).ToArray();
                if (matches.Length > 1)
                    map.Add(matches[0], (matches[1], matches[2]));
            }
        }

        public static int Walk(string startingLocation, Dictionary<string, (string, string)> navigationByNode, string instructions)
        {
            int result = 0;
            string location = startingLocation;
            Console.WriteLine("Starting: " + startingLocation);

            while (!location.EndsWith('Z'))
            {
                foreach (var instruction in instructions)
                {
                    Console.Write($"Instruction {instruction}, going ");
                    location = instruction == 'L' ? navigationByNode[location].Item1 : navigationByNode[location].Item2;
                    result++;
                    Console.WriteLine(location);

                    if (location.EndsWith('Z'))
                        return result;
                }
            }

            return result;
        }

        internal class Locations
        {
            internal Dictionary<string, string> CurrentByStarting = new Dictionary<string, string>();

            internal bool IsFinished()
            {
                return this.CurrentByStarting.Values.All( l => l.EndsWith('Z'));
            }
        }
    }
}
