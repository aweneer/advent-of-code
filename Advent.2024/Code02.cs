using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace Advent._2024
{
    internal class Code02
    {
        public static int FirstPuzzle(string[] input)
        {
            var totalSafeReport = 0;
            foreach (var line in input)
            {
                var levels = line.Split(" ").Select(x => int.Parse(x)).ToArray();

                bool isIncreasing = levels[0] < levels[1];
                bool isSafe = true;

                for (int index = 0; index < levels.Length - 1; index++)
                {
                    int currentLevel = levels[index];

                    if (isIncreasing && currentLevel >= levels[index + 1] || Math.Abs(levels[index + 1] - currentLevel) > 3)
                    {
                        isSafe = false;
                        break;
                    }

                    if (!isIncreasing && currentLevel <= levels[index + 1] || Math.Abs(levels[index + 1] - currentLevel) > 3)
                    {
                        isSafe = false;
                        break;
                    }
                }

                if (isSafe)
                    totalSafeReport += 1;
            }

            return totalSafeReport;
        }


        public static int SecondPuzzle(string[] input)
        {
            var totalSafeReport = 0;
            foreach (var line in input)
            {
                var levels = line.Split(" ").Select(x => int.Parse(x)).ToList();

                bool isIncreasing = levels[0] < levels[1];
                bool isSafe = true;
                bool alreadyTolerated = false;

                for (int index = 0; index < levels.Count - 1; index++)
                {
                    int currentLevel = levels[index];

                    bool beyondLimit = Math.Abs(levels[index + 1] - currentLevel) > 3;

                    if (isIncreasing && currentLevel >= levels[index + 1] || beyondLimit)
                    {
                        if (!alreadyTolerated && beyondLimit)
                        {
                            //levels(index + 1);  // Recursion instead
                            index--;
                            continue;
                        }

                        isSafe = false;
                        break;
                    }

                    if (!isIncreasing && currentLevel <= levels[index + 1] || beyondLimit)
                    {
                        if (!alreadyTolerated && beyondLimit)
                        {
                            levels.Remove(index + 1);
                            index--;
                            continue;
                        }

                        isSafe = false;
                        break;
                    }
                }

                if (isSafe)
                    totalSafeReport += 1;
            }

            return totalSafeReport;
        }
    }
}
