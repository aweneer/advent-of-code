using System;
using System.IO;
using System.Collections.Generic;

namespace day_04
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("input.txt");
            Console.WriteLine(FirstPuzzle(input));
            //Console.WriteLine(SecondPuzzle(input));
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

            // TODO
            return -1;
        }
    }
}
