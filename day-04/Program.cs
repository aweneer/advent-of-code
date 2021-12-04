using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace day_04
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
            int[] numbers = Array.ConvertAll(input[0].Split(","), nums => int.Parse(nums));
            List<int[,]> boards = new List<int[,]>();
            int[,] board = new int[5, 5];
            int lines = 0;  

            // Prepare boards from input
            for (int i = 1; i < input.Length; i++)
            {
                if (input[i].Length != 0)
                {                    
                    string[] line = input[i].Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    for (int j = 0; j < line.Length; j++)
                    {
                        board[lines, j % 5] = Int32.Parse(line[j]); 
                    }

                    if (++lines == 5)
                    {
                        boards.Add(board);
                        board = new int[5,5];
                        lines = 0;
                    }
                }
            }
            
            int[] markedInBoard = new int[boards.Count];
            bool win = false;
            int lastDraw = -1;
            int winningBoard = -1;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (win) { lastDraw = numbers[i-1]; break; }
                for (int b = 0; b < boards.Count; b++)
                {
                    for (int x = 0; x < 5; x++)
                    {
                        for (int y = 0; y < 5; y++)
                        {
                            if (boards[b][x,y] == numbers[i])
                            {
                                boards[b][x,y] = -1;
                                markedInBoard[b] += 1;
                            }
                        }
                    }

                    if (markedInBoard[b] >= 5)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            if ((markedInBoard[b] >= 5) && (boards[b][0, j] == -1 && boards[b][1, j] == -1 && boards[b][2, j] == -1 && boards[b][3, j] == -1 && boards[b][4, j] == -1))
                            {
                                win = true;
                                winningBoard = b;
                            }
                            if ((markedInBoard[b] >= 5) && boards[b][j, 0] == -1 && boards[b][j, 1] == -1 && boards[b][j, 2] == -1 && boards[b][j, 3] == -1 && boards[b][j, 4] == -1)
                            {
                                win = true;
                                winningBoard = b;
                            }
                        }
                    }
                }
            }

            int sum = 0;
            for (int x = 0; x < 5; x++)
            {
                for (int y = 0; y < 5; y++)
                {
                    if (boards[winningBoard][x, y] != -1)
                    {
                        sum += boards[winningBoard][x, y];
                    }
                }
            }
            return sum * lastDraw;
        }

        public static int SecondPuzzle(string[] input)
        {
            int[] numbers = Array.ConvertAll(input[0].Split(","), nums => int.Parse(nums));

            List<Board> boards = new List<Board>();
            int lines = 0;
            Board board = new();

            // Prepare boards from input
            for (int i = 1; i < input.Length; i++)
            {
                if (input[i].Length != 0)
                {
                    string[] line = input[i].Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    for (int j = 0; j < line.Length; j++)
                    {
                        board.values[lines, j % 5] = Int32.Parse(line[j]);
                    }

                    if (++lines == 5)
                    {
                        boards.Add(board);
                        board = new();
                        lines = 0;
                    }
                }
            }

            int lastDraw = -1;
            int lastBoard = -1;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (boards.Where(b => b.hasWon == false).Count() == 0) { lastDraw = numbers[i - 1]; break; }

                for (int b = 0; b < boards.Count; b++)
                {
                    if (!boards[b].hasWon)
                    {
                        for (int x = 0; x < 5; x++)
                        {
                            for (int y = 0; y < 5; y++)
                            {
                                if (boards[b].values[x, y] == numbers[i])
                                {
                                    boards[b].AddMarker(x, y);
                                }
                            }
                        }
                        if (boards[b].totalMarkers >= 5)
                        {
                            for (int j = 0; j < 5; j++)
                            {
                                if ((boards[b].markers[0, j] == -1 && boards[b].markers[1, j] == -1 && boards[b].markers[2, j] == -1 && boards[b].markers[3, j] == -1 && boards[b].markers[4, j] == -1))
                                {
                                    boards[b].hasWon = true;
                                    lastBoard = b;
                                }
                                if (boards[b].markers[j, 0] == -1 && boards[b].markers[j, 1] == -1 && boards[b].markers[j, 2] == -1 && boards[b].markers[j, 3] == -1 && boards[b].markers[j, 4] == -1)
                                {
                                    boards[b].hasWon = true;
                                    lastBoard = b;
                                }
                            }
                        }
                    }

                }
            }
            return boards[lastBoard].CountUnmarkedCurrentSum() * lastDraw;
        }
    }

    internal class Board
    {
        public int[,] values { get; set; } = new int[5, 5];
        public int[,] markers { get; set; } = new int[5, 5];
        public int totalMarkers = 0;
        public bool hasWon { get; set; }

        public void AddMarker(int x, int y)
        {
            markers[x, y] = -1;
            totalMarkers++;
        }

        public void DrawBoard()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(this.values[i, 0] + " " + this.values[i, 1] + " " + this.values[i, 2] + " " + this.values[i, 3] + " " + this.values[i, 4]);
            }
        }

        public void DrawBoardMarkers()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(this.markers[i, 0] + " " + this.markers[i, 1] + " " + this.markers[i, 2] + " " + this.markers[i, 3] + " " + this.markers[i, 4]);
            }
        }

        public int CountUnmarkedCurrentSum()
        {
            int sum = 0;
            for (int x = 0; x < 5; x++)
            {
                for (int y = 0; y < 5; y++)
                {
                    if (this.markers[x, y] != -1)
                    {
                        sum += this.values[x, y];
                    }
                }
            }
            return sum;
        }
    }
}
