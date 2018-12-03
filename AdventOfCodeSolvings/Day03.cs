using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeSolvings
{
    public class Day03 : DayInterface<int, int>
    {
        public int RunPartA(List<string> input)
        {
            int[,] array = new int[1000, 1000];

            /**
             -> x
             # # # # # # # 
             # # # # # # # 
             I
             V Y
             */
            foreach (var item in input)
            {
                var split = item.Split(' ');

                var id = int.Parse(split[0].Remove(0, 1));
                /* split[1] = @ */
                var startSplit = split[2].Replace(":", "").Split(',');
                int startX = int.Parse(startSplit[0]);
                int startY = int.Parse(startSplit[1]);
                var widthSplit = split[3].Split('x');
                int widthX = int.Parse(widthSplit[0]);
                int widthY = int.Parse(widthSplit[1]);

                for(var i = startX; i < startX + widthX; i++)
                {
                    for(var j = startY; j < startY + widthY; j++)
                    {
                        array[i, j]++;
                    }

                }
            }

            int minimumTwoOverlaps = 0;

            for (var i = 0; i < 1000; i++)
            {
                for (var j = 0; j < 1000; j++)
                {
                    if(array[i, j] >= 2)
                    {
                        minimumTwoOverlaps++;
                    }
                }
            }

            return minimumTwoOverlaps;
        }



        public int RunPartB(List<string> input)
        {
            var array = new List<int>[1000, 1000];
            var existingIds = new List<int>();

            /**
                -> x
                # # # # # # # 
                # # # # # # # 
                I
                V Y
                */
            foreach (var item in input)
            {
                var split = item.Split(' ');

                var id = int.Parse(split[0].Remove(0, 1));
                existingIds.Add(id);
                /* split[1] = @ */
                var startSplit = split[2].Replace(":", "").Split(',');
                int startX = int.Parse(startSplit[0]);
                int startY = int.Parse(startSplit[1]);
                var widthSplit = split[3].Split('x');
                int widthX = int.Parse(widthSplit[0]);
                int widthY = int.Parse(widthSplit[1]);

                for (var i = startX; i < startX + widthX; i++)
                {
                    for (var j = startY; j < startY + widthY; j++)
                    {
                        if (array[i, j] == null)
                        {
                            array[i, j] = new List<int>();
                        }
                        array[i, j].Add(id);
                    }

                }
            }

            List<int> coveredIds = new List<int>();
            for (var i = 0; i < 1000; i++)
            {
                for (var j = 0; j < 1000; j++)
                {
                    if (array[i, j] != null && array[i, j].Count >= 2)
                    {
                        foreach (var item in array[i, j])
                        {
                            if (!coveredIds.Contains(item))
                            {
                                coveredIds.Add(item);
                            }
                        }
                    }
                }
            }

            var result = existingIds.Except(coveredIds);

            if (result.ToArray().Length != 1)
            {
                Console.WriteLine("Too much elements containing");
            }
            return result.First();
        }
    }
}
