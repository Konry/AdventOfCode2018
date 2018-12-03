using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeSolvings
{
    public class Day1 : DayInterface<int, int>
    {
        public int RunPartA(List<string> input)
        {
            var res = 0;
            foreach(var item in input)
            {
                var value = int.Parse(item);
                res += value;
            }
            return res;
        }

        public int RunPartB(List<string> input)
        {
            HashSet<int> hashSet = new HashSet<int>();

            var res = 0;
            hashSet.Add(0);

            var notFound = true;
            while (notFound)
            {
                foreach (var item in input)
                {
                    var value = int.Parse(item);
                    res += value;
                    if (hashSet.Contains(res))
                    {
                        return res;
                    }
                    hashSet.Add(res);
                }
            }
            return -1;
        }
    }

}
