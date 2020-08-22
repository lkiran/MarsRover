using MarsRover.Utils;
using NUnit.Framework;

namespace MarsRover.Tests
{
    public class RoverTurnTests
    {
        public Rover Rover { get; set; }

        [SetUp]
        public void Setup()
        {
            var deployedAt = new Position();
            Rover = new Rover(deployedAt, new Plateau());
        }

        [Test]
        public void TurnLeft()
        {
            Rover.Turn(Rotate.L);
            Assert.AreEqual(Rover.Position.Heading, Cardinals.Get("W"));
        }

        [Test]
        public void TurnRight()
        {
            Rover.Turn(Rotate.R);
            Assert.AreEqual(Rover.Position.Heading, Cardinals.Get("E"));
        }

        [Test]
        public void TurnLeftTwoTimes()
        {
            Rover.Turn(Rotate.L);
            Rover.Turn(Rotate.L);
            Assert.AreEqual(Rover.Position.Heading, Cardinals.Get("S"));
        }

        [Test]
        public void TurnRightTwoTimes()
        {
            Rover.Turn(Rotate.R);
            Rover.Turn(Rotate.R);
            Assert.AreEqual(Rover.Position.Heading, Cardinals.Get("S"));
        }

        [Test]
        public void TurnLeftThreeTimes()
        {
            Rover.Turn(Rotate.L);
            Rover.Turn(Rotate.L);
            Rover.Turn(Rotate.L);
            Assert.AreEqual(Rover.Position.Heading, Cardinals.Get("E"));
        }

        [Test]
        public void TurnRightThreeTimes()
        {
            Rover.Turn(Rotate.R);
            Rover.Turn(Rotate.R);
            Rover.Turn(Rotate.R);
            Assert.AreEqual(Rover.Position.Heading, Cardinals.Get("W"));
        }

        [Test]
        public void TurnLeftFourTimes()
        {
            Rover.Turn(Rotate.L);
            Rover.Turn(Rotate.L);
            Rover.Turn(Rotate.L);
            Rover.Turn(Rotate.L);
            Assert.AreEqual(Rover.Position.Heading, Cardinals.Get("N"));
        }

        [Test]
        public void TurnRightFourTimes()
        {
            Rover.Turn(Rotate.R);
            Rover.Turn(Rotate.R);
            Rover.Turn(Rotate.R);
            Rover.Turn(Rotate.R);
            Assert.AreEqual(Rover.Position.Heading, Cardinals.Get("N"));
        }
    }
}