namespace HillClimbingAlgorithmTests;

public class RouteFinderTests
{
    private string[] _startingPosition = {
        "Sabqponm",
        "abcryxxl",
        "accszExk",
        "acctuvwj",
        "abdefghi"
    };

    [Test]
    public void RouteFinder_FindsCorrectRoute()
    {
        string[] expected =
        {
            "v..v<<<<",
            ">v.vv<<^",
            ".>vv>E^^",
            "..v>>>^^",
            "..>>>>>^"
        };
        string[] actual = RouteFinder.FindRoute(_startingPosition);

    }
}