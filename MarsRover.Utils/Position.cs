namespace MarsRover.Utils
{
    public class Position
    {
        private Point? _point;
        private CardinalPoint? _heading;

        public Point Point
        {
            get => _point ?? Point.Origin;
            set => _point = value;
        }

        public CardinalPoint Heading
        {
            get => _heading ?? Cardinals.DefaultCardinalPoint;
            set => _heading = value;
        }

        public Position()
        {
        }

        public Position(Point point)
        {
            _point = point;
        }

        public Position(Point point, CardinalPoint heading)
        {
            _point = point;
            _heading = heading;
        }

        public override string ToString()
        {
            return $"{Point.X} {Point.Y} {Heading.Value}";
        }
    }
}