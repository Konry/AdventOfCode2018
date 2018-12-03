using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeSolvings
{
    public class Day02 : DayInterface<int, string>
    {
        public int RunPartA(List<string> input)
        {
            var occurence2ExactChars = 0;
            var occurence3ExactChars = 0;
            foreach(var inputItem in input)
            {
                if (ContainsExactXTimesChar(inputItem, 2)) occurence2ExactChars ++;
                if (ContainsExactXTimesChar(inputItem, 3)) occurence3ExactChars++;
            }
            return occurence2ExactChars * occurence3ExactChars;
        }

        public bool ContainsExactXTimesChar(string input, int count)
        {
            try
            {
                var result = input.GroupBy(x => x).First(x => x.Count() == count).Key;
                if(result != 0 )
                {
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
            return false;
        }

        public struct CompareItem
        {
            public int index;
            public char charValue;
        }

        public List<CompareItem> GetAllStringDifferences(string baseString, string toCompareString)
        {
            var diffList = new List<CompareItem>();

            for(int i = 0; i < baseString.Length; i++)
            {
                if(toCompareString.Length <= i)
                {
                    break;
                }

                if(baseString[i] != toCompareString[i])
                {
                    diffList.Add(new CompareItem
                    {
                        index = i,
                        charValue = baseString[i]
                    });
                }
                if (diffList.Count > 1)
                {
                    break;
                }
            }
            return diffList;
        }

        public string RunPartB(List<string> input)
        {
            foreach(var item in input)
            {
                foreach(var toCompareItem in input)
                {
                    var result = GetAllStringDifferences(item, toCompareItem);
                    if(result.Count == 1)
                    {
                        return item.Remove(result[0].index, 1);
                    }
                }
            }

            return "";
        }
    }
}
