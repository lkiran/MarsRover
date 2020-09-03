using System.Collections.Generic;
using System.Linq;
using MarsRover.Utils;

namespace MarsRover
{
    public class Plateau
    {
        private Point? _bottomLeft;
        private Point? _topRight;

        public readonly List<IObstacle> Obstacles;

        public Plateau()
        {
            Obstacles = new List<IObstacle>();
        }

        public Plateau(Point topRight)
        {
            TopRight = topRight;
            Obstacles = new List<IObstacle>();
        }

        public Plateau(Point bottomLeft, Point topRight)
        {
            BottomLeft = bottomLeft;
            TopRight = topRight;
            Obstacles = new List<IObstacle>();
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

        public IObstacle DeployRover(Position position)
        {
            var newRover = new Rover(position, this);
            Obstacles.Add(newRover);
            return newRover;
        }

        public bool IsPointAvailable(Point point) => !IsThereARoverAtPoint(point) && IsPointInPlateau(point);

        public bool IsPointInPlateau(Point point) =>
            BottomLeft.X <= point.X
            && TopRight.X >= point.X
            && BottomLeft.Y <= point.Y
            && TopRight.Y >= point.Y;

        public bool IsThereARoverAtPoint(Point point) =>
            Obstacles.Any(r => r.Position.Point.X == point.X && r.Position.Point.Y == point.Y);

        public Rover GetCorpseInPosition(Position position)
        {
            return (Rover) Obstacles.FirstOrDefault(o => o.Position.Heading.Value == position.Heading.Value
                                                         && o.Position.Point.X == position.Point.X
                                                         && o.Position.Point.Y == position.Point.Y
                                                         && !((Rover) o).IsAlive);
        }
    }
}
