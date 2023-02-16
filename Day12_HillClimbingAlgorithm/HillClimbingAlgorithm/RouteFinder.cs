namespace HillClimbingAlgorithm;

public class RouteFinder
{
    private string[] _startingMap;

    public RouteFinder(string[] startingMap)
    {
        this._startingMap = startingMap;
    }

    private Point2D FindStartPoint()
    {
        for (int i = 0; i < _startingMap.Length; i++)
        {
            string line = _startingMap[i];
            if (line.Contains('S')) return new Point2D(line.IndexOf('S'), i);
        }
    }

    private int FindEndPoint()
    {

    }

    private 

    public int GetFewestSteps()
    {

    }

}
