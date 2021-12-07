using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace day_07
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Array.ConvertAll(File.ReadAllLines("input.txt")[0].Split(','), nums => int.Parse(nums));
            Console.WriteLine(FirstPart(input));
            Console.WriteLine(SecondPart(input));
        }

        public static int FirstPart(int[] input)
        {
            int max = input.Max();
            List<int> consumptions = new();
            
            for (int pos = 0; pos < max; pos++)
            {
                int sum = 0;
                for (int crab = 0; crab < input.Length; crab++)
                {
                    sum += Math.Abs(input[crab] - pos);
                    //Console.WriteLine("- Move from " + input[crab] + " to " + pos + ": " + (Math.Abs(input[crab] - pos)) + " fuel");
                }
                //Console.WriteLine();
                consumptions.Add(sum);
            }
            return consumptions.Min();
        }

        public static int SecondPart(int[] input)
        {
            int max = input.Max();
            int[] consumptions = new int[max];

            for (int pos = 0; pos < max; pos++)
            {
                int sum = 0;
                for (int crab = 0; crab < input.Length; crab++)
                {
                    int diff = Math.Abs(input[crab] - pos);
                    double a = (Math.Pow(diff, 2) + diff) / 2;
                    sum += (int)a;
                }                
                consumptions[pos] = sum;
            }
            return consumptions.Min();
        }
    }
}
