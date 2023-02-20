using System.Collections.Generic;
using System;

namespace HillClimbingAlgorithm;

public class RouteFinder
{
    public string[] HeightMap { get; private set; }
    public Dictionary<Point2D, int> PathedPoints { get; private set; }

    public RouteFinder(string[] startingMap)
    {
        HeightMap = startingMap;
        PathedPoints = new Dictionary<Point2D, int>();
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
        if (heightChar == 'S') return 1;
        if (heightChar == 'E') return 26;
        return (int)heightChar - 96;
    }

    private Point2D[] FindNeighboursInSet(Point2D[] currentSet, int stepsFromStart)
    {
        List<Point2D> nextSet = new();
        foreach (var point in currentSet)
        {
            int currentHeight = GetHeightOfPoint(point);
            Point2D nextPoint;
            // check right
            if (point.X < HeightMap[0].Length - 1)
            {
                nextPoint = new Point2D(point.X + 1, point.Y);
                if (currentHeight - GetHeightOfPoint(nextPoint) > -2 && !PathedPoints.ContainsKey(nextPoint))
                {
                    PathedPoints.Add(nextPoint, stepsFromStart);
                    nextSet.Add(nextPoint);
                }
            }

            // check down
            if (point.Y < HeightMap.Length - 1)
            {
                nextPoint = new Point2D(point.X, point.Y + 1);
                if (currentHeight - GetHeightOfPoint(nextPoint) > -2 && !PathedPoints.ContainsKey(nextPoint))
                {
                    PathedPoints.Add(nextPoint, stepsFromStart);
                    nextSet.Add(nextPoint);
                }
            }

            // check left
            if (point.X > 0)
            {
                nextPoint = new Point2D(point.X - 1, point.Y);
                if (currentHeight - GetHeightOfPoint(nextPoint) > -2 && !PathedPoints.ContainsKey(nextPoint))
                {
                    PathedPoints.Add(nextPoint, stepsFromStart);
                    nextSet.Add(nextPoint);
                }
            }

            // check up
            if (point.Y > 0)
            {
                nextPoint = new Point2D(point.X, point.Y - 1);
                if (currentHeight - GetHeightOfPoint(nextPoint) > -2 && !PathedPoints.ContainsKey(nextPoint))
                {
                    PathedPoints.Add(nextPoint, stepsFromStart);
                    nextSet.Add(nextPoint);
                }
            }
        }
        return nextSet.ToArray();
    }

    /// Returns a Dictionary<Point2D, int> of all points connected to the end point and their shortest distance from
    /// the end.
    private Dictionary<Point2D, int> GetAllPointsConnectedToEndPoint(Point2D endPoint)
    {
        // Dictionary to hold output
        var connectedPoints = new Dictionary<Point2D, int>();

        int stepsFromEnd = 0;
        connectedPoints.Add(endPoint, stepsFromEnd);

        // List of points whose neighbours need checking
        var currentSet = new List<Point2D> { endPoint };

        while (currentSet.Count != 0)
        {
            List<Point2D> nextSet = new();
            stepsFromEnd++;
            foreach (var point in currentSet)
            {
                int currentHeight = GetHeightOfPoint(point);
                Point2D nextPoint;
                // check right
                if (point.X < HeightMap[0].Length - 1)
                {
                    nextPoint = new Point2D(point.X + 1, point.Y);
                    if (currentHeight - GetHeightOfPoint(nextPoint) < 2 && !connectedPoints.ContainsKey(nextPoint))
                    {
                        connectedPoints.Add(nextPoint, stepsFromEnd);
                        nextSet.Add(nextPoint);
                    }
                }

                // check down
                if (point.Y < HeightMap.Length - 1)
                {
                    nextPoint = new Point2D(point.X, point.Y + 1);
                    if (currentHeight - GetHeightOfPoint(nextPoint) < 2 && !connectedPoints.ContainsKey(nextPoint))
                    {
                        connectedPoints.Add(nextPoint, stepsFromEnd);
                        nextSet.Add(nextPoint);
                    }
                }

                // check left
                if (point.X > 0)
                {
                    nextPoint = new Point2D(point.X - 1, point.Y);
                    if (currentHeight - GetHeightOfPoint(nextPoint) < 2 && !connectedPoints.ContainsKey(nextPoint))
                    {
                        connectedPoints.Add(nextPoint, stepsFromEnd);
                        nextSet.Add(nextPoint);
                    }
                }

                // check up
                if (point.Y > 0)
                {
                    nextPoint = new Point2D(point.X, point.Y - 1);
                    if (currentHeight - GetHeightOfPoint(nextPoint) < 2 && !connectedPoints.ContainsKey(nextPoint))
                    {
                        connectedPoints.Add(nextPoint, stepsFromEnd);
                        nextSet.Add(nextPoint);
                    }
                }
            }
            currentSet = nextSet;
        }
        return connectedPoints;
    }

    public int GetFewestStepsBetweenPoints(Point2D startPoint, Point2D endPoint)
    {
        // reset path
        PathedPoints = new Dictionary<Point2D, int>();

        Point2D[] currentSet = { startPoint };

        int stepsFromStart = 0;
        PathedPoints.Add(startPoint, stepsFromStart);

        while (!currentSet.Contains(endPoint))
        {
            stepsFromStart++;
            currentSet = FindNeighboursInSet(currentSet, stepsFromStart);
        }
        return stepsFromStart;
    }

    public int GetNumberOfStepsFromSToE()
    {
        Point2D startPoint = FindStartPoint();
        Point2D endPoint = FindEndPoint();

        return GetFewestStepsBetweenPoints(startPoint, endPoint);
    }

    public int GetFewestNumberOfStepsToFinishFromHeight(char height)
    {
        Point2D endPoint = FindEndPoint();

        Dictionary<Point2D, int> connectedPoints = GetAllPointsConnectedToEndPoint(endPoint);

        int fewestOverallSteps = int.MaxValue;
        foreach (var kvPair in connectedPoints)
        {
            if (HeightMap[kvPair.Key.Y][kvPair.Key.X] == height)
            {
                int fewestSteps = kvPair.Value;
                if (fewestSteps < fewestOverallSteps) fewestOverallSteps = fewestSteps;
            }
        }
        return fewestOverallSteps;
    }
}
