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
        new object[] { new Point2D(0, 1), 1},
        new object[] { new Point2D(4, 2), 26}
    };

    [Test]
    public void CreateGraph_ReturnsCorrectGraph()
    {
        int[,] expected = {
            { 0, 1, 2, 19, 18, 17, 16, 15 },
            { 1, 2, 3, 20, 29, 28, 27, 14 },
            { 2, 3, 4, 21, 30, 31, 26, 13 },
            { 3, 4, 5, 22, 23, 24, 25, 12 },
            { 4, 5, 6,  7,  8,  9, 10, 11 }
        };
        int[,] actual = _sut.CreatePath();

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void GetNumberOfSteps_ReturnsCorrectNumberOfSteps()
    {
        int expected = 31;
        int actual = _sut.GetNumberOfSteps();

        Assert.That(actual, Is.EqualTo(expected));
    }
}