using System;
using System.IO;

namespace day_01
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("input.txt");
            Console.WriteLine("Total increases: " + FirstPuzzle(input));
            Console.WriteLine("Total increases: " + SecondPuzzle(input));
        }

        public static int FirstPuzzle(string[] input)
        {
            int previous = 0;
            int current;
            int increases = 0;

            foreach (string line in input)
            {
                current = int.Parse(line);
                if (current - previous > 0 && previous != 0)
                {
                    increases++;
                }
                previous = current;
            }
            return increases;
        }

        public static int SecondPuzzle(string[] input)
        {
            int previous = 0;
            int current = 0;
            int increases = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (i < input.Length - 3)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        current += int.Parse(input[i + j]);
                    }
                    if (current - previous > 0 && previous != 0)
                    {
                        increases++;
                    }
                    previous = current;
                }
                else
                {
                    for (int j = 0; j < 3; j++)
                    {
                        current += int.Parse(input[i + j]);
                    }
                    if (current - previous > 0 && previous != 0)
                    {
                        increases++;
                    }
                    break;
                }
                current = 0;
            }
            return increases;
        }
    }
}
