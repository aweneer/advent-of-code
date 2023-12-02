using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Utilities;

namespace Advent._2023
{
    public static class Code01
    {
        public static int FirstPuzzle(string[] input) {

            var result = 0;
            foreach (string line in input)
            {
                var firstDigit = line.FirstOrDefault(ch => char.IsDigit(ch));
                if (firstDigit == 0)
                    continue;

                var lastDigit = line.LastOrDefault(ch => char.IsDigit(ch));
                var fullDigit = string.Concat(firstDigit, lastDigit);
                result += int.Parse(fullDigit);
            }

            return result;
        }


        public static int SecondPuzzle(string[] input)
        {
            
            var result = 0;

            List<string> numbersList = new();
            foreach(string line in input)
            {
                var chars = line.ToCharArray();
                var sb = new StringBuilder();
                string? overlapString = null;
                foreach (var ch in chars)
                {
                    if ( char.IsDigit(ch) )
                    {
                        numbersList.Add(ch.ToString());
                        continue;
                    }

                    sb.Append(ch);
                    var overlappedString = overlapString + sb.ToString();

                    if ( Utilities2023.numberByWord.Keys.Any( k => k.StartsWith(sb.ToString() )) )
                    {
                        if ( Utilities2023.numberByWord.TryGetValue( sb.ToString(), out var number ) )
                        {
                            overlapString = sb.ToString().Last().ToString();
                            numbersList.Add(number.ToString());
                            sb.Clear();                         
                        }
                    }
                    else if ( Utilities2023.numberByWord.Keys.Any( k => k.StartsWith(overlappedString )))
                    {
                        if ( Utilities2023.numberByWord.TryGetValue( overlappedString, out var overlappedNumber ))
                        {
                            overlapString = sb.ToString().Last().ToString();
                            numbersList.Add(overlappedNumber.ToString());
                            sb.Clear();
                        }
                    }
                    else if ( Utilities2023.numberByWord.Keys.Any( k => k.StartsWith(sb.ToString()[1..] )))
                    {
                        var rest = sb.ToString()[1..];
                        sb.Clear();
                        sb.Append(rest);
                    }
                    else
                    {
                        overlapString = null;
                        sb.Clear();
                    }
                }

                var singularNumber = string.Concat(numbersList);
                numbersList.Clear();
                result += FirstPuzzle(new[] { singularNumber });
            }
            return result;
        }
    }
}
