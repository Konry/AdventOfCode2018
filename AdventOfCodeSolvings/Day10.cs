using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace AdventOfCodeSolvings
{


    public class Day10 : DayInterface<int, int>
    {


        public int RunPartA(List<string> input)
        {
            ParseInformations(input, out List<Point> points);
            int expansion = int.MaxValue;

            int seconds = 0;
            while (true)
            {
                foreach(var point in points)
                {
                    point.AddVelocity();
                }
                int xMin = int.MaxValue, xMax = int.MinValue, yMin = int.MaxValue, yMax = int.MinValue;
                foreach (var point in points)
                {
                    xMin = Math.Min(xMin, point.Postion.x);
                    xMax = Math.Max(xMax, point.Postion.x);
                    yMin = Math.Min(yMin, point.Postion.y);
                    yMax = Math.Max(yMax, point.Postion.y);
                }
                var currentExpansion = (xMax - xMin) + (yMax - yMin);
                if (expansion < currentExpansion)
                {

                    foreach (var point in points)
                    {
                        point.RevertVelocity();
                    }
                    Show(points);
                    Console.WriteLine("seconds " + seconds);
                    return 0;
                }
                expansion = currentExpansion;
                seconds++;
            }
        }

        private void Show(List<Point> points)
        {
            int xMin = int.MaxValue, xMax = int.MinValue, yMin = int.MaxValue, yMax = int.MinValue;
            foreach (var point in points)
            {
                xMin = Math.Min(xMin, point.Postion.x);
                xMax = Math.Max(xMax, point.Postion.x);
                yMin = Math.Min(yMin, point.Postion.y);
                yMax = Math.Max(yMax, point.Postion.y);
            }
            Console.WriteLine($"{xMin}  {xMax}  {yMin}  {yMax} ");
            //if ((Math.Abs(xMin) + Math.Abs(xMax)) > 75 && (Math.Abs(yMin) + Math.Abs(yMax)) > 75)
            //    return;
            Console.WriteLine("");
            Console.WriteLine("#########    ##########");
            Console.WriteLine("");

            for (var y = yMin; y <= yMax; y++)
            {
                for (var x = xMin; x <= xMax; x++)
                {
                    if (points.Any(pos => pos.Postion.x == x && pos.Postion.y == y))
                    {
                        Console.Write('x'); 
                    }
                    else
                    {
                        Console.Write(' ');
                    }
                }
                Console.WriteLine("");
            }
        }

        public class Point
        {
            public Postion Postion;
            public Velocity Velocity;

            public Point(Postion pos, Velocity velo)
            {
                Postion = pos;
                Velocity = velo;
            }

            internal void AddVelocity()
            {
                Postion.x += Velocity.x;
                Postion.y += Velocity.y;
            }
            internal void RevertVelocity()
            {
                Postion.x -= Velocity.x;
                Postion.y -= Velocity.y;
            }
        }
        public  class Postion{
            public int x;
            public int y;

            public Postion(int v1, int v2)
            {
                x = v1;
                y = v2;
            }

        }
        public class Velocity
        {
            public int x;
            public int y;

            public Velocity(int v1, int v2)
            {
                x = v1;
                y = v2;
            }
        }
        private void ParseInformations(List<string> input, out List<Point> point)
        {
            point = new List<Point>();
            foreach (var inp in input)
            {
                var tmp = inp.Replace("<", string.Empty).Replace(">", string.Empty).Replace("position=", string.Empty).Replace("velocity=", ",").Split(',');
                var pos = new Postion(int.Parse(tmp[0]), int.Parse(tmp[1]));
                var velo = new Velocity(int.Parse(tmp[2]), int.Parse(tmp[3]));
                point.Add(new Point(pos, velo));
            }
        }

        public int RunPartB(List<string> input)
        {

            return -1;
        }
    }
}
