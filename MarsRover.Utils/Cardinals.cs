using System.Collections.Generic;

namespace MarsRover.Utils
{
    public class CardinalPoint
    {
        public string Value { get; set; }
        public Point Direction { get; set; }
        public CardinalPoint Right { get; set; }
        public CardinalPoint Left { get; set; }

        public override string ToString()
        {
            return Value;
        }

        public override bool Equals(object? obj)
        {
            return ToString().Equals(obj?.ToString());
        }
    };

    public static class Cardinals
    {
        public static void PopulateCardinals()
        {
            if (_start != null)
                return;
            Insert("N", new Point(0, 1));
            Insert("E", new Point(1, 0));
            Insert("S", new Point(0, -1));
            Insert("W", new Point(-1, 0));
        }

        public static CardinalPoint DefaultCardinalPoint
        {
            get
            {
                PopulateCardinals();
                return _start;
            }
        }

        private static CardinalPoint _start;

        private static void Insert(string value, Point direction)
        {
            CardinalPoint newCardinalPoint;

            if (_start == null)
            {
                newCardinalPoint = new CardinalPoint {Value = value, Direction = direction};
                newCardinalPoint.Right = newCardinalPoint.Left = newCardinalPoint;
                _start = newCardinalPoint;

                return;
            }

            var last = _start.Left;
            newCardinalPoint = new CardinalPoint {Value = value, Direction = direction, Right = _start};
            _start.Left = newCardinalPoint;
            newCardinalPoint.Left = last;
            last.Right = newCardinalPoint;
        }

        public static CardinalPoint Get(string value)
        {
            if (_start == null)
                PopulateCardinals();

            var current = _start;
            while (!current.Value.Equals(value))
            {
                current = current.Right;
            }

            return current;
        }

        public static List<CardinalPoint> ToList()
        {
            var result = new List<CardinalPoint>();
            CardinalPoint temp = _start;
            do
            {
                result.Add(temp);
                temp = temp.Right;
            } while (!temp.Equals(_start));

            return result;
        }
    }
}