using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent._2021
{
    public static class Code11
    {
        private static int flashes = 0;

        public static int FirstPart(string[] input, int steps)
        {
            int[,] octopuses = new int[input.Length, input[0].Length];
            for (int y = 0; y < input.Length; y++)
            {
                for (int x = 0; x < input[0].Length; x++) { octopuses[y, x] = int.Parse(input[y][x].ToString()); }
            }

            for (int i = 0; i < steps; i++)
            {
                for (int y = 0; y < input.Length; y++)
                {
                    for (int x = 0; x < input[0].Length; x++) { octopuses[y, x]++; }
                }

                for (int y = 0; y < input.Length; y++)
                {
                    for (int x = 0; x < input[0].Length; x++)
                    {
                        if (octopuses[y, x] > 9) { FlashAndIncreaseAdjacent(octopuses, y, x); }
                    }
                }

            }
            return flashes;
        }

        public static int SecondPart(string[] input, int steps)
        {
            int terminalStep = -1;
            int[,] octopuses = new int[input.Length, input[0].Length];
            for (int y = 0; y < input.Length; y++)
            {
                for (int x = 0; x < input[0].Length; x++) { octopuses[y, x] = int.Parse(input[y][x].ToString()); }
            }

            for (int i = 0; i < steps; i++)
            {
                if (AreSynchronized(octopuses) && terminalStep == -1)
                {
                    terminalStep = i;
                    break;
                }

                for (int y = 0; y < input.Length; y++)
                {
                    for (int x = 0; x < input[0].Length; x++) { octopuses[y, x]++; }
                }

                for (int y = 0; y < input.Length; y++)
                {
                    for (int x = 0; x < input[0].Length; x++)
                    {
                        if (octopuses[y, x] > 9) { FlashAndIncreaseAdjacent(octopuses, y, x); }
                    }
                }

            }
            return terminalStep;
        }

        public static void FlashAndIncreaseAdjacent(int[,] octopuses, int y, int x)
        {
            flashes++;
            octopuses[y, x] = 0;
            for (int vertical = y - 1; vertical < y + 2; vertical++)
            {
                for (int horizontal = x - 1; horizontal < x + 2; horizontal++)
                {
                    if ((vertical >= 0 && vertical < octopuses.GetLength(0)) && (horizontal >= 0 && horizontal < octopuses.GetLength(1)))
                    {
                        if (octopuses[vertical, horizontal] != 0) { octopuses[vertical, horizontal]++; }
                        if (octopuses[vertical, horizontal] > 9) { FlashAndIncreaseAdjacent(octopuses, vertical, horizontal); }
                    }
                }
            }
        }

        public static bool AreSynchronized(int[,] octo)
        {
            if (octo[0, 0] == 0 && octo[0, 1] == 0 && octo[1, 0] == 0)
            {
                for (int y = 0; y < octo.GetLength(0); y++)
                {
                    for (int x = 0; x < octo.GetLength(1); x++)
                    {
                        if (octo[y, x] != 0) { return false; }
                    }
                }
                return true;
            }
            return false;
        }
    }
}
