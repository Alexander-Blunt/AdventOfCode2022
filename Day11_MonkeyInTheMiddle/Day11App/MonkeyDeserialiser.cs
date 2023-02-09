using System.Reflection.Emit;

namespace Day11App;

public class MonkeyDeserialiser
{
    public Queue<int> DeserialiseStartingItems(string itemsLine)
    {
        int[] itemArray = itemsLine.Split(", ").Select(s => int.Parse(s)).ToArray<int>();

        return new Queue<int>(itemArray);
    }

    public Func<int, int> DeserialiseOperation(string opString)
    {
        string[] opParts = opString.Split(' ');
        if (opParts.Length != 5) throw new ArgumentException("The function should be of the format new = old + x");
        switch (opParts[3])
        {
            case "+":
                return OperationBuilder.Add(opParts[4]);
            case "*":
                return OperationBuilder.Mul(opParts[4]);
            default:
                throw new ArgumentException("Operator must be + or *");
        }
    }

    public Func<int, bool> DeserialiseTest(string opString)
    {
        string divisorString = opString.Split(" ").Last();
        int divisor = int.Parse(divisorString);
        return i => i % divisor == 0;
    }
}

public static class OperationBuilder
{
    public static Func<int, int> Add(string other)
    {
        if (other == "old") return i => i + i;
        else if (int.TryParse(other, out int result)) return i => i + result;
        else throw new ArgumentException(@"Argument must be a string representation of an integer or 'old'");
    }

    public static Func<int, int> Mul(string other)
    {
        if (other == "old") return i => i * i;
        else if (int.TryParse(other, out int result)) return i => i * result;
        else throw new ArgumentException(@"Argument must be a string representation of an integer or 'old'");
    }
}