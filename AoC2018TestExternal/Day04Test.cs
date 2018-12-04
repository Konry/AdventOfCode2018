using AdventOfCodeSolvings;
using NUnit.Framework;
using System.Collections.Generic;
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

            // 12504 after long time 2h stucked :(
        }

        [Test]
        public void RunPartB_TestChain()
        {
            var sut = new Day04();
            var list = FileLoader.LoadLinesFromFile("../../../../../Data/data_day04_test.txt");
            var result = sut.RunPartB(list);

            Assert.AreEqual(4455, result);
        }

        [Test]
        public void RunPartB_RunFromFile()
        {

            var sut = new Day04();
            var list = FileLoader.LoadLinesFromFile("../../../../../Data/data_day04.txt");
            var result = sut.RunPartB(list);

            System.Console.WriteLine(result);

            // 139543 5min less changes :)
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
