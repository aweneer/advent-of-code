using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent._2024
{
    public static class Code01
    {
        public static int FirstPuzzle(string[] input)
        {
            var leftNumbers = new List<int>();
            var rightNumbers = new List<int>();

            foreach (var line in input)
            {
                var split = line.Split("   ");
                leftNumbers.Add(int.Parse(split[0]));
                rightNumbers.Add(int.Parse(split[1]));
            }

            leftNumbers.Sort();
            rightNumbers.Sort();

            var distances = new List<int>();

            for (var position = 0; position < leftNumbers.Count; position++)
            {
                distances.Add(Math.Abs(leftNumbers[position] - rightNumbers[position]));
            }

            var result = distances.Sum();

            return result;
        }


        public static int SecondPuzzle(string[] input)
        {

            var leftNumbers = new List<int>();
            var rightOccurencesByNumber = new Dictionary<int, int>();

            foreach (var line in input)
            {
                var split = line.Split("   ");
                leftNumbers.Add(int.Parse(split[0]));

                var rightNumber = int.Parse(split[1]);

                if (rightOccurencesByNumber.ContainsKey(rightNumber))
                {
                    rightOccurencesByNumber[rightNumber]++;
                }
                else
                {
                    rightOccurencesByNumber.Add(rightNumber, 1);
                }
            }

            var similarityScore = new List<int>();

            foreach (var leftNumber in leftNumbers)
            {
                if (rightOccurencesByNumber.TryGetValue(leftNumber, out var occurence))
                {
                    similarityScore.Add(leftNumber * occurence);
                }
            }

            var result = similarityScore.Sum();

            return result;
        }
    }
}
