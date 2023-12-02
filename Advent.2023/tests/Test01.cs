using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Advent._2023.tests
{
    public class Test01
    {
        [Fact]
        public void TestFirstPuzzleExample()
        {
            var input = File.ReadAllLines(@"..\..\..\examples\example01.txt");
            var expectedResult = 142;
            var actualResult = Code01.FirstPuzzle(input);

            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void TestFirstPuzzle()
        {
            var input = File.ReadAllLines(@"..\..\..\inputs\input01.txt");
            var expectedResult = 55488;
            var actualResult = Code01.FirstPuzzle(input);

            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void TestSecondPuzzleExample()
        {
            var input = File.ReadAllLines(@"..\..\..\examples\example01b.txt");
            var expectedResult = 281;
            var actualResult = Code01.SecondPuzzle(input);

            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void TestSecondPuzzle()
        {
            var input = File.ReadAllLines(@"..\..\..\inputs\input01.txt");
            var expectedResult = 55614;
            var actualResult = Code01.SecondPuzzle(input);

            Assert.Equal(expectedResult, actualResult);
        }
    }
}
