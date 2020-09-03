using MarsRover.Utils;
using NUnit.Framework;

namespace MarsRover.Tests
{
    public class RoverMoveTest
    {
        private Plateau Plateau { get; set; }
        private Rover Rover { get; set; }

        [SetUp]
        public void Setup()
        {
            Plateau = new Plateau(Point.Origin, new Point(2,2));
            // Rover = Plateau.DeployRover(new Position(new Point(1, 1)));
        }

        [Test]
        public void MoveToN()
        {
            var expectedPosition = new Position(new Point(1,2));
            Rover.Move();
            Assert.True(Rover.Position.Equals(expectedPosition));
        }
        
        [Test]
        public void MoveToW()
        {
            var expectedPosition = new Position(new Point(0,1), Cardinals.Get("W"));
            Rover.TurnLeft();
            Rover.Move();
            Assert.True(Rover.Position.Equals(expectedPosition));
        }
        
        [Test]
        public void MoveToE()
        {
            var expectedPosition = new Position(new Point(2,1), Cardinals.Get("E"));
            Rover.TurnRight();
            Rover.Move();
            Assert.True(Rover.Position.Equals(expectedPosition));
        }
        
        [Test]
        public void MoveToS()
        {
            var expectedPosition = new Position(new Point(1,0), Cardinals.Get("S"));
            Rover.TurnRight();
            Rover.TurnRight();
            Rover.Move();
            Assert.True(Rover.Position.Equals(expectedPosition));
        }
    }
}