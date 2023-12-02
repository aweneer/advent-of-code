using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Utilities;

namespace Advent._2023
{
    public static class Code02
    {
        public static int FirstPuzzle(string[] input)
        {
            var result = 0;

            var targetColors = new Dictionary<string, int>()
            {
                { "red", 12 },
                { "green", 13 },
                { "blue", 14 }
            };

            var colorsByGame = GetColorsByGame(input);

            foreach (var game in colorsByGame)
            {
                if (targetColors.Any( t => game.Value[t.Key] > t.Value))
                    continue;

                result += game.Key;
            }

            return result;
        }

        public static int SecondPuzzle(string[] input)
        {
            var result = 0;
            var colorsByGame = GetColorsByGame(input);

            foreach (var game in colorsByGame)
            {
                var power = game.Value["red"] * game.Value["green"] * game.Value["blue"];
                result += power;
            }

            return result;
        }

        public static Dictionary<string, int> GetMaximumByColor(string[] sets)
        {
            var numberByColor = new Dictionary<string, int>();

            foreach (var handfulOfCubes in sets)
            {
                var colors = handfulOfCubes.Split(",");

                foreach (var color in colors)
                {
                    var word = Regex.Match(color, @"[a-zA-z]+").Value;
                    var number = int.Parse(Regex.Match(color, @"\d+").Value);

                    if (!numberByColor.ContainsKey(word) || numberByColor[word] < number)
                        numberByColor[word] = number;
                }
            }

            return numberByColor;
        }

        public static Dictionary<int, Dictionary<string, int>> GetColorsByGame(string[] input)
        {
            var colorsByGame = new Dictionary<int, Dictionary<string, int>>();

            foreach (var line in input)
            {
                var split = line.Split(':');
                var gameId = int.Parse(Regex.Match(split[0], @"\d+").Value);
                var sets = split[1].Split(";");

                var numberByColor = GetMaximumByColor(sets);
                colorsByGame.Add(gameId, numberByColor);
            }

            return colorsByGame;
        }
    }
}
