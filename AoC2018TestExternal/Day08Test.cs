using AdventOfCodeSolvings;
using NUnit.Framework;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace AdventOfCodeSolvingsTest
{
    class Day08Test
    {
        [Test]
        public void RunPartA_TestChain()
        {

            var sut = new Day08();
            var result = sut.RunPartA(new List<string>() { "2 3 0 3 10 11 12 1 1 0 1 99 2 1 1 2" });

            Assert.AreEqual(138, result);
        }

        [Test]
        public void RunPartA_FileExample()
        {

            var sut = new Day08();
            var list = FileLoader.LoadLinesFromFile("../../../../../Data/data_day08.txt");
            var result = sut.RunPartA(list);

            System.Console.WriteLine(result);
            // 47647 in 37:30

        }

        [Test]
        public void RunPartB_TestChain()
        {

            var sut = new Day08();
            var result = sut.RunPartB(new List<string>() { "2 3 0 3 10 11 12 1 1 0 1 99 2 1 1 2" });

            Assert.AreEqual(66, result);
        }

        [Test]
        public void RunPartB_RunFromFile()
        {

            var sut = new Day08();
            var list = FileLoader.LoadLinesFromFile("../../../../../Data/data_day08.txt");
            var result = sut.RunPartB(list);

            System.Console.WriteLine(result);

            // 23636 in additional 14:06
        }
    }
}
