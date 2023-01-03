namespace RopeBridge;

public class Rope
{
    int[] _head;

    public int[] Head
    {
        get
        {
            return _head;
        }
        set
        {
            _head = value;
            if (+(_head[0] - Tail[0]) > 2)
            {

            }
        }
    }
    public int[] Tail { get; private set; }

    public Rope()
    {
        Head = new[] { 0, 0 };
        Tail = new[] { 0, 0 };
    }

    public Rope MoveUp(int numberOfSteps)
    {
        throw new NotImplementedException();
    }
}

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}