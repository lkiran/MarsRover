namespace MarsRover.Utils
{
    public class Point
    {
        public static Point Origin = new Point();
        
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x = 0, int y = 0)
        {
            this.X = x;
            this.Y = y;
        }

        public override string ToString()
        {
            return $"{X} {Y}";
        }
    }
}