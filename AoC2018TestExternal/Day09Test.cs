using AdventOfCodeSolvings;
using NUnit.Framework;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace AdventOfCodeSolvingsTest
{
    class Day09Test
    {
        [Test]
        public void RunPartA_TestChain()
        {

            var sut = new Day09();
            var result = sut.RunPartA(new List<string>() { "9 players; last marble is worth 25 points" });

            Assert.AreEqual(32, result);
        }
        [Test]
        public void RunPartA_TestChain_10()
        {

            var sut = new Day09();
            var result = sut.RunPartA(new List<string>() { "10 players; last marble is worth 1618 points" });

            Assert.AreEqual(8317, result);
        }
        [Test]
        public void ModuloTest()
        {
            var sut = new Day09();
            Assert.AreEqual(5, sut.mod(-2, 7));
            Assert.AreEqual(true, 23 % 23 == 0);
        }
        [Test]
        public void RunPartA_TestChain_13()
        {

            var sut = new Day09();
            var result = sut.RunPartA(new List<string>() { "13 players; last marble is worth 7999 points" });

            Assert.AreEqual(146373, result);
        }
        [Test]
        public void RunPartA_TestChain_17()
        {

            var sut = new Day09();
            var result = sut.RunPartA(new List<string>() { "17 players; last marble is worth 1104 points" });

            Assert.AreEqual(2764, result);
        }
        [Test]
        public void RunPartA_TestChain_21()
        {

            var sut = new Day09();
            var result = sut.RunPartA(new List<string>() { "21 players; last marble is worth 6111 points" });

            Assert.AreEqual(54718, result);
        }
        [Test]
        public void RunPartA_TestChain_30()
        {

            var sut = new Day09();
            var result = sut.RunPartA(new List<string>() { "30 players; last marble is worth 5807 points" });

            Assert.AreEqual(37305, result);
        }

        [Test]
        public void ParseInformations_test()
        {

            var sut = new Day09();
            var res = sut.ParseInformations("476 players; last marble is worth 71431 points");

            Assert.AreEqual(476, res[0]);
            Assert.AreEqual(71431, res[1]);
        }

        [Test]
        public void RunPartA_FileExample()
        {

            var sut = new Day09();
            var result = sut.RunPartA(new List<string>() { "476 players; last marble is worth 71431 points" });

            System.Console.WriteLine(result);
            // 368161
            // 384205 after 1:43:15 h...

        }


        [Test]
        public void RunPartB_FileExample()
        {

            var sut = new Day09();
            var result = sut.RunPartA(new List<string>() { "476 players; last marble is worth 7143100 points" });

            System.Console.WriteLine(result);
            // 368161
            // 384205 after 1:43:15 h...

        }

        [Test]
        public void Other()
        {
            OtherClassDay09 oth = new OtherClassDay09();

            System.Console.WriteLine(oth.run());
        }

        [Test]
        public void RunPartB_TestChain()
        {

            var sut = new Day09();
            var result = sut.RunPartB(new List<string>() { "2 3 0 3 10 11 12 1 1 0 1 99 2 1 1 2" });

            Assert.AreEqual(66, result);
        }

        [Test]
        public void RunPartB_RunFromFile()
        {

            var sut = new Day09();
            var list = FileLoader.LoadLinesFromFile("../../../../../Data/data_day09.txt");
            var result = sut.RunPartB(list);

            System.Console.WriteLine(result);

            // 23636 in additional 14:06
        }
    }

    class OtherClassDay09
    {
        static int players = 476;
        static int marbles = 71431;

        static long[] scores = new long[players];
        static LinkedList<int> placed = new LinkedList<int>();
        static LinkedListNode<int> current = placed.AddFirst(0);

        static void next()
        {
            current = current.Next ?? placed.First;
        }
        static void previous()
        {
            current = current.Previous ?? placed.Last;
        }

        public long run()
        {
            for (int m = 1; m <= marbles; m++)
            {
                if (((m) % 23) == 0)
                {
                    previous(); previous(); previous(); previous();
                    previous(); previous(); previous();

                    var j = m % players;
                    scores[j] += m + current.Value;

                    var tmp = current;
                    next();
                    placed.Remove(tmp);
                }
                else
                {
                    next();
                    current = placed.AddAfter(current, m);
                }
            }
            return scores.Max(x => x);
        }
    }
}
