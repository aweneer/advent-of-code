using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace day_10
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("input.txt");
            Console.WriteLine(FirstPart(input));
            Console.WriteLine(SecondPart(input));
        }

        public static int FirstPart(string[] input)
        {
            Dictionary<char, int> scoreRatings = new();
            scoreRatings.Add(')', 3);
            scoreRatings.Add(']', 57);
            scoreRatings.Add('}', 1197);
            scoreRatings.Add('>', 25137);

            List<char> illegalSymbols = new();
            Stack<char> openings = new();
            foreach (var line in input)
            {
                foreach (var symbol in line)
                {
                    if (new[] { '(', '[', '{', '<' }.Any(ch => symbol.ToString().Contains(ch)))
                    {
                        openings.Push(symbol);
                    }
                    else
                    {
                        if (openings.Peek() == '(' && symbol == ')') { openings.Pop(); }
                        else if (openings.Peek() == '[' && symbol == ']') { openings.Pop(); }
                        else if (openings.Peek() == '{' && symbol == '}') { openings.Pop(); }
                        else if (openings.Peek() == '<' && symbol == '>') { openings.Pop(); }
                        else { illegalSymbols.Add(symbol); break; }
                    }
                }
            }
            int score = 0;
            foreach (var symbol in illegalSymbols) { score += scoreRatings[symbol]; }
            return score;
        }

        public static int SecondPart(string[] input)
        {
            return -1;
        }

    }
}
