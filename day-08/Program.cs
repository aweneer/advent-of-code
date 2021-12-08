using System;
using System.IO;
using System.Linq;

namespace day_08
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("input.txt");
            Console.WriteLine(FirstPart(input));
            Console.WriteLine(SecondPart(input));
        }

        public static int FirstPart(string[] input)
        {
            string[][] entries = new string[input.Length][];
            for (int i = 0; i < input.Length; i++)
            {
                string outputValues = input[i].Substring(input[i].LastIndexOf('|'));
                entries[i] = (outputValues.Split(new Char[] { ' ', '|' }, StringSplitOptions.RemoveEmptyEntries)).ToArray();
            }
            int uniques = 0;
            foreach (var entry in entries)
            {
                foreach (string pattern in entry)
                {
                    if (pattern.Length >= 2 && pattern.Length <= 4 || pattern.Length == 7) { uniques++; }
                }
            }
            return uniques;
        }

        public static int SecondPart(string[] input)
        {
            return -1;
        }
    }
}
