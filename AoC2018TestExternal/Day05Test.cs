using AdventOfCodeSolvings;
using NUnit.Framework;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System;

namespace AdventOfCodeSolvingsTest
{
    class Day05Test
    {

        [Test]
        [Ignore("Too long")]
        public void RunPartA_FileExample()
        {

            var sut = new Day05();
            var list = FileLoader.LoadLinesFromFile("../../../../../Data/data_day05.txt");
            var result = sut.RunPartA(list);

            System.Console.WriteLine(result);

            // 12476 Fuck off regex... this sucks derb... too high
            // 4511 its fucking annoying, I know what to do but i cant get into regex
            // 10496 rewrite, use manual regex, dunno why this not works 2:12:33 h...
        }


        [Test]
        [Ignore("Too long")]
        public void RunPartB_RunFromFile()
        {

            var sut = new Day05();
            var list = FileLoader.LoadLinesFromFile("../../../../../Data/data_day05.txt");
            var result = sut.RunPartB(list);

            System.Console.WriteLine(result);

            // 5774 Additional 33:44 min... ultra long running, dafuq I'am out...
        }

        [Test]
        public void RunPartA_StringFormation_dabAcCaCBAcCcaDA()
        {

            var sut = new Day05();
            var result = sut.RemoveValues("dabAcCaCBAcCcaDA");

            Assert.AreEqual("dabCBAcaDA", result);
        }

        [Test]
        public void RunPartA_StringFormation_aAa()
        {

            var sut = new Day05();
            var result = sut.RemoveValues("aAa");

            Assert.AreEqual("a", result);
        }

        [Test]
        public void RunPartA_StringFormation_aaAa()
        {

            var sut = new Day05();
            var result = sut.RemoveValues("aaAa");

            Assert.AreEqual("aa", result);
        }

        [Test]
        public void RunPartBA_StringFormation_AAA()
        {

            var sut = new Day05();
            var result = sut.RemoveValues("AAA");

            Assert.AreEqual("AAA", result);
        }


        [Test]
        public void RunPartA_StringFormation_aBb()
        {

            var sut = new Day05();
            var result = sut.RemoveValues("aBb");

            Assert.AreEqual("a", result);
        }


        [Test]
        public void RunPartB_StringFormation_dabAcCaCBAcCcaDA_complete()
        {

            var sut = new Day05();
            var result = sut.RunPartB(new List<string>() { "dabAcCaCBAcCcaDA" });

            Assert.AreEqual(4, result);
        }

        public static void Part1()
        {
            var stack = new Stack<char>();
            var list = FileLoader.LoadLinesFromFile("../../../../../Data/data_day05.txt");
            foreach (var c in list[0])
            {
                if (stack.Count == 0)
                {
                    stack.Push(c);
                }
                else
                {
                    var inStack = stack.Peek();
                    var same = c != inStack && char.ToUpper(c) == char.ToUpper(inStack);
                    if (same)
                    {
                        stack.Pop();
                    }
                    else
                    {
                        stack.Push(c);
                    }
                }
            }

            Console.WriteLine(stack.Count);
        }

        public static void Part2()
        {
            var list = FileLoader.LoadLinesFromFile("../../../../../Data/data_day05.txt");
            var min = int.MaxValue;
            for (var i = 'a'; i < 'z'; i++)
            {
                var s = list[0].Replace(i.ToString(), "").Replace(char.ToUpper(i).ToString(), "");
                var stack = new Stack<char>();
                foreach (var c in s)
                {
                    if (stack.Count == 0)
                    {
                        stack.Push(c);
                    }
                    else
                    {
                        var inStack = stack.Peek();
                        var same = c != inStack && char.ToUpper(c) == char.ToUpper(inStack);
                        if (same)
                        {
                            stack.Pop();
                        }
                        else
                        {
                            stack.Push(c);
                        }
                    }
                }

                if (stack.Count < min)
                {
                    min = stack.Count;
                }
            }

            Console.WriteLine(min);
        }

        [Test]
        public void RunExternalPart1()
        {
            Part1();
        }

        [Test]
        public void RunExternalPart2()
        {
            Part2();
        }


        [Test]
        [Ignore("FUCK")]
        public void RunPartB_StringFormation_dabAcCaCBAcCcaDA()
        {

            var sut = new Day05();
            var result = sut.CheckSingleValues("dabAcCaCBAcCcaDA");

            int i = 0;
            foreach(var item in result)
            {
                if (i == 0)
                {
                    Assert.AreEqual(6, item.Value);
                }
                if (i == 1)
                {
                    Assert.AreEqual(8, item.Value);
                }
                if (i == 2)
                {
                    Assert.AreEqual(4, item.Value);
                }
                if (i == 3)
                {
                    Assert.AreEqual(6, item.Value);
                }
                i++;
            }

            //Assert.AreEqual(8, result[1]);
            //Assert.AreEqual(4, result[2]);
            //Assert.AreEqual(6, result[3]);
        }




        //[Test]
        //public void RunPartB_StringFormation_bbb()
        //{

        //    var sut = new Day05();
        //    var result = sut.StringFormation("trelLis llama webbing dresser swagger");

        //    //Assert.AreEqual("", result);
        //}

    }
}
