using AdventOfCodeSolvings;
using NUnit.Framework;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace AdventOfCodeSolvingsTest
{
    class Day12Test
    {
        [Test]
        public void RunPartA_TestChain()
        {

            var sut = new Day12();
            var list = FileLoader.LoadLinesFromFile("../../../../../Data/data_day12_test.txt");
            var result = sut.RunPartA(list);

            Assert.AreEqual(325, result);
        }

        [Test]
        public void Check_char()
        {
            var a1 = new char[] {'a', 'b' };
            var a2 = new char[] { 'a', 'b' };
            Assert.AreEqual(a1, a2);
            Assert.AreEqual(true, a1.SequenceEqual(a2));
        }

        [Test]
        public void RunPartA_FileExample()
        {

            var sut = new Day12();
            sut.Interations = 20;
            var list = FileLoader.LoadLinesFromFile("../../../../../Data/data_day12.txt");
            var result = sut.RunPartA(list);

            System.Console.WriteLine(result);
            // 718 Wrong, too low
            // 1991 misunderstood the plannumber :/ :O

        }


        [Test]
        public void RunPartB_FileExample_2000()
        {

            var sut = new Day12();
            var list = FileLoader.LoadLinesFromFile("../../../../../Data/data_day12.txt");
            sut.Interations = 2000;
            var result = sut.RunPartA(list);

            Assert.AreEqual(44511, result);
            System.Console.WriteLine(result);

        }

        [Test]
        public void RunPartB_FileExample()
        {

            var sut = new Day12();
            var list = FileLoader.LoadLinesFromFile("../../../../../Data/data_day12.txt");
            sut.Interations = 50000000000;
            var result = sut.RunPartA(list);

            System.Console.WriteLine(result);

            // Gnihihihi 1100000000511
        }
    }

}
