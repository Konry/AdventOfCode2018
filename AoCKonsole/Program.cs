using AdventOfCodeSolvings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoCKonsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var sut = new Day05();
            var list = FileLoader.LoadLinesFromFile("../../../../../Data/data_day05.txt");
            var result = sut.RunPartB(list);
        }
    }
}
