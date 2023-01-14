using RopeBridge;

namespace RopeBridgeTests;

internal class Point2DTests
{
    [Test]
    public void GivenReversedPoints_TheirHashcodes_AreNotEqual()
    {
        int pointHashcode = new Point2D(2, 1).GetHashCode();
        int reversedPointHashcode = new Point2D(1, 2).GetHashCode();

        Assert.That(pointHashcode, Is.Not.EqualTo(reversedPointHashcode));
    }
}
