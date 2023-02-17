namespace HillClimbingAlgorithmTests;

public class RouteFinderTests
{
    private RouteFinder _sut;
    private string[] _startingMap = {
        "Sabqponm",
        "abcryxxl",
        "accszExk",
        "acctuvwj",
        "abdefghi"
    };

    [SetUp]
    public void SetUp()
    {
        _sut = new RouteFinder(_startingMap);
    }

    [TestCaseSource(nameof(HeightTestSource))]
    public void GetHeightOfPoint_ReturnsCorrectValue(Point2D input, int expected)
    {
        int actual = _sut.GetHeightOfPoint(input);
        Assert.That(actual, Is.EqualTo(expected));
    }

    public static object[] HeightTestSource =
    {
        new object[] { new Point2D(0, 0), 1},
        new object[] { new Point2D(5, 2), 26},
        new object[] { new Point2D(0, 1), 1},
        new object[] { new Point2D(4, 2), 26}
    };

    [Test]
    public void GetNumberOfStepsToFinish_ReturnsCorrectNumberOfSteps()
    {
        int expected = 31;
        int actual = _sut.GetNumberOfStepsToFinish();

        Assert.That(actual, Is.EqualTo(expected));
    }
}