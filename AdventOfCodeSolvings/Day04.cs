using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeSolvings
{
    public class Day04 : DayInterface<int, int>
    {
        public Dictionary<int, Guard> guardIndex = new Dictionary<int, Guard>();
        public int RunPartA(List<string> input)
        {
            Guard guard = null ;
            foreach (var guardTimes in input)
            {
                var split = guardTimes.Split(']');
                var time = DateTime.Parse(split[0].Replace("[", ""));

                if (split[1].Contains(" begins shift"))
                {
                    var id = int.Parse(split[1].Split(' ')[2].Replace("#", ""));
                    guard = new Guard(id);
                    var dat = time.Date;
                    guard.ActiveMidnightTime.Add(time.Date, new int[60]);
                    var guardActive = guard.ActiveMidnightTime[time.Date];
                    for (int i = 0; i < 60; i++)
                    {
                        guardActive[i] = 1;
                    }
                }
                else if(split[1].Contains("falls asleep"))
                {
                    var guardActive = guard.ActiveMidnightTime[time.Date];
                    for (int i = time.Minute; i < 60; i++)
                    {
                        guardActive[i] = 0;
                    }
                }
                else if (split[1].Contains("wakes up"))
                {
                    var guardActive = guard.ActiveMidnightTime[time.Date];

                    for (int i = time.Minute; i < 60; i++)
                    {
                        guardActive[i] = 1;
                    }
                }
            }

            int idGuard = 0;
            int maxTimeAsleep = 0;
            int bestMinute = 0;
            int[] globalOverlap = new int[60];
            foreach (var guarding in guardIndex)
            {
                int sum = 0;
                int[] overlap = new int[60];
                foreach (var timeslot in guarding.Value.ActiveMidnightTime.Values)
                {
                    overlap = overlap.Intersect(timeslot).ToArray();
                    sum += timeslot.Sum();
                }
                if (sum > maxTimeAsleep)
                {
                    maxTimeAsleep = sum;
                    idGuard = guarding.Key;
                    bestMinute = overlap.Max();
                }
            }
            
            return idGuard * bestMinute;
        }

        

        public int RunPartB(List<string> input)
        {

            return -1;
        }

        public class Guard
        {
            public Dictionary<DateTime, int[]> ActiveMidnightTime = new Dictionary<DateTime, int[]>();

            public int Id = -1;
            public Guard(int id)
            {
                Id = id;
            }
        }
    }
}
