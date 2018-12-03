using AdventOfCodeSolvings;
using NUnit.Framework;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace AdventOfCodeSolvingsTest
{
    class Day02Test
    {
        [Test]
        public void RunPartA_TestChain()
        {

            var sut = new Day02();
            var result = sut.RunPartA(new List<string>() { "abcdef", "bababc", "abbcde", "abcccd", "aabcdd", "abcdee", "ababab", });

            Assert.AreEqual(12, result);
        }

        [Test]
        public void RunPartA_FileExample()
        {

            var sut = new Day02();
            var list = FileLoader.LoadLinesFromFile("../../../../Data/data_day2.txt");
            var result = sut.RunPartA(list);

            System.Console.WriteLine(result);

            // 5904 in 36:41, damn regex... 
        }

        [Test]
        public void GetAllStringDifferences_stringDiffersInTwoChars()
        {

            var sut = new Day02();
            var result = sut.GetAllStringDifferences("abcde", "axcye");

            Assert.AreEqual(2, result.Count);
        }

        [Test]
        public void GetAllStringDifferences_StringDiffersInOneChar()
        {

            var sut = new Day02();
            var result = sut.GetAllStringDifferences("fghij", "fguij");

            Assert.AreEqual(1, result.Count);
        }


        [Test]
        public void RunPartB_ListContainsOnePairWhichDiffersInExactlyOne()
        {

            var sut = new Day02();
            var result = sut.RunPartB(new List<string>() { "abcde", "fghij", "klmno", "pqrst", "fguij", "axcye", "wvxyz", });

            Assert.AreEqual("fgij", result);
        }

        [Test]
        public void RunPartB_RunFromFile()
        {

            var sut = new Day02();
            var list = FileLoader.LoadLinesFromFile("../../../../Data/data_day2.txt");
            var result = sut.RunPartB(list);

            System.Console.WriteLine(result);

            // jiwamotgsfrudclzbyzkhlrvp in additional 18:52 
        }
        
        [Test]
        public void Test_Regex()
        {
            var str = "Test";
            
            str = str.ToLowerInvariant();
            var list = str.GroupBy(x => x).First(x => x.Count() == 2).Key;

            Assert.AreEqual('t', list);
        }
    }
}
