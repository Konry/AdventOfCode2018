using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;


namespace AdventOfCodeSolvings
{


    public class Day12 : DayInterface<long, int>
    {
        public long Interations;

        public long RunPartA(List<string> input)
        {
            List<Rule> rules = new List<Rule>();
            List<char> initialState = null;
            
            foreach(var item in input)
            {
                if(item == "")
                {
                    continue;
                }
                if (initialState == null)
                {
                    initialState = new List<char>(item.Split(' ')[2].ToCharArray());
                } else
                {
                    var newRule = new Rule(item.Split(' ')[2].ToCharArray()[0], item.Split(' ')[0].ToCharArray());
                    rules.Add(newRule);
                }
            }


            char[] state = new char[initialState.Count + 8];
            initialState.CopyTo(state, 4);
            int plants = 0;
            for (var i = 0; i < state.Length; i++)
            {
                if (state[i] == '#')
                {
                    plants++;
                }
                else
                {
                    state[i] = '.';
                }
            }
            var plantNumber = 0;
            int startIndex = 4;
            int diffCounter = 0;
            int diff = 0;
            for(int i = 0; i < Interations; i++)
            {
                if (i % 10000 == 0)
                {
                    Debug.WriteLine(i);
                }
                List<char> result = new List<char>(state.Length);
                result.Add('.');
                result.Add('.');
                int min = 4, max = state.Length - 4;

                for(int j = 0; j < state.Length - 4; j++)
                {
                    var toCheck = state.Skip(j).Take(5).ToArray();

                    var rule = rules.FindAll(x => x.RuleSet.SequenceEqual(toCheck));

                    if(rule.Count > 1)
                    {
                        Console.WriteLine("unable to check");
                    }
                    else
                    {
                        if (rule.Count == 1 && rule[0].grow)
                        {
                            min = Math.Min(min, j + 2 );
                            max = Math.Max(max, j + 2);
                            result.Add('#');
                            plants++;
                        }
                        else
                        {
                            result.Add('.');
                        }
                    }
                }
                result.Add('.');
                result.Add('.');
                var addMin = 4 - min;
                var addMax = max - (state.Length - 4);
                if (min < 4 || max > state.Length - 4)
                {
                    var newLength = (state.Length + addMin + addMax);
                    state = new char[newLength];
                }

                for (var ind = 0; ind < state.Length; ind++)
                {
                    state[ind] = '.';
                }
                startIndex += addMin;
                result.CopyTo(state, 0 + addMin);

                var oldPlantNumber = plantNumber;
                plantNumber = 0;
                for (int index = 0; index < state.Length; index++)
                {
                    if (state[index] == '#')
                        plantNumber += index - startIndex;
                }
                var oldDiff = diff;
                diff = (plantNumber - oldPlantNumber);
                if (oldDiff - diff == 0)
                {
                    diffCounter++;
                }
                else
                {
                    diffCounter = 0;
                }
                if (diffCounter > 100)
                {
                    return plantNumber + (Interations - i - 1) * diff;
                }

            }

            for(int i = 0; i < state.Length; i++)
            {
                if(state[i] == '#')
                    plantNumber += i - startIndex;
            }

            return plantNumber;
        }

        public int RunPartB(List<string> input)
        {

            return -1;
        }
    }

    public class Rule
    {
        public char[] RuleSet;
        public bool grow;

        public Rule(char growChar, char[] rule)
        {
            RuleSet = rule;

            if (growChar == '#')
            {
                grow = true;
            }
        }
        //public override bool Equals(object obj)
        //{
        //    var castObj = obj as Rule;

        //    if (castObj != null){
        //        //for
        //    }
        //    return base.Equals(obj);
        //}
    }
}
