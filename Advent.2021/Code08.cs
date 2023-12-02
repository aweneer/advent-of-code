using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent._2021
{
    public static class Code08
    {
        public static int FirstPart(string[] entries)
        {
            string[][] output = new string[entries.Length][];
            for (int i = 0; i < entries.Length; i++)
            {
                string outputValues = entries[i].Substring(entries[i].LastIndexOf('|'));
                output[i] = (outputValues.Split(new Char[] { ' ', '|' }, StringSplitOptions.RemoveEmptyEntries)).ToArray();
            }
            int uniques = 0;
            foreach (var entry in output)
            {
                foreach (string pattern in entry)
                {
                    if (pattern.Length >= 2 && pattern.Length <= 4 || pattern.Length == 7) { uniques++; }
                }
            }
            return uniques;
        }

        public static int SecondPart(string[] entries)
        {
            // Processing input and output sides
            string[][] input = new string[entries.Length][];
            string[][] output = new string[entries.Length][];
            for (int i = 0; i < entries.Length; i++)
            {
                string inputValues = entries[i].Substring(0, entries[i].LastIndexOf('|'));
                string outputValues = entries[i].Substring(entries[i].LastIndexOf('|'));
                input[i] = (inputValues.Split(new Char[] { ' ', '|' }, StringSplitOptions.RemoveEmptyEntries)).ToArray();
                output[i] = (outputValues.Split(new Char[] { ' ', '|' }, StringSplitOptions.RemoveEmptyEntries)).ToArray();
            }

            // Mapping the input value signals
            string signal;
            List<Dictionary<int, string>> mappings = new();
            for (int i = 0; i < input.Length; i++)
            {
                Dictionary<int, string> mapping = new();
                Array.Sort(input[i], (x, y) => x.Length.CompareTo(y.Length));
                for (int j = 0; j < input[i].Length; j++)
                {
                    signal = input[i][j];
                    switch (signal.Length)
                    {
                        case 2:
                            if (!mapping.ContainsKey(1)) { mapping.Add(1, signal); }
                            break;
                        case 3:
                            if (!mapping.ContainsKey(7)) { mapping.Add(7, signal); }
                            break;
                        case 4:
                            if (!mapping.ContainsKey(4)) { mapping.Add(4, signal); }
                            break;
                        case 7:
                            if (!mapping.ContainsKey(8)) { mapping.Add(8, signal); }
                            break;
                        case 5:
                            if (PatternIncludedInSignal(mapping[1], signal) && !mapping.ContainsKey(3))
                            {
                                mapping.Add(3, signal);
                            }
                            else if (PatternIncludedInSignal((String.Concat(mapping[4].OrderBy(c => c).Except(String.Concat(mapping[7].OrderBy(c => c))))), signal) && !mapping.ContainsKey(5))
                            {
                                mapping.Add(5, signal);
                            }
                            else
                            {
                                if (!mapping.ContainsKey(2)) { mapping.Add(2, signal); }
                            }
                            break;
                        case 6:
                            if (PatternIncludedInSignal(mapping[7], signal) && !PatternIncludedInSignal(mapping[4], signal) && !mapping.ContainsKey(0))
                            {
                                mapping.Add(0, signal);
                            }
                            else if (PatternIncludedInSignal(mapping[7], signal) && PatternIncludedInSignal(mapping[4], signal) && !mapping.ContainsKey(9))
                            {
                                mapping.Add(9, signal);
                            }
                            else
                            {
                                if (!mapping.ContainsKey(6)) { mapping.Add(6, signal); }
                            }
                            break;
                        default:
                            break;
                    }
                }
                mappings.Add(mapping);
            }

            // Output values decoding
            int totalValue = 0;
            for (int i = 0; i < output.Length; i++)
            {
                string entryValue = "";
                int value = 0;
                for (int j = 0; j < output[i].Length; j++)
                {
                    signal = output[i][j];
                    switch (signal.Length)
                    {
                        case 2:
                            entryValue += "1";
                            break;
                        case 3:
                            entryValue += "7";
                            break;
                        case 4:
                            entryValue += "4";
                            break;
                        case 5:
                            if (PatternIncludedInSignal(mappings[i][3], signal)) { entryValue += "3"; }
                            else if (PatternIncludedInSignal(mappings[i][5], signal)) { entryValue += "5"; }
                            else { entryValue += "2"; }
                            break;
                        case 6:
                            if (PatternIncludedInSignal(mappings[i][7], signal) && !PatternIncludedInSignal(mappings[i][4], signal))
                            {
                                entryValue += "0";
                            }
                            else if (PatternIncludedInSignal(mappings[i][7], signal) && PatternIncludedInSignal(mappings[i][4], signal))
                            {
                                entryValue += "9";
                            }
                            else { entryValue += "6"; }
                            break;
                        case 7:
                            entryValue += "8";
                            break;
                    }
                }
                int result;
                if (int.TryParse(entryValue, out result)) { value = result; }
                totalValue += value;
            }
            return totalValue;
        }

        /// <summary>
        /// Checks if every character of required string pattern is included in signal. Return value indicates if the characters of pattern are included in the signal.
        /// </summary>
        /// <param name="pattern"></param> string value of pattern
        /// <param name="signal"></param> string value of signal/text
        /// <returns></returns>
        public static bool PatternIncludedInSignal(string pattern, string signal)
        {
            foreach (var character in pattern)
            {
                if (signal.IndexOf(character) == -1) { return false; }
            }
            return true;
        }
    }
}
