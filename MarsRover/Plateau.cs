using System.Collections.Generic;
using System.Linq;
using MarsRover.Utils;

namespace MarsRover
{
    public class Plateau
    {
        private Point? _bottomLeft;
        private Point? _topRight;

        public readonly List<Rover> Rovers;

        public Plateau()
        {
            Rovers = new List<Rover>();
        }

        public Plateau(Point topRight)
        {
            TopRight = topRight;
            Rovers = new List<Rover>();
        }

        public Plateau(Point bottomLeft, Point topRight)
        {
            BottomLeft = bottomLeft;
            TopRight = topRight;
            Rovers = new List<Rover>();
        }


        public Point BottomLeft
        {
            get => _bottomLeft ?? Point.Origin;
            set => _bottomLeft = value;
        }

        public Point TopRight
        {
            get { return _topRight ?? Point.Origin; }
            set => _topRight = value;
        }

        public Rover DeployRover(Position position)
        {
            var newRover = new Rover(position, this);
            Rovers.Add(newRover);
            return newRover;
        }

        public bool IsPointAvailable(Point point) => !IsThereARoverAtPoint(point) && IsPointInPlateau(point);

        public bool IsPointInPlateau(Point point) =>
            BottomLeft.X <= point.X
            && TopRight.X >= point.X
            && BottomLeft.Y <= point.Y
            && TopRight.Y >= point.Y;

        public bool IsThereARoverAtPoint(Point point) =>
            Rovers.Any(r => r.Position.Point.X == point.X && r.Position.Point.Y == point.Y);
    }
}