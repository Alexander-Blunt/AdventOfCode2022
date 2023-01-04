namespace RopeBridge;

public class Rope
{
    public int[] Head { get; set; }
    public int[] Tail { get; private set; }

    public Rope()
    {
        Head = new[] { 0, 0 };
        Tail = new[] { 0, 0 };
    }

    private void UpdateTail()
    {
        int xDifference = Head[0] - Tail[0];
        int yDifference = Head[1] - Tail[1];

        if (xDifference > 1)
        {
            Tail[0]++;
            Tail[1] += yDifference;
        }
        else if (xDifference < -1)
        {
            Tail[0]--;
            Tail[1] += yDifference;
        }

        if (yDifference > 1)
        {
            Tail[1]++;
            Tail[0] += xDifference;
        }
        else if (yDifference < -1)
        {
            Tail[1]--;
            Tail[0] += xDifference;
        }
    }

    public Rope MoveUp()
    {
        Head[1]++;
        this.UpdateTail();
        return this;
    }

    public Rope MoveDown()
    {
        Head[1]--;
        this.UpdateTail();
        return this;
    }

    public Rope MoveLeft()
    {
        Head[0]--;
        this.UpdateTail();
        return this;
    }

    public Rope MoveRight()
    {
        Head[0]++;
        this.UpdateTail();
        return this;
    }
}

public class RopePhysics
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }

    public static int GetNumPositionsVisitedByTail(string[] instructionArray)
    {
        throw new NotImplementedException();
    }
}