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
        int yDifference = Head[1] - Tail[1];
        if (yDifference > 1) Tail[1]++;
        else if (yDifference < -1) Tail[1]--;
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
}

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}