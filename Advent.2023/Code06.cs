using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Advent._2023
{
    public static class Code06
    {
        public static double FirstPuzzle(string[] input)
        {
            double result = 1;

            var raceTimes = Regex.Matches(input[0], @"\d+").Cast<Match>().Select(m => long.Parse(m.Value)).ToArray();
            var distances = Regex.Matches(input[1], @"\d+").Cast<Match>().Select(m => long.Parse(m.Value)).ToArray();

            for (int raceNumber = 0; raceNumber < raceTimes.Length; raceNumber++)
            {
                var recordBeaten = YieldWhenRecordBeaten(raceTimes, distances, raceNumber);              
                result *= recordBeaten.Count(isBeaten => isBeaten == true);
            }

            return result;
        }

        public static double SecondPuzzle(string[] input)
        {
            double result = 1;

            var raceTime = long.Parse(Regex.Match(input[0].Replace(" ", ""), @"\d+").Value);
            var distance = long.Parse(Regex.Match(input[1].Replace(" ", ""), @"\d+").Value);

            var recordBeaten = YieldWhenRecordBeaten(new[] { raceTime }, new[] { distance }, 0);
            result *= recordBeaten.Count(isBeaten => isBeaten == true);

            return result;
        }

        public static IEnumerable<bool> YieldWhenRecordBeaten(long[] raceTimes, long[] distances, int raceNumber)
        {
            for (int millisecond = 0; millisecond < raceTimes[raceNumber]; millisecond++)
            {
                var distanceRaced = millisecond * (raceTimes[raceNumber] - millisecond);
                if (distanceRaced > distances[raceNumber])
                    yield return true;
            }
        }
    }
}
