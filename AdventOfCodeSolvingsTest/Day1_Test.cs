using AdventOfCodeSolvings;
using NUnit.Framework;
using System.Collections.Generic;

namespace AdventOfCodeSolvingsTest
{
    class Day1_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test_PartA_add_1_1_1()
        {
            var sut = new Day1();
            var list = new List<string>();
            list.Add("+1");
            list.Add("+1");
            list.Add("+1");

            var returnValue = sut.RunPartA(list);

            Assert.AreEqual(3, returnValue);
        }

        [Test]
        public void Test_PartA_add_1_1_minus2()
        {
            var sut = new Day1();
            var list = new List<string>();
            list.Add("+1");
            list.Add("+1");
            list.Add("-2");

            var returnValue = sut.RunPartA(list);

            Assert.AreEqual(0, returnValue);
        }


        [Test]
        public void Test_PartA_minus_1_2_3()
        {
            var sut = new Day1();
            var list = new List<string>();
            list.Add("-1");
            list.Add("-2");
            list.Add("-3");

            var returnValue = sut.RunPartA(list);

            Assert.AreEqual(-6, returnValue);
        }

        [Test]
        public void Test_PartA_Complete()
        {
            var sut = new Day1();
            var list = FileLoader.LoadLinesFromFile("../../../../Data/data_day1_A.txt");

            var returnValue = sut.RunPartA(list);

            System.Console.WriteLine(returnValue);
            // 427 after 17:15 min
        }

        [Test]
        public void Test_PartB_add_1_1()
        {
            var sut = new Day1();
            var list = new List<string>();
            list.Add("+1");
            list.Add("-1");

            var returnValue = sut.RunPartB(list);

            Assert.AreEqual(0, returnValue);
        }

        [Test]
        public void Test_PartB_2ndTest()
        {
            var sut = new Day1();
            var list = new List<string>();
            list.Add("+3");
            list.Add("+3");
            list.Add("+4");
            list.Add("-2");
            list.Add("-4");

            var returnValue = sut.RunPartB(list);

            Assert.AreEqual(10, returnValue);
        }


        [Test]
        public void Test_PartB_3rdTest()
        {
            var sut = new Day1();
            var list = new List<string>();
            list.Add("-6");
            list.Add("+3");
            list.Add("+8");
            list.Add("+5");
            list.Add("-6");

            var returnValue = sut.RunPartB(list);

            Assert.AreEqual(5, returnValue);
        }
        [Test]
        public void Test_PartB_4thTest()
        {
            var sut = new Day1();
            var list = new List<string>();
            list.Add("+7");
            list.Add("+7");
            list.Add("-2");
            list.Add("-7");
            list.Add("-4");

            var returnValue = sut.RunPartB(list);

            Assert.AreEqual(14, returnValue);
        }

        [Test]
        public void Test_PartB_Complete()
        {
            var sut = new Day1();
            var list = FileLoader.LoadLinesFromFile("../../../../Data/data_day1_A.txt");

            var returnValue = sut.RunPartB(list);

            System.Console.WriteLine(returnValue);
            // 341 in additional 9:32
        }
    }
}
