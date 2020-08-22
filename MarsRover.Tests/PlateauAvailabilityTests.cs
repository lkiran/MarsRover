using MarsRover.Utils;
using NUnit.Framework;

namespace MarsRover.Tests
{
    public class PlateauAvailabilityTests
    {
        [Test]
        public void InsidePlateau()
        {
            var plateau = new Plateau(Point.Origin);

            Assert.True(plateau.IsPointInPlateau(Point.Origin));
        }

        [Test]
        public void AtTheEdgeOfPlateau()
        {
            var plateau = new Plateau(Point.Origin, new Point(1, 1));
            
            Assert.True(plateau.IsPointInPlateau(new Point(1, 1)));
        }

        [Test]
        public void OutsidePlateau()
        {
            var plateau = new Plateau(Point.Origin);

            Assert.False(plateau.IsPointInPlateau(new Point(1, 1)));
        }


        [Test]
        public void RoverAtPoint()
        {
            var plateau = new Plateau(Point.Origin);
            plateau.DeployRover(new Position(Point.Origin));
            
            Assert.True(plateau.IsThereARoverAtPoint(Point.Origin));
        }

        [Test]
        public void NoRoverAtPoint()
        {
            var plateau = new Plateau(new Point(1, 1));
            plateau.DeployRover(new Position(Point.Origin));
            
            Assert.False(plateau.IsThereARoverAtPoint(new Point(1, 0)));
        }
    }
}