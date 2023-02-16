namespace HillClimbingAlgorithm;

public class RouteFinder
{
    public string[] HeightMap { get; private set; }

    public RouteFinder(string[] startingMap)
    {
        HeightMap = startingMap;
    }

    private Point2D FindStartPoint()
    {
        for (int i = 0; i < HeightMap.Length; i++)
        {
            string line = HeightMap[i];
            if (line.Contains('S')) return new Point2D(line.IndexOf('S'), i);
        }
        throw new ArgumentException("No starting point 'S' found.");
    }

    private Point2D FindEndPoint()
    {
        for (int i = 0; i < HeightMap.Length; i++)
        {
            string line = HeightMap[i];
            if (line.Contains('E')) return new Point2D(line.IndexOf('E'), i);
        }
        throw new ArgumentException("No end point 'E' found.");
    }

    public int GetHeightOfPoint(Point2D point)
    {
        char heightChar = HeightMap[point.Y][point.X];
        return (int)heightChar - 96;
    }

    public int[,] CreatePath()
    {
        int mapWidth = HeightMap[0].Length;
        int mapHeight = HeightMap.Length;
        Point2D startPoint = FindStartPoint();
        Point2D endPoint = FindEndPoint();
        Point2D currentPoint = startPoint;
        int[,] graph = new int[mapWidth, mapHeight];

        // Dictionary to represent all points for which a path has been found and their distance from the start point
        Dictionary<Point2D, int> pathedPoints = new();
        pathedPoints.Add(currentPoint, 0);

        while (!pathedPoints.ContainsKey(endPoint))
        {
            int currentHeight = GetHeightOfPoint(currentPoint);
            Point2D nextPoint;
            // check right
            if (currentPoint.X < mapWidth)
            {
                nextPoint = new Point2D(currentPoint.X + 1, currentPoint.Y);
                if (currentHeight - GetHeightOfPoint(nextPoint) > -2) pathedPoints.Add(nextPoint, distanceFromStart);
            }

            // check down
            if (currentPoint.Y < mapHeight)
            {
                nextPoint = new Point2D(currentPoint.X, currentPoint.Y + 1);
                if (currentHeight - GetHeightOfPoint(nextPoint) > -2) pathedPoints.Add(nextPoint, distanceFromStart);
            }

            // check left
            if (currentPoint.X >= 0)
            {
                nextPoint = new Point2D(currentPoint.X - 1, currentPoint.Y);
                if (currentHeight - GetHeightOfPoint(nextPoint) > -2) pathedPoints.Add(nextPoint, distanceFromStart);
            }

            // check up
            if (currentPoint.Y >= 0)
            {
                nextPoint = new Point2D(currentPoint.X, currentPoint.Y - 1);
                if (currentHeight - GetHeightOfPoint(nextPoint) > -2) pathedPoints.Add(nextPoint, distanceFromStart);
            }
            currentPoint = pathedPoints[distanceFromStart];
        }
        throw new NotImplementedException();
    }

    public int GetNumberOfSteps()
    {
        throw new NotImplementedException();
    }
}
