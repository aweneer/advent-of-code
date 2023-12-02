using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent._2021
{
    public static class Code09
    {
        private static int FirstPart(string[] input)
        {
            int[,] digits = new int[input.Length, input[0].Length];
            for (int y = 0; y < input.Length; y++)
            {
                for (int x = 0; x < input[0].Length; x++)
                {
                    digits[y, x] = int.Parse(input[y][x].ToString());
                }
            }
            int lows = 0;
            for (int y = 0; y < input.Length; y++)
            {
                for (int x = 0; x < input[0].Length; x++)
                {
                    if (y == 0)
                    {
                        if (x == 0)
                        {
                            if (digits[y, x] < digits[y + 1, x] && digits[y, x] < digits[y, x + 1]) { lows += digits[y, x] + 1; }
                        }
                        else if (x == (input[0].Length - 1))
                        {
                            if (digits[y, x] < digits[y + 1, x] && digits[y, x] < digits[y, x - 1]) { lows += digits[y, x] + 1; }
                        }
                        else
                        {
                            if (digits[y, x] < digits[y + 1, x] && digits[y, x] < digits[y, x - 1] && digits[y, x] < digits[y, x + 1]) { lows += digits[y, x] + 1; }
                        }
                    }
                    else if (y == (input.Length - 1))
                    {
                        if (x == 0)
                        {
                            if (digits[y, x] < digits[y - 1, x] && digits[y, x] < digits[y, x + 1]) { lows += digits[y, x] + 1; }
                        }
                        else if (x == (input[0].Length - 1))
                        {
                            if (digits[y, x] < digits[y - 1, x] && digits[y, x] < digits[y, x - 1]) { lows += digits[y, x] + 1; }
                        }
                        else
                        {
                            if (digits[y, x] < digits[y - 1, x] && digits[y, x] < digits[y, x - 1] && digits[y, x] < digits[y, x + 1]) { lows += digits[y, x] + 1; }
                        }
                    }
                    else
                    {
                        if (x == 0)
                        {
                            if (digits[y, x] < digits[y - 1, x] && digits[y, x] < digits[y, x + 1] && digits[y, x] < digits[y + 1, x]) { lows += digits[y, x] + 1; }
                        }
                        else if (x == (input[0].Length - 1))
                        {
                            if (digits[y, x] < digits[y - 1, x] && digits[y, x] < digits[y, x - 1] && digits[y, x] < digits[y + 1, x]) { lows += digits[y, x] + 1; }
                        }
                        else
                        {
                            if (digits[y, x] < digits[y - 1, x] && digits[y, x] < digits[y + 1, x] && digits[y, x] < digits[y, x - 1] && digits[y, x] < digits[y, x + 1]) { lows += digits[y, x] + 1; }
                        }
                    }
                }
            }
            return lows;
        }

        private static int SecondPart(string[] input)
        {
            return -1;
        }
    }
}
