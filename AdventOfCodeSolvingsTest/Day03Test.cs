using AdventOfCodeSolvings;
using NUnit.Framework;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace AdventOfCodeSolvingsTest
{
    class Day03Test
    {
        [Test]
        public void RunPartA_TestChain()
        {

            var sut = new Day03();
            var result = sut.RunPartA(new List<string>() { "#1 @ 1,3: 4x4", "#2 @ 3,1: 4x4", "#3 @ 5,5: 2x2"});

            Assert.AreEqual(4, result);
        }

        [Test]
        public void RunPartA_FileExample()
        {

            var sut = new Day03();
            var list = FileLoader.LoadLinesFromFile("../../../../Data/data_day03.txt");
            var result = sut.RunPartA(list);

            System.Console.WriteLine(result);

            // 1736845 at 17:34 wrong too high
            // 118840 , wrong day started... Started with day 02... so correct in 23:06
        }

        [Test]
        public void RunPartB_RunPartB()
        {

            var sut = new Day03();
            var result = sut.RunPartB(new List<string>() { "#1 @ 1,3: 4x4", "#2 @ 3,1: 4x4", "#3 @ 5,5: 2x2" });

            Assert.AreEqual(3, result);
        }

        [Test]
        public void RunPartB_RunFromFile()
        {

            var sut = new Day03();
            var list = FileLoader.LoadLinesFromFile("../../../../Data/data_day03.txt");
            var result = sut.RunPartB(list);

            System.Console.WriteLine(result);

            // 919 in additional 16:00 min, but I am not pleased with the allocation of 1.000.000 Elements and therefore a list
            // more objectorientated: parse the object and look for each object if it intersects with each other
        }
    }
}
