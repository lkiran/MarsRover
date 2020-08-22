namespace MarsRover.Utils
{
    public class Position
    {
        private Point? _point;
        private Orientation? _heading;

        public Point Point
        {
            get => _point ?? Point.Origin;
            set => _point = value;
        }

        public Orientation Heading
        {
            get => _heading ?? Orientation.N;
            set => _heading = value;
        }

        public Position()
        {
        }

        public Position(Point point)
        {
            _heading = Orientation.N;
        }

        public Position(Point point, Orientation heading)
        {
            _point = point;
            _heading = heading;
        }

        public override string ToString()
        {
            return $"{Point.X} {Point.Y} {Heading}";
        }
    }
}