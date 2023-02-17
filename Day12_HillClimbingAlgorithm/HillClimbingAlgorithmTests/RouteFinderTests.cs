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
    public void GetNumberOfStepsFromSToF_ReturnsCorrectNumberOfSteps()
    {
        int expected = 31;
        int actual = _sut.GetNumberOfStepsFromSToF();

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void GetNumberOfStepsFromHeight_ReturnsCorrectNumberOfSteps()
    {
        int expected = 29;
        int actual = _sut.GetFewestNumberOfStepsToFinishFromHeight('a');

        Assert.That(actual, Is.EqualTo(expected));
    }
}