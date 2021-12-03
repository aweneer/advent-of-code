using System;
using System.IO;

namespace day_02
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("input.txt");
            Console.WriteLine("Multiply result: " + FirstPuzzle(input));
            Console.WriteLine("Multiply result: " + SecondPuzzle(input));
        }

        private static int FirstPuzzle(string[] input)
        {
            int horizontal = 0;
            int depth = 0;

            foreach (string line in input)
            {
                string[] splitLine = line.Split(" ");
                string command = splitLine[0];
                int value = int.Parse(splitLine[1]);
                switch (command)
                {
                    case "up":
                        depth -= value;
                        break;
                    case "down":
                        depth += value;
                        break;
                    default:
                        horizontal += value;
                        break;
                }
            }
            return horizontal * depth;
        }

        private static int SecondPuzzle(string[] input)
        {
            int horizontal = 0;
            int depth = 0;
            int aim = 0;

            foreach (string line in input)
            {
                string[] splitLine = line.Split(" ");
                string command = splitLine[0];
                int value = int.Parse(splitLine[1]);
                switch (command)
                {
                    case "up":
                        aim -= value;
                        break;
                    case "down":
                        aim += value;
                        break;
                    default:
                        horizontal += value;
                        depth += value * aim;
                        break;
                }
            }
            return horizontal * depth;
        }
    }
}
