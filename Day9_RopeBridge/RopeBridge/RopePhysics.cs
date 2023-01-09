using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace RopeBridge;

public class Rope
{
    private Point2D[] _knots;
    public int Length { get; private set; }
    public Point2D Head
    {
        get { return _knots[0]; }
        private set { _knots[0] = value; }
    }
    public Point2D Tail
    {
        get { return _knots[Length - 1]; }
    }

    private Point2D[] InitializeKnots()
    {
        Point2D[] knots = new Point2D[Length];
        for (int i = 0; i < Length; i++)
        {
            knots[i] = new Point2D(0, 0);
        }
        return knots;
    }

    public Rope()
    {
        Length = 2;
        _knots = InitializeKnots();
    }

    public Rope(int length)
    {
        Length = length;
        _knots = InitializeKnots();
    }

    private void UpdateKnots()
    {
        for (int i = 1; i < Length; i++)
        {
            Point2D positionDiff = _knots[i - 1].Subtract(_knots[i]);
            if (positionDiff.Y > 1)
            {
                _knots[i] = _knots[i].Add(0, 1);
                if (positionDiff.X > 0) _knots[i] = _knots[i].Add(1, 0);
                else if (positionDiff.X < 0) _knots[i] = _knots[i].Subtract(1, 0);
            }
            else if (positionDiff.Y < -1)
            {
                _knots[i] = _knots[i].Subtract(0, 1);
                if (positionDiff.X > 0) _knots[i] = _knots[i].Add(1, 0);
                else if (positionDiff.X < 0) _knots[i] = _knots[i].Subtract(1, 0);
            }
            if (positionDiff.X > 1)
            {
                _knots[i] = _knots[i].Add(1, 0);
                if (positionDiff.Y > 0) _knots[i] = _knots[i].Add(0, 1);
                else if (positionDiff.Y < 0) _knots[i] = _knots[i].Subtract(0, 1);
            }
            else if (positionDiff.X < -1)
            {
                _knots[i] = _knots[i].Subtract(1, 0);
                if (positionDiff.Y > 0) _knots[i] = _knots[i].Add(0, 1);
                else if (positionDiff.Y < 0) _knots[i] = _knots[i].Subtract(0, 1);
            }
        }
    }

    public Rope MoveHeadUp()
    {
        Head = Head.Add(0, 1);
        UpdateKnots();
        return this;
    }

    public Rope MoveHeadDown()
    {
        Head = Head.Subtract(0, 1);
        UpdateKnots();
        return this;
    }

    public Rope MoveHeadLeft()
    {
        Head = Head.Subtract(1, 0);
        UpdateKnots();
        return this;
    }

    public Rope MoveHeadRight()
    {
        Head = Head.Add(1, 0);
        UpdateKnots();
        return this;
    }
}

public class RopePhysics
{
    public static int GetNumPositionsVisitedByTail(string[] instructionArray, Rope rope)
    {
        List<Point2D> tailTrail = new() { rope.Tail };
        foreach (string instruction in instructionArray)
        {
            int numRepetitions = int.Parse(instruction.Substring(2));
            for (int i = 0; i < numRepetitions; i++)
            {
                switch (instruction[0])
                {
                    case 'U':
                        rope.MoveHeadUp();
                        break;

                    case 'D':
                        rope.MoveHeadDown();
                        break;

                    case 'L':
                        rope.MoveHeadLeft();
                        break;

                    case 'R':
                        rope.MoveHeadRight();
                        break;

                    default:
                        break;
                }
                if (!tailTrail.Contains(rope.Tail))
                {
                    tailTrail.Add(rope.Tail);
                }
            }
        }
        return tailTrail.Count;
    }

    static void Main(string[] args)
    {
        string fileLocation = @"C:\Users\Spore\source\repos\AdventOfCode2022\Day9_RopeBridge\RopeBridge\Day9Input.txt";

        string[] instructionArray = File.ReadAllLines(fileLocation);

        Rope rope = new();

        Console.WriteLine(RopePhysics.GetNumPositionsVisitedByTail(instructionArray, rope));

        rope = new(10);
        Console.WriteLine(RopePhysics.GetNumPositionsVisitedByTail(instructionArray, rope));
    }

}