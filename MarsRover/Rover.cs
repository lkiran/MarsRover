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

        public void Move()
        {
            Position.Point.X += Position.Heading.Direction.X;
            Position.Point.Y += Position.Heading.Direction.Y;
        }

        public void Turn(Rotate rotate)
        {
            if (rotate == Rotate.L)
                Position.Heading = Position.Heading.Left;
            else if (rotate == Rotate.R)
                Position.Heading = Position.Heading.Right;
        }

        public override string ToString()
        {
            return Position.ToString();
        }
    }
}