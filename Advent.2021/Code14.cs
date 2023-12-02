using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent._2021
{
    public static class Code14
    {
        // Very naive, inefficient and memory leeching for high inputs
        public static int FirstPart(string[] input)
        {
            Tuple<string, char>[] rules = new Tuple<string, char>[input.Length - 2];
            Dictionary<char, int> elementQuantity = new();
            for (int i = 2; i < input.Length; i++)
            {
                char element = input[i].Substring(input[i].Length - 1, 1).ToCharArray()[0];
                rules[i - 2] = new(input[i].Substring(0, 2), element);
                if (!elementQuantity.ContainsKey(element))
                {
                    elementQuantity.Add(element, 0);
                }
            }

            string polymer = input[0];
            // Adding single element counts of base polymer
            foreach (var element in polymer)
            {
                elementQuantity[element]++;
            }

            for (int step = 0; step < 10; step++)
            {
                for (int i = 0; i < polymer.Length - 1; i += 2)
                {
                    string pair = polymer.Substring(i, 2);
                    foreach (var rule in rules)
                    {
                        if (rule.Item1.Equals(pair))
                        {
                            polymer = polymer.Insert(i + 1, rule.Item2.ToString());
                            elementQuantity[rule.Item2]++;
                            break;
                        }
                    }
                }
            }
            return elementQuantity.Values.Max() - elementQuantity.Values.Min();
        }

        public static long SecondPart(string[] input)
        {
            Dictionary<string, Tuple<string, string>> pairsFromRule = new();
            Dictionary<string, long> pairs = new();
            Dictionary<char, long> elementQuantity = new();

            // Adding single element counts of base polymer
            string polymer = input[0];
            for (int i = 0; i < polymer.Length; i++)
            {
                if (!elementQuantity.ContainsKey(polymer[i]))
                {
                    elementQuantity.Add(polymer[i], 1);
                }
                else
                {
                    elementQuantity[polymer[i]]++;
                }
            }
            // Create all possible pairs and all possible pairs based on pair insertion rules
            for (int i = 2; i < input.Length; i++)
            {
                char element = input[i].Substring(input[i].Length - 1, 1).ToCharArray()[0];
                pairs.Add(input[i].Substring(0, 2), 0);
                pairsFromRule.Add(input[i].Substring(0, 2), new(input[i].Substring(0, 1) + element, element + input[i].Substring(1, 1)));
            }
            // Adding counts of pairs from base polymer
            for (int i = 1; i < polymer.Length; i++)
            {
                pairs[polymer[i - 1].ToString() + polymer[i].ToString()]++;
            }
            // Polymerization
            for (int step = 0; step < 40; step++)
            {
                var currentPairs = new Dictionary<string, long>(pairs);
                foreach (var pair in pairs)
                {
                    if (pair.Value > 0)
                    {
                        var generates = pairsFromRule[pair.Key];
                        currentPairs[generates.Item1] += pair.Value;
                        currentPairs[generates.Item2] += pair.Value;

                        var character = generates.Item1[1];
                        if (elementQuantity.ContainsKey(character)) { elementQuantity[character] += pair.Value; }
                        else { elementQuantity.Add(character, pair.Value); }
                        currentPairs[pair.Key] -= pair.Value;
                    }
                }
                pairs = currentPairs;
            }
            return elementQuantity.Values.Max() - elementQuantity.Values.Min();
        }
    }
}
