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

        public static long SecondPart(string[] input)
        {
            Dictionary<char, int> scoreRatings = new();
            scoreRatings.Add(')', 1);
            scoreRatings.Add(']', 2);
            scoreRatings.Add('}', 3);
            scoreRatings.Add('>', 4);

            List<Stack<char>> openings = new();
            Stack<char> opening = new();

            bool illegal = false;
            foreach (var line in input)
            {
                illegal = false;
                opening.Clear();
                foreach (var symbol in line)
                {
                    if (new[] { '(', '[', '{', '<' }.Any(ch => symbol.ToString().Contains(ch)))
                    {
                        opening.Push(symbol);
                    }
                    else
                    {
                        if (opening.Peek() == '(' && symbol == ')') { opening.Pop(); }
                        else if (opening.Peek() == '[' && symbol == ']') { opening.Pop(); }
                        else if (opening.Peek() == '{' && symbol == '}') { opening.Pop(); }
                        else if (opening.Peek() == '<' && symbol == '>') { opening.Pop(); }
                        else { illegal = true; break; }
                    }
                }
                if (!illegal) { openings.Add(new(opening)); }
            }

            string[] addedSymbols = new string[openings.Count];
            for (int i = 0; i < openings.Count; i++)
            {
                while (openings[i].Count > 0)
                {
                    if (openings[i].Peek() == '(') { addedSymbols[i] += ")"; openings[i].Pop(); }
                    else if (openings[i].Peek() == '[') { addedSymbols[i] += "]"; openings[i].Pop(); }
                    else if (openings[i].Peek() == '{') { addedSymbols[i] += "}"; openings[i].Pop(); }
                    else if (openings[i].Peek() == '<') { addedSymbols[i] += ">"; openings[i].Pop(); }
                }
            }

            List<long> scores = new();
            for (int i = 0; i < addedSymbols.Length; i++)
            {
                long score = 0;
                foreach (var symbol in addedSymbols[i].Reverse())
                {
                    score = 5 * score + scoreRatings[symbol];
                }
                scores.Add(score);
            }
            scores.Sort();
            return scores[scores.Count / 2];
        }

    }
}
