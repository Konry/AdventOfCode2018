using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace AdventOfCodeSolvings
{

    public class ExpandingItem
    {
        public int[] Center;
        public List<int[]> PointsCorresponding;

        public ExpandingItem(int[] center)
        {
            Center = center;
        }

        public int CalcManhattenDistanz(int[] pointToCheck)
        {
            return Math.Abs(pointToCheck[0] - Center[0]) + Math.Abs(pointToCheck[1] - Center[1]);
        }
    }

    public class Day06 : DayInterface<int, int>
    {
        
        public int RunPartA(List<string> input)
        {
            int[] centerOfInput = { 0, 0 };
            List<ExpandingItem> expandingItems = new List<ExpandingItem>();

            foreach(var inputString in input)
            {
                var split = inputString.Split(',');
                var x = int.Parse(split[0]);
                var y = int.Parse(split[1]);
                var exp = new ExpandingItem(new int[] { x, y });
            }

            RunExpanding(centerOfInput, expandingItems);
            return 1;
        }

        private void RunExpanding(int[] centerOfInput, List<ExpandingItem> expandingItems)
        {
            for(int i = 0; i < 1000; i++)
            {
                int[] pointToCheck = centerOfInput;
            }
        }

        public int RunPartB(List<string> input)
        {
            return 1;
        }
    }
}
