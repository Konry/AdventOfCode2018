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
            var sut = new Day12();
            var list = FileLoader.LoadLinesFromFile("../../../../../Data/data_day12.txt");
            sut.Interations = 50000;
            var result = sut.RunPartA(list);
        }
    }
}
