using MarsRover.Utils;
using NUnit.Framework;

namespace MarsRover.Tests
{
    public class InputHandlerTests
    {
        private Plateau Plateau { get; set; }
        private Rover Rover { get; set; }

        [SetUp]
        public void Setup()
        {
            Plateau = new Plateau(Point.Origin, new Point(2, 2));
            Rover = Plateau.DeployRover(new Position(new Point(1, 1)));
        }

        [Test]
        public void RoverCommandL()
        {
            RoverInputHandler.Execute(Rover, 'L');
            Assert.AreEqual(Rover.Position.Heading, Cardinals.Get("W"));
        }

        [Test]
        public void RoverCommandR()
        {
            RoverInputHandler.Execute(Rover, 'R');
            Assert.AreEqual(Rover.Position.Heading, Cardinals.Get("E"));
        }

        [Test]
        public void RoverCommandM()
        {
            RoverInputHandler.Execute(Rover, 'M');
            Assert.AreEqual(Rover.Position.Point, new Point(1, 2));
        }
      
        [Test]
        public void RoverCommandL_M()
        {
            RoverInputHandler.Execute(Rover, "LM");
            Assert.AreEqual(Rover.Position.Point, new Point(0, 1));
        }
    }
}