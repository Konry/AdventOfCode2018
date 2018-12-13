using AdventOfCodeSolvings;
using NUnit.Framework;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace AdventOfCodeSolvingsTest
{
    class Day13Test
    {
        [Test]
        public void RunPartA_TestChain()
        {

            var sut = new Day13();
            var list = FileLoader.LoadLinesFromFile("../../../../../Data/data_day13_test.txt");
            var result = sut.RunPartA(list);

            Assert.AreEqual(325, result);
        }


        [Test]
        public void RunPartA_FileExample()
        {

            var sut = new Day13();
            var list = FileLoader.LoadLinesFromFile("../../../../../Data/data_day13.txt");
            var result = sut.RunPartA(list);

            System.Console.WriteLine(result);
            // 718 Wrong, too low
            // 1991 misunderstood the plannumber :/ :O

        }
        

        [Test]
        public void RunPartB_FileExample()
        {

            var sut = new Day13();
            var list = FileLoader.LoadLinesFromFile("../../../../../Data/data_day13.txt");
            var result = sut.RunPartA(list);

            System.Console.WriteLine(result);

            // Gnihihihi 1100000000511
        }
    }

}
