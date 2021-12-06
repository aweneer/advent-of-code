using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace day_06
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Array.ConvertAll(File.ReadAllLines("input.txt")[0].Split(','), nums => int.Parse(nums));
            Console.WriteLine(FirstPuzzle(input));
            Console.WriteLine(SecondPuzzle(input));
        }

        // Very naive and inefficient and memory leeching for high inputs
        public static int FirstPuzzle(int[] input)
        {
            List<int> water = input.ToList();
            Console.Write("Initial state: ");
            for (int i = 0; i < water.Count; i++) { if (i < water.Count - 1) { Console.Write(water[i] + ","); } else { Console.WriteLine(water[i]); } }
            for (int day = 0; day < 80; day++)
            {
                for (int fish = 0; fish < water.Count; fish++)
                {
                    if (water[fish]-- == 0) { water[fish] = 6; water.Add(9); }
                    
                }
                
                /*
                Console.Write("After\t" + (day + 1) + " day(s): ");
                for (int i = 0; i < water.Count; i++)
                {
                    if (i < water.Count - 1) { Console.Write(water[i] + ","); } else { Console.WriteLine(water[i]); }
                }  
                */
            }
            return (from fishes in water select fishes).Count();
        }

        public static int SecondPuzzle(int[] input)
        {
            int[] water = input;
            Console.Write("Initial state: \t\t");
            for (int i = 0; i < water.Length; i++) { if (i < water.Length - 1) { Console.Write(water[i] + ","); } else { Console.WriteLine(water[i]); } }

            // TODO
            return (from fishes in water select fishes).Count();
        }
    }
}
