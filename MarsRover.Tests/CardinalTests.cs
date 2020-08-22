using MarsRover.Utils;
using NUnit.Framework;

namespace MarsRover.Tests
{
    public class CardinalTests
    {
        [Test]
        public void PopulateCardinals()
        {
            Cardinals.PopulateCardinals();
            Assert.NotNull(Cardinals.DefaultCardinalPoint);
        }
        
        [Test]
        public void GetSouthCardinal()
        {
            Cardinals.PopulateCardinals();
            var sought = Cardinals.Get("S");

            Assert.NotNull(sought);
        }
    }
}