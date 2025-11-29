using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Advent._2023
{
    public static class Code04
    {
        public static double FirstPuzzle(string[] input)
        {
            double result = 0;

            foreach (var line in input)
            {
                var splitNumbers = line.Split('|');
                var winningNumbers = Regex.Match(splitNumbers[0], @":\s*([\d\s]+)$").Groups[1].Value.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var numbers = splitNumbers[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);

                var matchingNumbers = winningNumbers.Count(n => numbers.Contains(n));

                if (matchingNumbers >= 1)
                    result += Math.Pow(2, matchingNumbers - 1);
            }

            return result;
        }

        public static double SecondPuzzle(string[] input)
        {
            double result = 0;

            Dictionary<int, int> copiesPerCard = new Dictionary<int, int>();

            for (int cardNumber = 1; cardNumber < input.Length + 1; cardNumber++)
            {
                foreach (var item in copiesPerCard)
                {
                    Console.WriteLine("Card " + item.Key + " : " + item.Value);
                }
                // Add for the original
                if (!copiesPerCard.ContainsKey(cardNumber))
                    copiesPerCard[cardNumber] = 1;
                else
                    copiesPerCard[cardNumber]++;

                var line = input[cardNumber-1];
                var splitNumbers = line.Split('|');
                var winningNumbers = Regex.Match(splitNumbers[0], @":\s*([\d\s]+)$").Groups[1].Value.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var numbers = splitNumbers[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);

                var matchingNumbers = winningNumbers.Count(n => numbers.Contains(n));

                // Add for copies
                for (int num = cardNumber + 1; num < cardNumber + matchingNumbers + 1; num++)
                {
                    if (copiesPerCard.ContainsKey(num))
                        copiesPerCard[num] += 1 * copiesPerCard[cardNumber];
                    else
                        copiesPerCard[num] = 1 * copiesPerCard[cardNumber];
                }
            }

            foreach (var copies in copiesPerCard.Values)
            {
                result += copies;
            }
            return result;
        }
    }
}
