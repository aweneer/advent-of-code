using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Advent._2023
{
    public static class Code07
    {
        public static double FirstPuzzle(string[] input)
        {
            double result=  1;

            var hands =  new List<string>();
            var bidsByHands = new Dictionary<string, int>();

            // Prepare
            foreach (string line in input)
            {
                var splittedLine = line.Split(' ');
                var hand = splittedLine[0];
                hands.Add(hand);
                bidsByHands.Add(hand, int.Parse(splittedLine[1]));
            }


            foreach (var card in hands)
            {
                Console.WriteLine(card);

            }

            

            return result;
        }

        public static double SecondPuzzle(string[] input)
        {
            double result = 1;

            

            return result;
        }

        static Dictionary<string, int> Cards = new Dictionary<string, int>
        {
            { "A", 14 },
            { "K", 13 },
            { "Q", 12 },
            { "J", 11 },
            { "T", 10 },
            { "9", 9 },
            { "8", 8 },
            { "7", 7 },
            { "6", 6 },
            { "5", 5 },
            { "4", 4 },
            { "3", 3 },
            { "2", 2 }
        };

        static Dictionary<string, int> Types = new Dictionary<string, int>
        {
            { "5K", 5 },
            { "4K", 4 },
            { "FH", 5 },
            { "3K", 4 },
            { "2P", 3 },
            { "1P", 2 },
            { "HC", 1 },
        };
    }
}
