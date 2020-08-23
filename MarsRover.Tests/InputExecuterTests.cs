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
        public void CreatePlateau()
        {
            var plateau = PlateauInputExecuter.Create("5 5");
            Assert.AreEqual(plateau.TopRight, new Point(5,5));
            Assert.AreEqual(plateau.BottomLeft,  Point.Origin);
        }
        
        [Test]
        public void DeployRover()
        {
            var rover = PlateauInputExecuter.DeployRover(Plateau, "1 2 N");
            Assert.AreEqual(rover.Position, new Position(new Point(1,2), Cardinals.Get("N")));
        }
        
        [Test]
        public void RoverCommandL()
        {
            RoverInputExecuter.Execute(Rover, 'L');
            Assert.AreEqual(Rover.Position.Heading, Cardinals.Get("W"));
        }

        [Test]
        public void RoverCommandR()
        {
            RoverInputExecuter.Execute(Rover, 'R');
            Assert.AreEqual(Rover.Position.Heading, Cardinals.Get("E"));
        }

        [Test]
        public void RoverCommandM()
        {
            RoverInputExecuter.Execute(Rover, 'M');
            Assert.AreEqual(Rover.Position.Point, new Point(1, 2));
        }
      
        [Test]
        public void RoverCommandL_M()
        {
            RoverInputExecuter.Execute(Rover, "LM");
            Assert.AreEqual(Rover.Position.Point, new Point(0, 1));
        }
    }
}