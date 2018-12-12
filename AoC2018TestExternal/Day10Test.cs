using AdventOfCodeSolvings;
using NUnit.Framework;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace AdventOfCodeSolvingsTest
{
    class Day10Test
    {
        [Test]
        public void RunPartA_TestChain()
        {

            var sut = new Day10();
            var list = FileLoader.LoadLinesFromFile("../../../../../Data/data_day10_test.txt");
            var result = sut.RunPartA(list);

            //Assert.AreEqual(32, result);
        }

        [Test]
        public void RunPartA_FileExample()
        {

            var sut = new Day10();
            var list = FileLoader.LoadLinesFromFile("../../../../../Data/data_day10.txt");
            var result = sut.RunPartA(list);

            System.Console.WriteLine(result);
            // 368161
            // 384205 after 1:43:15 h...

        }


        [Test]
        public void RunPartB_FileExample()
        {

            var sut = new Day10();
            var list = FileLoader.LoadLinesFromFile("../../../../../Data/data_day10_test.txt");
            var result = sut.RunPartA(list);

            System.Console.WriteLine(result);
            // 368161
            // 384205 after 1:43:15 h...

        }

        [Test]
        public void RunPartB_TestChain()
        {

            var sut = new Day10();
            var list = FileLoader.LoadLinesFromFile("../../../../../Data/data_day10_test.txt");
            var result = sut.RunPartA(list);

            //Assert.AreEqual(66, result);
        }
    }

}
