using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace RopeBridge;

public class Rope
{
    public Point2D Head { get; set; }
    public Point2D Tail { get; private set; }

    public Rope()
    {
        Head = new(0, 0);
        Tail = new(0, 0);
    }

    public Rope(int x, int y)
    {
        Head = new(x, y);
        Tail = new(x, y);
    }

    private Rope MoveTailUp()
    {
        Tail = Tail.Add(0, 1);
        return this;
    }

    private Rope MoveTailDown()
    {
        Tail = Tail.Subtract(0, 1);
        return this;
    }

    private Rope MoveTailLeft()
    {
        Tail = Tail.Subtract(1, 0);
        return this;
    }

    private Rope MoveTailRight()
    {
        Tail = Tail.Add(1, 0);
        return this;
    }

    private void UpdateTail()
    {
        Point2D headTailDiff = Head.Subtract(Tail);

        if (headTailDiff.X > 1) MoveTailRight();
        if (headTailDiff.X < -1) MoveTailLeft();
        if (headTailDiff.Y > 1) MoveTailUp();
        if (headTailDiff.Y < -1) MoveTailDown();
    }

    public Rope MoveHeadUp()
    {
        Head = Head.Add(0, 1);
        UpdateTail();
        return this;
    }

    public Rope MoveHeadDown()
    {
        Head = Head.Subtract(0, 1);
        UpdateTail();
        return this;
    }

    public Rope MoveHeadLeft()
    {
        Head = Head.Subtract(1, 0);
        UpdateTail();
        return this;
    }

    public Rope MoveHeadRight()
    {
        Head = Head.Add(1, 0);
        UpdateTail();
        return this;
    }
}

public class RopePhysics
{
    public static int GetNumPositionsVisitedByTail(string[] instructionArray, Rope rope)
    {
        List<Point2D> tailTrail = new() { rope.Tail };
        int numPositionsVisited = 0;
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
                    numPositionsVisited++;
                    tailTrail.Add(rope.Tail);
                }
            }
        }
        return numPositionsVisited;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }

}