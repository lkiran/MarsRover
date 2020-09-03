using MarsRover.Utils;

namespace MarsRover
{
    public class Rover : IObstacle
    {
        public Rover(Position position, Plateau plateau)
        {
            Position = position;
            Plateau = plateau;
        }

        public bool IsAlive { get; set; } = true;

        public Position Position { get; set; }

        public Plateau Plateau { get; private set; }

        [Command('M')]
        public void Move()
        {
            var corpseAtPosition = Plateau.GetCorpseInPosition(Position);
            if (corpseAtPosition != null)
                return;

            Position targetPosition = new Position()
            {
                Heading = Position.Heading,
                Point = new Point
                {
                    X = Position.Point.X + Position.Heading.Direction.X,
                    Y = Position.Point.Y + Position.Heading.Direction.Y
                }
            };


            if (Plateau.IsPointInPlateau(targetPosition.Point))
                Position = targetPosition;
            else
                IsAlive = false;
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


        public string Print()
        {
            return IsAlive
                ? Position.ToString()
                : $"{Position} RIP";
        }
    }
}