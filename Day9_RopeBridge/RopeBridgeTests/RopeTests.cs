using RopeBridge;
namespace RopeBridgeTests;

public class RopeTests
{
    [TestCase(1, 0, 0)]
    public void GivenTheHeadMovesUp_TheTail_CorrectlyFollows(int numberOfSteps, int expectedTailX, int expectedTailY)
    {
        Rope testRope = new();

        testRope.MoveUp(numberOfSteps);
        int[] output = testRope.Tail;

        Assert.That(output[0], Is.EqualTo(expectedTailX));
        Assert.That(output[1], Is.EqualTo(expectedTailY));
    }
}