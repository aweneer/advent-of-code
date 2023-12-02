using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Advent._2023.tests
{
    public class Test02
    {
        [Fact]
        public void TestFirstPuzzleExample()
        {
            var input = File.ReadAllLines(@"..\..\..\examples\example02.txt");
            var expectedResult = 8;
            var actualResult = Code02.FirstPuzzle(input);

            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void TestFirstPuzzle()
        {
            var input = File.ReadAllLines(@"..\..\..\inputs\input02.txt");
            var expectedResult = 2439;
            var actualResult = Code02.FirstPuzzle(input);

            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void TestSecondPuzzleExample()
        {
            var input = File.ReadAllLines(@"..\..\..\examples\example02.txt");
            var expectedResult = 2286;
            var actualResult = Code02.SecondPuzzle(input);

            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void TestSecondPuzzle()
        {
            var input = File.ReadAllLines(@"..\..\..\inputs\input02.txt");
            var expectedResult = 63711;
            var actualResult = Code02.SecondPuzzle(input);

            Assert.Equal(expectedResult, actualResult);
        }
    }
}
