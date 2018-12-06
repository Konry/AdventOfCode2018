using AdventOfCodeSolvings;
using NUnit.Framework;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System;

namespace AdventOfCodeSolvingsTest
{
    class Day04Test
    {
        [Test]
        public void RunPartA_TestChain()
        {

            var sut = new Day04();
            var list = FileLoader.LoadLinesFromFile("../../../../../Data/data_day04_test.txt");
            var result = sut.RunPartA(list);

            Assert.AreEqual(240, result);
        }

        [Test]
        public void RunPartA_FileExample()
        {

            var sut = new Day04();
            var list = FileLoader.LoadLinesFromFile("../../../../../Data/data_day04.txt");
            var result = sut.RunPartA(list);

            System.Console.WriteLine(result);

            // 1736845 at 17:34 wrong too high
            // 118840 , wrong day started... Started with day 02... so correct in 23:06
        }

        [Test]
        public void RunPartB_RunFromFile()
        {

            var sut = new Day04();
            var list = FileLoader.LoadLinesFromFile("../../../../../Data/data_day04.txt");
            var result = sut.RunPartB(list);

            System.Console.WriteLine(result);

            // 919 in additional 16:00 min, but I am not pleased with the allocation of 1.000.000 Elements and therefore a list
            // more objectorientated: parse the object and look for each object if it intersects with each other
        }

        [Test]
        public void DateTimeParseTest()
        {
            var date = DateTime.Parse("1518-11-01 05:26");

            Assert.AreEqual(1518, date.Year);
            Assert.AreEqual(11, date.Month);
            Assert.AreEqual(01, date.Day);
            Assert.AreEqual(5, date.Hour);
            Assert.AreEqual(26, date.Minute);
        }
    }
}
