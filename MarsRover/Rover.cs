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

        [Command('M')]
        public void Move()
        {
            Position.Point.X += Position.Heading.Direction.X;
            Position.Point.Y += Position.Heading.Direction.Y;
        }

        [Command('L')]
        public void TurnLeft()
        {
            Position.Heading = Position.Heading.Left;
        }
        
        [Command('R')]
        public void TurnRight()
        {
            Position.Heading = Position.Heading.Right;
        }

        public void Turn(Rotate rotate)
        {
            if (rotate == Rotate.L)
                TurnLeft();
            else if (rotate == Rotate.R)
                TurnRight();
        }

        public override string ToString()
        {
            return Position.ToString();
        }
    }
}