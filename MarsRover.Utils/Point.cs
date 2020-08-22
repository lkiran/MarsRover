using System;

namespace MarsRover.Utils
{
    public class Point
    {
        public static readonly Point Origin = new Point();
        
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x = 0, int y = 0)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"{X} {Y}";
        }

        public override bool Equals(object? obj)
        {
            return ToString().Equals(obj?.ToString());
        }
    }
}