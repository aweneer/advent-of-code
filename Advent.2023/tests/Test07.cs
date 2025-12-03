using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Advent._2023.tests
{
    public class Test07
    {
        [Fact]
        public void TestFirstPuzzleExample()
        {
            var input = File.ReadAllLines(@"..\..\..\examples\example07.txt");
            var expectedResult = 6440;
            var actualResult = Code03.FirstPuzzle(input);

            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void TestFirstPuzzleInput()
        {
            var input = File.ReadAllLines(@"..\..\..\inputs\input07.txt");
            var expectedResult = -1;
            var actualResult = Code03.FirstPuzzle(input);

            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void TestSecondPuzzleExample()
        {
            var input = File.ReadAllLines(@"..\..\..\examples\example07.txt");
            var expectedResult = -1;
            var actualResult = Code03.SecondPuzzle(input);

            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void TestSecondPuzzleInput()
        {
            var input = File.ReadAllLines(@"..\..\..\inputs\input07.txt");
            var expectedResult = -1;
            var actualResult = Code03.SecondPuzzle(input);

            Assert.Equal(expectedResult, actualResult);
        }
    }
}
