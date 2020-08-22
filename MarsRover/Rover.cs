using MarsRover.Utils;

namespace MarsRover
{
    public class Rover
    {
        public Rover(Position position, Plateau plateau)
        {
            Position = position;
        }

        public Position Position { get; private set; }

        public void Move(int step)
        {
            switch (Position.Heading)
            {
                case Orientation.N:
                    Position.Point.Y += step;
                    break;
                case Orientation.E:
                    Position.Point.X += step;
                    break;
                case Orientation.S:
                    Position.Point.Y += -step;
                    break;
                case Orientation.W:
                    Position.Point.X += -step;
                    break;
            }
        }

        public void Turn(Rotate rotate)
        {
            switch (Position.Heading)
            {
                case Orientation.N when rotate == Rotate.L:
                    Position.Heading = Orientation.W;
                    break;
                case Orientation.W when rotate == Rotate.R:
                    Position.Heading = Orientation.N;
                    break;
                default:
                    Position.Heading += (int) rotate;
                    break;
            }
        }
        
        public override string ToString()
        {
            return Position.ToString();
        }
    }
}