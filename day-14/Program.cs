using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace day_14
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("input.txt");
            Console.WriteLine(FirstPart(input));
            Console.WriteLine(SecondPart(input));
        }

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
            // Adding counts for base polymer
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
        
        public static int SecondPart(string[] input)
        {
            return -1;
        }
    }
}
