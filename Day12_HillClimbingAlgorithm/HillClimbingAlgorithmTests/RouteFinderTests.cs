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

    [Test]
    public void RouteFinder_FindsCorrectRoute()
    {
        int expected = 31;
        int actual = _sut.GetFewestSteps();

        Assert.That(actual, Is.EqualTo(expected));
    }
}