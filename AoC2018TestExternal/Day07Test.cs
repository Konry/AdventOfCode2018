﻿using AdventOfCodeSolvings;
using NUnit.Framework;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace AdventOfCodeSolvingsTest
{
    using System.Collections.Generic;
    using System.Linq;

    namespace AdventOfCode
    {
        public class Day07b
        {
            public static string PartOne(string input)
            {
                var dependencies = new List<(string pre, string post)>();

                //input.Lines().ForEach(x => dependencies.Add((x.Words().ElementAt(1), x.Words().ElementAt(7))));

                var allSteps = dependencies.Select(x => x.pre).Concat(dependencies.Select(x => x.post)).Distinct().OrderBy(x => x).ToList();
                var result = string.Empty;

                while (allSteps.Any())
                {
                    var valid = allSteps.Where(s => !dependencies.Any(d => d.post == s)).First();

                    result += valid;

                    allSteps.Remove(valid);
                    dependencies.RemoveAll(d => d.pre == valid);
                }

                return result;
            }

            public static string PartTwo(string input)
            {
                var dependencies = new List<(string pre, string post)>();

                //input.Lines().ForEach(x => dependencies.Add((x.Words().ElementAt(1), x.Words().ElementAt(7))));

                var allSteps = dependencies.Select(x => x.pre).Concat(dependencies.Select(x => x.post)).Distinct().OrderBy(x => x).ToList();
                var workers = new List<int>(5) { 0, 0, 0, 0, 0 };
                var currentSecond = 0;
                var doneList = new List<(string step, int finish)>();

                while (allSteps.Any() || workers.Any(w => w > currentSecond))
                {
                    //doneList.Where(d => d.finish <= currentSecond).ForEach(x => dependencies.RemoveAll(d => d.pre == x.step));
                    doneList.RemoveAll(d => d.finish <= currentSecond);

                    var valid = allSteps.Where(s => !dependencies.Any(d => d.post == s)).ToList();

                    for (var w = 0; w < workers.Count && valid.Any(); w++)
                    {
                        if (workers[w] <= currentSecond)
                        {
                            workers[w] = GetWorkTime(valid.First()) + currentSecond;
                            allSteps.Remove(valid.First());
                            doneList.Add((valid.First(), workers[w]));
                            valid.RemoveAt(0);
                        }
                    }

                    currentSecond++;
                }

                return currentSecond.ToString();
            }

            private static int GetWorkTime(string v)
            {
                return (v[0] - 'A') + 61;
            }
        }
    }
    class Day07Test
    {
        [Test]
        public void RunPartA_TestChain()
        {

            var sut = new Day07();
            var list = FileLoader.LoadLinesFromFile("../../../../../Data/data_day07_test.txt");
            var result = sut.RunPartA(list);

            Assert.AreEqual("CUABDFE", result);
        }

        [Test]
        public void RunPartA_FileExample()
        {

            var sut = new Day07();
            var list = FileLoader.LoadLinesFromFile("../../../../../Data/data_day07.txt");
            var result = sut.RunPartA(list);

            System.Console.WriteLine(result);

        }

        public static string PartOne(string input)
        {
            var dependencies = new List<(string pre, string post)>();

            //input.Lines().ForEach(x => dependencies.Add((x.Words().ElementAt(1), x.Words().ElementAt(7))));

            var allSteps = dependencies.Select(x => x.pre).Concat(dependencies.Select(x => x.post)).Distinct().OrderBy(x => x).ToList();
            var result = string.Empty;

            while (allSteps.Any())
            {
                var valid = allSteps.Where(s => !dependencies.Any(d => d.post == s)).First();

                result += valid;

                allSteps.Remove(valid);
                dependencies.RemoveAll(d => d.pre == valid);
            }

            return result;
        }

        [Test]
        public void RunPartB_TestChain()
        {

            var sut = new Day07();
            var list = FileLoader.LoadLinesFromFile("../../../../../Data/data_day07.txt");
            var result = sut.RunPartB(list);

            Assert.AreEqual(3, result);
        }

        [Test]
        public void RunPartB_RunFromFile()
        {

            var sut = new Day07();
            var list = FileLoader.LoadLinesFromFile("../../../../../Data/data_day07.txt");
            var result = sut.RunPartB(list);

            System.Console.WriteLine(result);
        }
    }
}
