using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent._2021
{
    public static class Code12
    {
        public static int FirstPuzzle(string[] input)
        {
            HashSet<Cave> connections = new();
            Dictionary<Cave, bool> caves = new();
            foreach (var line in input)
            {
                Console.WriteLine(line);
                string[] splitLine = line.Split('-');

                Cave cave = new(splitLine[0]);
                Cave otherCave = new(splitLine[1]);
                cave.AddConnection(otherCave);
                otherCave.AddConnection(cave);
                caves.Add(cave, false);
                caves.Add(otherCave, false);
            }

            Console.WriteLine(caves.Count);


            Console.WriteLine();

            return -1;
        }

        public static int SecondPuzzle(string[] input)
        {
            return -1;
        }

        internal class Cave
        {
            public string value;
            public bool isSmallCave = true;
            public bool visited = false;
            public HashSet<Cave> connections = new();

            public Cave(string value)
            {
                this.value = value;
                if (value.Any(char.IsUpper)) { isSmallCave = false; }

            }
            public void AddConnection(Cave connectedCave)
            {
                this.connections.Add(connectedCave);
                connectedCave.connections.Add(this);
            }
        }
    }
}
