using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace AdventOfCodeSolvings
{
    

    public class Day09 : DayInterface<long, int>
    {

        static LinkedList<long> marbellGame = new LinkedList<long>();
        static void next()
        {
            current = current.Next ?? marbellGame.First;
        }
        static void previous()
        {
            current = current.Previous ?? marbellGame.Last;
        }

        static LinkedListNode<long> current = marbellGame.AddFirst(0);

        public long RunPartA(List<string> input)
        {
            var intInput = ParseInformations(input[0]);

            var marbelsRolling = true;

            Dictionary<int, long> playerScore = new Dictionary<int, long>();
            for (var i = 1; i <= intInput[0]; i++)
            {
                playerScore.Add(i, 0);
            }

            long currentMarbleValue = 1;

            while (marbelsRolling)
            {
                for(var playerId = 1; playerId <= playerScore.Count; playerId ++)
                {
                    if(currentMarbleValue > intInput[1])
                    {
                        return playerScore.Max(x => x.Value);
                    }
                    if (currentMarbleValue % 23 == 0)
                    {
                        previous();
                        previous();
                        previous();
                        previous();
                        previous();
                        previous();
                        previous();

                        playerScore[playerId] += currentMarbleValue + current.Value;

                        var tmp = current;
                        next();
                        marbellGame.Remove(tmp);
                        currentMarbleValue++;
                    }
                    else
                    {
                        next();
                        current = marbellGame.AddAfter(current, currentMarbleValue++);
                    }
                }
            }
            return -1;
        }

        public int mod(int k, int n) {
            return ((k %= n) < 0) ? k + n : k;
        }


        public int[] ParseInformations(string s)
        {
            var str = s.Replace(" players; last marble is worth ", ",").Replace(" points", string.Empty);
            var split = str.Split(',');
            return new int[] { int.Parse(split[0]), int.Parse(split[1]) };
        }

        public int RunPartB(List<string> input)
        {

            return -1;
        }

        public class DoubleLink
        {
            public int Title { get; set; }
            public DoubleLink PreviousLink { get; set; }
            public DoubleLink NextLink { get; set; }

            public DoubleLink(int title)
            {
                Title = title;
            }
        }
    }
}
