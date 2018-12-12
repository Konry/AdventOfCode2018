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
        public void CheckAmount()
        {
            var str = new string[] { " 0: ...#..#.#..##......###...###........... 1: ...#...#....#.....#..#..#..#........... 2: ...##..##...##....#..#..#..##.......... 3: ..#.#...#..#.#....#..#..#...#.......... 4: ...#.#..#...#.#...#..#..##..##......... 5: ....#...##...#.#..#..#...#...#......... 6: ....##.#.#....#...#..##..##..##........ 7: ...#..###.#...##..#...#...#...#........ 8: ...#....##.#.#.#..##..##..##..##....... 9: ...##..#..#####....#...#...#...#.......10: ..#.#..#...#.##....##..##..##..##......11: ...#...##...#.#...#.#...#...#...#......12: ...##.#.#....#.#...#.#..##..##..##.....13: ..#..###.#....#.#...#....#...#...#.....14: ..#....##.#....#.#..##...##..##..##....15: ..##..#..#.#....#....#..#.#...#...#....16: .#.#..#...#.#...##...#...#.#..##..##...17: ..#...##...#.#.#.#...##...#....#...#...18: ..##.#.#....#####.#.#.#...##...##..##..19: .#..###.#..#.#.#######.#.#.#..#.#...#..20: .#....##....#####...#######....#.#..##."};
            var strArr = str[0].ToCharArray();
            var count = 0;
            for(int i = 0; i < strArr.Length; i++)
            {
                if(strArr[i] == '#')
                {
                    count++;
                }
            }
            Assert.AreEqual(325, count);
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
        public void RunPartB_FileExample()
        {

            var sut = new Day12();
            var list = FileLoader.LoadLinesFromFile("../../../../../Data/data_day12.txt");
            sut.Interations = 50000000000;
            var result = sut.RunPartA(list);

            System.Console.WriteLine(result);

        }

        [Test]
        public void RunPartB_TestChain()
        {

            var sut = new Day12();
            var list = FileLoader.LoadLinesFromFile("../../../../../Data/data_day12_test.txt");
            var result = sut.RunPartA(list);

            //Assert.AreEqual(66, result);
        }
    }

}
