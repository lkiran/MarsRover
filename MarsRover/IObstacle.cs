using MarsRover.Utils;

namespace MarsRover
{
    public interface IObstacle
    {
        Position Position { get;  set; }
        string Print();
    }
}