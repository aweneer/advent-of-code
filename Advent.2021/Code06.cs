using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent._2021
{
    public static class Code06
    {
        // Very naive and inefficient and memory leeching for high inputs
        public static int FirstPuzzle(int[] input)
        {
            List<int> water = input.ToList();
            for (int day = 0; day < 80; day++)
            {
                for (int fish = 0; fish < water.Count; fish++)
                {
                    if (water[fish]-- == 0) { water[fish] = 6; water.Add(9); }
                }
            }
            return (from fishes in water select fishes).Count();
        }

        public static long SecondPuzzle(int[] input)
        {
            long[] fishes = new long[9];
            for (int i = 0; i < input.Length; i++)
            {
                fishes[input[i]] += 1;
            }

            for (int day = 0; day < 256; day++)
            {
                long f = fishes[0];
                for (int age = 0; age < 8; age++) { fishes[age] = fishes[age + 1]; }
                fishes[6] += f;
                fishes[8] = f;
            }

            long sum = 0;
            foreach (var fishCount in fishes) { sum += fishCount; }
            return sum;
        }
    }
}
