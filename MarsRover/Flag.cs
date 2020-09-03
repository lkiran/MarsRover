using MarsRover.Utils;

namespace MarsRover
{
    public class Flag : IObstacle
    {
        public Flag(Position position)
        {
            Position = position;
        }

        public Position Position { get; set; }

        public string Print()
        {
            return $"{Position} RIP";
        }
    }
}