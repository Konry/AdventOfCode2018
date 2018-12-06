using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace AdventOfCodeSolvings
{

    public class Day05 : DayInterface<int, int>
    {

        public int RunPartA(List<string> input)
        {
            var returnValue = RemoveValues(input[0]);

            return returnValue.Length;
        }

        public int RunPartB(List<string> input)
        {
            var returnValue = CheckSingleValues(input[0]);

            var min = returnValue.Min(x => x.Value);
            foreach ( var item in returnValue)
            {
                if (item.Value == min)
                {
                    Console.WriteLine("Minimum at " + item.Key + " with minimum of " + item.Value);
                }
            }

            return returnValue.Min(x => x.Value);
        }

        private const string pattern = @"([a-z])\1";

        public ConcurrentDictionary<string, int> CheckSingleValues(string input)
        {
            string[] chars = new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", };
            //var list = new Dictionary<string, int>();
            var list = new ConcurrentDictionary<string, int>();
            var listTasks = new List<Task>();
            for (int i = 0; i < 26; i++)
            {
                var index = i;
                var toCheck = Regex.Replace(input, chars[index], String.Empty);
                toCheck = Regex.Replace(toCheck, chars[index].ToUpper(), String.Empty);
                listTasks.Add(Task.Run(() => {
                    list.TryAdd(chars[index], RemoveValues(toCheck).Length);
                }));
            }
            Task.WaitAll(listTasks.ToArray());
            return list;
        }


        public string RemoveValues(string input)
        {
            var output = "";

            var arrayCheck = new List<string> { "aA", "bB", "cC", "dD", "eE", "fF", "gG", "hH",
                "iI", "jJ", "kK", "lL", "mM", "nN", "oO", "pP",
                "qQ", "rR", "sS", "tT", "uU", "vV", "wW", "xX",
                "yY", "zZ", "Aa", "Bb", "Cc", "Dd", "Ee", "Ff",
                "Gg", "Hh", "Ii", "Jj", "Kk", "Ll", "Mm", "Nn",
                "Oo", "Pp", "Qq", "Rr", "Ss", "Tt", "Uu", "Vv",
                "Ww", "Xx", "Yy", "Zz"};

            string pattern = "";
            foreach (var item in arrayCheck)
            {
                if (pattern != "")
                {
                    pattern += "|";
                }
                pattern += item;
            }
    
            var changedExist = true;
            var lengthInput = input.Length;
            while (changedExist)
            {
                input = Regex.Replace(input, pattern, String.Empty);

                Console.WriteLine(input.Length);

                if (lengthInput == input.Length)
                {
                    changedExist = false;
                    break;
                }
                lengthInput = input.Length;
            }
            output = input;
            return output;
        }

        public string StringFormation(string input)
        {
            var i = 0;
            var changesPossible = true;
            bool foundMatch = false;
            var output = "";

            while (changesPossible)
            {
                foundMatch = false;
                var match = Regex.Match(input.ToLowerInvariant(), pattern);
                i++;
                if (!match.Success)
                {
                    output += input;
                    changesPossible = false;
                    break;
                }

                if (input[match.Index] != input[match.Index + 1])
                {
                    foundMatch = true;

                    output += input.Substring(0, match.Index);
                    input = input.Remove(match.Index, 2);
                    if (i % 500 == 0)
                        Console.WriteLine("At index " + match.Index);
                }
                
                if (foundMatch == false){
                    output += input.Substring(0, match.Index + 1);
                    input = input.Remove(0, match.Index + 1);
                }
            
            }

            return output;
        }
    }
}
