using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace day_05
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("input.txt");
            Console.WriteLine(FirstPuzzle(input));
            Console.WriteLine(SecondPuzzle(input));
        }

        public static int FirstPuzzle(string[] input)
        {
            List<Line> coords = new();
            int[] lineCoords = new int[4];
            int biggestCoord = -1;
            foreach (var line in input)
            {
                lineCoords = Array.ConvertAll(line.Split(new Char[] { ',', '-', '>', ' ' }, StringSplitOptions.RemoveEmptyEntries), nums => int.Parse(nums));
                if (biggestCoord < lineCoords.Max()) { biggestCoord = lineCoords.Max(); };
                coords.Add(new Line(lineCoords));
            }
            Diagram d = new(biggestCoord + 1);
            d.AddLines(coords);
            return d.overlaps;
        }

        public static int SecondPuzzle(string[] input)
        {
            List<Line> coords = new();
            int[] lineCoords = new int[4];
            int biggestCoord = -1;
            foreach (var line in input)
            {
                lineCoords = Array.ConvertAll(line.Split(new Char[] { ',', '-', '>', ' ' }, StringSplitOptions.RemoveEmptyEntries), nums => int.Parse(nums));
                if (biggestCoord < lineCoords.Max()) { biggestCoord = lineCoords.Max(); };
                coords.Add(new Line(lineCoords));
            }
            Diagram d = new(biggestCoord + 1);
            d.AddLinesWithDiagonals(coords);
            return d.overlaps;
        }

        internal class Line
        {
            public int x1, y1, x2, y2;

            public Line(int x1, int y1, int x2, int y2)
            {
                this.x1 = x1;
                this.y1 = y1;
                this.x2 = x2;
                this.y2 = y2;
            }

            public Line(int[] coords)
            {
                this.x1 = coords[0];
                this.y1 = coords[1];
                this.x2 = coords[2];
                this.y2 = coords[3];
            }

            public void PrintCoords()
            {
                Console.WriteLine("[" + x1 + "," + y1 + "][" + x2 + "," + y2 + "]");
            }
        }

        internal class Diagram
        {
            public int overlaps { get; set; } = 0;
            public string[,] coords { get; set; }
            public int size { get; set; }
            public Diagram(int size)
            {
                this.size = size;
                coords = new string[size, size];
                for (int x = 0; x < size; x++)
                {
                    for (int y = 0; y < size; y++)
                    {
                        coords[x, y] = ".";
                    }
                }
            }

            /// <summary>
            /// Method <c>DrawDiagram</c> prints out the current <c>Diagram</c> onto console output including numbered X and Y axes, it is limited for <c>Diagram</c> size of 250.
            /// </summary>
            public void DrawDiagram()
            {
                if (size > 250) { Console.WriteLine("Sorry, input too big, I won't draw all that sh**. Exiting DrawDiagram()"); return; }
                Console.Write("   ");
                for (int i = 0; i < size; i++)
                {
                    Console.Write(i+" ");
                }
                Console.Write(" x");
                Console.WriteLine("");
                Console.Write("  ");
                for (int i = 0; i < size * 2; i++)
                {
                    Console.Write("_");
                }
                Console.WriteLine();
                for (int x = 0; x < size; x++)
                {
                    if (x < 10) { Console.Write(x + " |"); }
                    else { Console.Write(x + "|"); }
                    for (int y = 0; y < size; y++)
                    {
                        Console.Write(coords[y, x] + " ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("y");
            }

            /// <summary>
            /// Method <c>DrawDiagramSimple</c> prints out the current <c>Diagram</c> onto console output in simplified form, it is limited for <c>Diagram</c> size of 250.
            /// </summary>
            public void DrawDiagramSimple()
            {
                if (size > 250) { Console.WriteLine("Sorry, input too big, I won't draw all that sh**. Exiting DrawDiagram()"); return; }
                for (int x = 0; x < size; x++)
                {
                    for (int y = 0; y < size; y++)
                    {
                        Console.Write(coords[y, x] + "");
                    }
                    Console.WriteLine();
                }
            }

            public void AddLines(List<Line> lines)
            {
                foreach (var l in lines)
                {
                    int n = 0;
                    if (l.x1 == l.x2 && l.y1 != l.y2)
                    {
                        for (int y = Math.Min(l.y1, l.y2); y < Math.Max(l.y1, l.y2) + 1; y++)
                        {
                            if (int.TryParse(coords[l.x1, y], out n)) { if (n == 1) { coords[l.x1, y] = (++n).ToString(); overlaps++; } }
                            else { coords[l.x1, y] = "1"; }
                        }
                    } else if (l.y1 == l.y2 && l.x1 != l.x2)
                    {
                        for (int x = Math.Min(l.x1, l.x2); x < Math.Max(l.x1, l.x2) + 1; x++)
                        {
                            if (int.TryParse(coords[x, l.y1], out n))
                            {
                                if (n == 1) { coords[x, l.y1] = (++n).ToString(); overlaps++; }
                            }
                            else { coords[x, l.y1] = "1"; }
                        }
                    }
                }
            }

            public void AddLinesWithDiagonals(List<Line> lines)
            {
                foreach (var l in lines)
                {
                    int n = 0;
                    if (l.x1 == l.x2 && l.y1 != l.y2)
                    {
                        for (int y = Math.Min(l.y1, l.y2); y < Math.Max(l.y1, l.y2) + 1; y++)
                        {
                            if (int.TryParse(coords[l.x1, y], out n)) { if (n == 1) { coords[l.x1, y] = (++n).ToString(); overlaps++; } }
                            else { coords[l.x1, y] = "1"; }
                        }
                    }
                    else if (l.y1 == l.y2 && l.x1 != l.x2)
                    {
                        for (int x = Math.Min(l.x1, l.x2); x < Math.Max(l.x1, l.x2) + 1; x++)
                        {
                            if (int.TryParse(coords[x, l.y1], out n))
                            {
                                if (n == 1) { coords[x, l.y1] = (++n).ToString(); overlaps++; }
                            }
                            else { coords[x, l.y1] = "1"; }
                        }
                    }
                    else if (l.x1 != l.x2 && l.y1 != l.y2)
                    {
                        for (int x = 0; x < Math.Abs(l.x1 - l.x2) + 1; x++)
                        {
                            if (l.x1 < l.x2)
                            {
                                if (l.y1 < l.y2)
                                {
                                    if (int.TryParse(coords[l.x1 + x, l.y1 + x], out n))
                                    {
                                        if (n == 1) { coords[l.x1 + x, l.y1 + x] = (++n).ToString(); overlaps++; }
                                    }
                                    else { coords[l.x1 + x, l.y1 + x] = "1"; }
                                }
                                else
                                {
                                    if (int.TryParse(coords[l.x1 + x, l.y1 - x], out n))
                                    {
                                        if (n == 1) { coords[l.x1 + x, l.y1 - x] = (++n).ToString(); overlaps++; }
                                    }
                                    else { coords[l.x1 + x, l.y1 - x] = "1"; }
                                }
                            } else
                            {
                                if (l.y1 < l.y2)
                                {
                                    if (int.TryParse(coords[l.x1 - x, l.y1 + x], out n))
                                    {
                                        if (n == 1) { coords[l.x1 - x, l.y1 + x] = (++n).ToString(); overlaps++; }
                                    }
                                    else { coords[l.x1 - x, l.y1 + x] = "1"; }
                                }
                                else
                                {
                                    if (int.TryParse(coords[l.x1 - x, l.y1 - x], out n))
                                    {
                                        if (n == 1) { coords[l.x1 - x, l.y1 - x] = (++n).ToString(); overlaps++; }
                                    }
                                    else { coords[l.x1 - x, l.y1 - x] = "1"; }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
