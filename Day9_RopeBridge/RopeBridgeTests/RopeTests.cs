using RopeBridge;

namespace RopeBridgeTests;

public class RopeTests
{
    Rope testRope;
    [SetUp]
    public void Setup()
    {
        testRope = new();
    }

    [TestCase(2, 0, 1)]
    [TestCase(1, 0, 0)]
    [TestCase(3, 0, 2)]
    public void GivenTheHeadMovesUp_TheTail_CorrectlyFollows(int numberOfSteps, int expectedTailX, int expectedTailY)
    {
        Point2D expected = new(expectedTailX, expectedTailY);
        for (int i = 0; i < numberOfSteps; i++)
        {
            testRope.MoveHeadUp();
        }
        Point2D output = testRope.Tail;

        Assert.That(output, Is.EqualTo(expected));
    }

    [TestCase(2, 0, -1)]
    [TestCase(1, 0, 0)]
    [TestCase(3, 0, -2)]
    public void GivenTheHeadMovesDown_TheTail_CorrectlyFollows(int numberOfSteps, int expectedTailX, int expectedTailY)
    {
        Point2D expected = new(expectedTailX, expectedTailY);
        for (int i = 0; i < numberOfSteps; i++)
        {
            testRope.MoveHeadDown();
        }
        Point2D output = testRope.Tail;

        Assert.That(output, Is.EqualTo(expected));
    }

    [TestCase(2, -1, 0)]
    [TestCase(1, 0, 0)]
    [TestCase(3, -2, 0)]
    public void GivenTheHeadMovesLeft_TheTail_CorrectlyFollows(int numberOfSteps, int expectedTailX, int expectedTailY)
    {
        Point2D expected = new(expectedTailX, expectedTailY);
        for (int i = 0; i < numberOfSteps; i++)
        {
            testRope.MoveHeadLeft();
        }
        Point2D output = testRope.Tail;

        Assert.That(output, Is.EqualTo(expected));
    }

    [TestCase(2, 1, 0)]
    [TestCase(1, 0, 0)]
    [TestCase(3, 2, 0)]
    public void GivenTheHeadMovesRight_TheTail_CorrectlyFollows(int numberOfSteps, int expectedTailX, int expectedTailY)
    {
        Point2D expected = new(expectedTailX, expectedTailY);
        for (int i = 0; i < numberOfSteps; i++)
        {
            testRope.MoveHeadRight();
        }
        Point2D output = testRope.Tail;

        Assert.That(output, Is.EqualTo(expected));
    }

    [Test]
    public void GivenTheHeadMovesDiagonally_TheTail_CorrectlyFollows()
    {
        Point2D expected = new(1, 1);

        testRope.MoveHeadUp();
        testRope.MoveHeadRight();
        testRope.MoveHeadUp();

        Point2D output = testRope.Tail;

        Assert.That(output, Is.EqualTo(expected));
    }
}