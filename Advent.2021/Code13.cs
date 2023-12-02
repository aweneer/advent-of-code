using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent._2021
{
    public static class Code13
    {
        public static int FirstPuzzle(string[] input)
        {
            List<Tuple<string, int>> folds = new();
            List<int> xx = new();
            List<int> yy = new();
            foreach (var line in input)
            {
                if (line.Contains(','))
                {
                    string[] split = line.Split(',');
                    xx.Add(int.Parse(split[0]));
                    yy.Add(int.Parse(split[1]));
                }
                else if (line.Contains("x="))
                {
                    folds.Add(new("x", int.Parse(line.Substring(line.IndexOf('=') + 1))));
                }
                else if (line.Contains("y="))
                {
                    folds.Add(new("y", int.Parse(line.Substring(line.IndexOf('=') + 1))));
                }
            }
            //Console.WriteLine(yy.Max() + "++" + xx.Max());
            string[,] grid = new string[yy.Max() + 1, xx.Max() + 1];

            for (int y = 0; y < grid.GetLength(0); y++)
            {
                for (int x = 0; x < grid.GetLength(1); x++)
                {
                    grid[y, x] = ".";
                }
            }

            for (int i = 0; i < xx.Count; i++)
            {
                grid[yy[i], xx[i]] = "#";
            }

            for (int y = 0; y < grid.GetLength(0); y++)
            {
                for (int x = 0; x < grid.GetLength(1); x++)
                {
                    //Console.Write(grid[y,x]);
                }
                //Console.WriteLine();
            }

            string[,] gy1 = new string[grid.GetLength(0) / 2, grid.GetLength(1)];
            string[,] gy2 = new string[grid.GetLength(0) / 2, grid.GetLength(1)];
            string[,] gx1 = new string[grid.GetLength(0), grid.GetLength(1) / 2];
            string[,] gx2 = new string[grid.GetLength(0), grid.GetLength(1) / 2];
            //Console.WriteLine(g.GetLength(0));
            //Console.WriteLine("\n\n");
            int dotsVisible = 0;
            if (folds[0].Item1 == "y")
            {
                for (int y = 0; y < grid.GetLength(0) / 2; y++)
                {
                    for (int x = 0; x < grid.GetLength(1); x++)
                    {
                        gy1[y, x] = grid[y, x];
                        gy2[y, x] = ".";
                    }
                }

                for (int y = 0; y < gy1.GetLength(0); y++)
                {
                    for (int x = 0; x < gy1.GetLength(1); x++)
                    {
                        //Console.Write(g[y, x]);
                    }
                    //Console.WriteLine();
                }

                //Console.WriteLine("\n\n");
                int row = 0;
                for (int y = grid.GetLength(0) - 1; y > ((grid.GetLength(0) / 2)); y--)
                {
                    if (row == 7) { break; }
                    int col = 0;
                    for (int x = grid.GetLength(1) - 1; x > -1; x--)
                    {
                        //Console.WriteLine(y + ":" + x);
                        gy2[row, x] = grid[y, x];
                        col++;
                    }
                    row++;
                }


                for (int y = 0; y < gy2.GetLength(0); y++)
                {
                    for (int x = 0; x < gy2.GetLength(1); x++)
                    {
                        //Console.Write(g2[y, x]);
                    }
                    //Console.WriteLine();
                }

                for (int y = 0; y < gy2.GetLength(0); y++)
                {
                    for (int x = 0; x < gy2.GetLength(1); x++)
                    {
                        if (gy1[y, x] == "#" || gy2[y, x] == "#") { gy1[y, x] = "#"; dotsVisible++; }
                    }
                }

                for (int y = 0; y < gy1.GetLength(0); y++)
                {
                    for (int x = 0; x < gy1.GetLength(1); x++)
                    {
                        //Console.Write(g[y, x]);
                    }
                    //Console.WriteLine();
                }

            }
            else
            {
                for (int y = 0; y < grid.GetLength(0); y++)
                {
                    for (int x = 0; x < grid.GetLength(1) / 2; x++)
                    {
                        //Console.WriteLine(y + " " + x);
                        gx1[y, x] = grid[y, x];
                        gx2[y, x] = ".";
                    }
                }

                for (int y = 0; y < gx1.GetLength(0); y++)
                {
                    for (int x = 0; x < gx1.GetLength(1); x++)
                    {
                        //Console.Write(g[y, x]);
                    }
                    //Console.WriteLine();
                }

                //Console.WriteLine("\n\n");
                int row = 0;
                for (int y = grid.GetLength(0) - 1; y > -1; y--)
                {
                    if (row == grid.GetLength(1) / 2) { break; }
                    int col = 0;
                    for (int x = grid.GetLength(1) - 1; x > (grid.GetLength(1) / 2); x--)
                    {
                        gx2[y, row] = grid[y, x];
                        col++;
                    }
                    row++;
                }

                for (int y = 0; y < gx2.GetLength(0); y++)
                {
                    for (int x = 0; x < gx2.GetLength(1); x++)
                    {
                        if (gx1[y, x] == "#" || gx1[y, x] == "#") { gx1[y, x] = "#"; dotsVisible++; }
                    }
                }
            }

            return dotsVisible;
        }

        public static int SecondPuzzle(string[] input)
        {
            return -1;
        }
    }
}
