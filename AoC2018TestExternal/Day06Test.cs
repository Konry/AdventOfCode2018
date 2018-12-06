using AdventOfCodeSolvings;
using NUnit.Framework;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace AdventOfCodeSolvingsTest
{
    class Day06Test
    {
        [Test]
        public void RunPartA_TestChain()
        {

            var sut = new Day06();
            var result = sut.RunPartA(new List<string>() { "#1 @ 1,3: 4x4", "#2 @ 3,1: 4x4", "#3 @ 5,5: 2x2"});

            Assert.AreEqual(4, result);
        }

        [Test]
        public void RunPartA_FileExample()
        {

            var sut = new Day06();
            var list = FileLoader.LoadLinesFromFile("../../../../../Data/data_day03.txt");
            var result = sut.RunPartA(list);

            System.Console.WriteLine(result);

        }

        [Test]
        public void RunPartB_TestChain()
        {

            var sut = new Day06();
            var result = sut.RunPartB(new List<string>() { "#1 @ 1,3: 4x4", "#2 @ 3,1: 4x4", "#3 @ 5,5: 2x2" });

            Assert.AreEqual(3, result);
        }

        [Test]
        public void RunPartB_RunFromFile()
        {

            var sut = new Day06();
            var list = FileLoader.LoadLinesFromFile("../../../../../Data/data_day03.txt");
            var result = sut.RunPartB(list);

            System.Console.WriteLine(result);
        }
    }
}
