using MarsRover.Utils;
using NUnit.Framework;

namespace MarsRover.Tests
{
    public class RoverDeployTest
    {
        public Plateau Plateau { get; set; }

        [SetUp]
        public void Setup()
        {
            Plateau = new Plateau(Point.Origin, Point.Origin);
        }

        [Test]
        public void DeployRoverAt_3_2_S()
        {
            var position = (new Position(new Point(3, 2), Orientation.S));
            var deployedRover = Plateau.DeployRover(position);
            Assert.AreEqual(deployedRover.Position,position);
        }
    }
}