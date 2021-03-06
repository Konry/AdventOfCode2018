﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AdventOfCodeSolvings
{

    public class Entry
    {
        public DateTime date;

        public string extension;

        public Entry(DateTime dt, string ext)
        {
            date = dt;
            extension = ext;
        } 
    }
    public class Day04 : DayInterface<int, int>
    {
        public Dictionary<int, Guard> guardIndex = new Dictionary<int, Guard>();

        public List<Entry> entries = new List<Entry>();

        public int RunPartA(List<string> input)
        {
            foreach (var guardTimes in input)
            {
                var split = guardTimes.Split(']');
                var time = DateTime.Parse(split[0].Replace("[", ""));
                entries.Add(new Entry(time, split[1]));
            }

            var sortedEntries = entries.OrderBy(x => x.date);

            Guard guard = null;
            foreach (var entry in sortedEntries)
            {
                if (entry.extension.Contains(" begins shift"))
                {
                    var id = int.Parse(entry.extension.Split(' ')[2].Replace("#", ""));
                    if (guardIndex.Count == 0 || !guardIndex.ContainsKey(id))
                    {
                        guard = new Guard(id);
                    }
                    else
                    {
                        guard = guardIndex[id];
                    }

                    var time = entry.date;
                    if (time.Hour == 23)
                    {
                        time = time.AddMinutes(60 - time.Minute);
                    }
                    guard.ActiveMidnightTime.Add(time.Date, new int[60]);
                    var guardActive = guard.ActiveMidnightTime[time.Date];
                    for (int i = 0; i < 60; i++)
                    {
                        guardActive[i] = 0;
                    }
                    if (!guardIndex.ContainsKey(guard.Id))
                        guardIndex.Add(guard.Id, guard);
                }
                else if (entry.extension.Contains("falls asleep"))
                {
                    Console.WriteLine(guard.Id + " change falls asleep " + entry.date.ToLocalTime());
                    var time = entry.date;
                    if (time.Hour == 23)
                    {
                        time = time.AddMinutes(60 - time.Minute);
                    }
                    var guardActive = guard.ActiveMidnightTime[time.Date];
                    for (int i = entry.date.Minute; i < 60; i++)
                    {
                        guardActive[i] = 1;
                    }
                }
                else if (entry.extension.Contains("wakes up"))
                {
                    Console.WriteLine(guard.Id + " change wakes up " + entry.date.ToLocalTime());
                    var time = entry.date;
                    if (time.Hour == 23)
                    {
                        time = time.AddMinutes(60 - time.Minute);
                    }
                    var guardActive = guard.ActiveMidnightTime[time.Date];

                    for (int i = entry.date.Minute; i < 60; i++)
                    {
                        guardActive[i] = 0;
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
                    for (var i = 0; i < overlap.Length; i++)
                    {
                        overlap[i] += timeslot[i];
                    }
                    //overlap = overlap.Union(timeslot).ToArray();
                    //Array.Copy(timeslot, overlap, overlap.Length);
                    //overlap = overlap.Intersect(timeslot).ToArray();
                    sum += timeslot.Sum();
                }
                if (sum > maxTimeAsleep)
                {
                    maxTimeAsleep = sum;
                    idGuard = guarding.Key;
                    var max = overlap.Max();
                    for(var i = 0; i < overlap.Length; i++)
                    {
                        if (overlap[i] == max)
                        {
                            bestMinute = i;
                        } 
                    }
                }
            }
            
            return idGuard * bestMinute;
        }

        

        public int RunPartB(List<string> input)
        {

            foreach (var guardTimes in input)
            {
                var split = guardTimes.Split(']');
                var time = DateTime.Parse(split[0].Replace("[", ""));
                entries.Add(new Entry(time, split[1]));
            }

            var sortedEntries = entries.OrderBy(x => x.date);

            Guard guard = null;
            foreach (var entry in sortedEntries)
            {
                if (entry.extension.Contains(" begins shift"))
                {
                    var id = int.Parse(entry.extension.Split(' ')[2].Replace("#", ""));
                    if (guardIndex.Count == 0 || !guardIndex.ContainsKey(id))
                    {
                        guard = new Guard(id);
                    }
                    else
                    {
                        guard = guardIndex[id];
                    }

                    var time = entry.date;
                    if (time.Hour == 23)
                    {
                        time = time.AddMinutes(60 - time.Minute);
                    }
                    guard.ActiveMidnightTime.Add(time.Date, new int[60]);
                    var guardActive = guard.ActiveMidnightTime[time.Date];
                    for (int i = 0; i < 60; i++)
                    {
                        guardActive[i] = 0;
                    }
                    if (!guardIndex.ContainsKey(guard.Id))
                        guardIndex.Add(guard.Id, guard);
                }
                else if (entry.extension.Contains("falls asleep"))
                {
                    Console.WriteLine(guard.Id + " change falls asleep " + entry.date.ToLocalTime());
                    var time = entry.date;
                    if (time.Hour == 23)
                    {
                        time = time.AddMinutes(60 - time.Minute);
                    }
                    var guardActive = guard.ActiveMidnightTime[time.Date];
                    for (int i = entry.date.Minute; i < 60; i++)
                    {
                        guardActive[i] = 1;
                    }
                }
                else if (entry.extension.Contains("wakes up"))
                {
                    Console.WriteLine(guard.Id + " change wakes up " + entry.date.ToLocalTime());
                    var time = entry.date;
                    if (time.Hour == 23)
                    {
                        time = time.AddMinutes(60 - time.Minute);
                    }
                    var guardActive = guard.ActiveMidnightTime[time.Date];

                    for (int i = entry.date.Minute; i < 60; i++)
                    {
                        guardActive[i] = 0;
                    }
                }
            }

            int idGuard = 0;
            int maxTimeSlotAsleep = 0;
            int bestMinute = 0;
            int[] globalOverlap = new int[60];
            foreach (var guarding in guardIndex)
            {
                int max = 0;
                int[] overlap = new int[60];
                foreach (var timeslot in guarding.Value.ActiveMidnightTime.Values)
                {
                    for (var i = 0; i < overlap.Length; i++)
                    {
                        overlap[i] += timeslot[i];
                    }
                    //overlap = overlap.Union(timeslot).ToArray();
                    //Array.Copy(timeslot, overlap, overlap.Length);
                    //overlap = overlap.Intersect(timeslot).ToArray();
                }
                max = overlap.Max();

                if (max > maxTimeSlotAsleep)
                {
                    maxTimeSlotAsleep = max;
                    idGuard = guarding.Key;
                    for (var i = 0; i < overlap.Length; i++)
                    {
                        if (overlap[i] == max)
                        {
                            bestMinute = i;
                        }
                    }
                }
            }

            return idGuard * bestMinute;
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
