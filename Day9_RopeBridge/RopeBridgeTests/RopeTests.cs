using RopeBridge;
namespace RopeBridgeTests;

public class RopeTests
{
    [TestCase(2, 0, 1)]
    [TestCase(1, 0, 0)]
    [TestCase(3, 0, 2)]
    public void GivenTheHeadMovesUp_TheTail_CorrectlyFollows(int numberOfSteps, int expectedTailX, int expectedTailY)
    {
        int[] expected = { expectedTailX, expectedTailY };
        Rope testRope = new();
        for (int i = 0; i < numberOfSteps; i++)
        {
            testRope.MoveUp();
        }
        int[] output = testRope.Tail;

        Assert.That(output, Is.EqualTo(expected));
    }

    [TestCase(2, 0, -1)]
    [TestCase(1, 0, 0)]
    [TestCase(3, 0, -2)]
    public void GivenTheHeadMovesDown_TheTail_CorrectlyFollows(int numberOfSteps, int expectedTailX, int expectedTailY)
    {
        int[] expected = { expectedTailX, expectedTailY };
        Rope testRope = new();
        for (int i = 0; i < numberOfSteps; i++)
        {
            testRope.MoveDown();
        }
        int[] output = testRope.Tail;

        Assert.That(output, Is.EqualTo(expected));
    }

    [TestCase(2, -1, 0)]
    [TestCase(1, 0, 0)]
    [TestCase(3, -2, 0)]
    public void GivenTheHeadMovesLeft_TheTail_CorrectlyFollows(int numberOfSteps, int expectedTailX, int expectedTailY)
    {
        int[] expected = { expectedTailX, expectedTailY };
        Rope testRope = new();
        for (int i = 0; i < numberOfSteps; i++)
        {
            testRope.MoveLeft();
        }
        int[] output = testRope.Tail;

        Assert.That(output, Is.EqualTo(expected));
    }

    [TestCase(2, 1, 0)]
    [TestCase(1, 0, 0)]
    [TestCase(3, 2, 0)]
    public void GivenTheHeadMovesRight_TheTail_CorrectlyFollows(int numberOfSteps, int expectedTailX, int expectedTailY)
    {
        int[] expected = { expectedTailX, expectedTailY };
        Rope testRope = new();
        for (int i = 0; i < numberOfSteps; i++)
        {
            testRope.MoveRight();
        }
        int[] output = testRope.Tail;

        Assert.That(output, Is.EqualTo(expected));
    }
}