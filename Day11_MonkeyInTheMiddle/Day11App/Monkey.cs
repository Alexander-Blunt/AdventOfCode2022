using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day11App;

public class Monkey : IEquatable<Monkey?>
{
    public Queue<long> Items { get; set; }
    public MonkeyOp Operation { get; }
    public int TestDivisor { get; }
    public int TrueReceiver { get; }
    public int FalseReceiver { get; }
    public Watcher Watcher { get; internal set; }
    public int Business { get; internal set; }

    public Monkey(Queue<long> startingItems, string opString, int testDivisor, int trueReceiver, int falseReceiver)
    {
        Items = startingItems;
        Operation = new MonkeyOp(opString);
        TestDivisor = testDivisor;
        TrueReceiver = trueReceiver;
        FalseReceiver = falseReceiver;
    }

    public void TakeTurn()
    {
        while (Items.Count > 0)
        {
            long worryLevel = Items.Dequeue();
            worryLevel = Inspect(worryLevel);
            worryLevel /= 3;
            if (Test(worryLevel)) Throw(TrueReceiver, worryLevel);
            else Throw(FalseReceiver, worryLevel);
        }
    }

    public long Inspect(long worryLevel)
    {
        Business++;
        return Operation.OperateOn(worryLevel);
    }

    public bool Test(long worryLevel) => worryLevel % TestDivisor == 0;

    private void Throw(int target, long worryLevel)
    {
        Watcher.ProcessThrow(target, worryLevel);
    }

    public void Catch(long worryLevel) => Items.Enqueue(worryLevel);

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("Monkey with:");
        sb.Append("Items: ");
        foreach (int item in Items)
        {
            sb.Append(item + ", ");
        }
        sb.Remove(sb.Length - 3, 2);
        sb.AppendLine();
        sb.AppendLine($"Operation: {Operation}");
        sb.AppendLine($"Test: {TestDivisor}");
        sb.AppendLine($"True receiver: {TrueReceiver}");
        sb.AppendLine($"False receiver: {FalseReceiver}");
        return sb.ToString();
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as Monkey);
    }

    public bool Equals(Monkey? other)
    {
        return other is not null &&
               Items.SequenceEqual(other.Items) &&
               Operation == other.Operation &&
               TestDivisor == other.TestDivisor &&
               TrueReceiver == other.TrueReceiver &&
               FalseReceiver == other.FalseReceiver;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Items, Operation, TestDivisor, TrueReceiver, FalseReceiver);
    }

    public void AddWatcher(Watcher watcher)
    {
        Watcher = watcher;
    }

    public static bool operator ==(Monkey? left, Monkey? right)
    {
        {
            if (left is null)
            {
                if (right is null)
                {
                    return true;
                }

                return false;
            }
            // Equals handles case of null on right side.
            return left.Equals(right);
        };
    }

    public static bool operator !=(Monkey? left, Monkey? right)
    {
        return !(left == right);
    }
}

public class MonkeyOp : IEquatable<MonkeyOp?>
{
    public Func<long, long> Operation { get; }
    public string OpString { get; }

    public MonkeyOp(string opString)
    {
        OpString = opString;
        Operation = ParseOperation(OpString);
    }

    internal Func<long, long> ParseOperation(string opString)
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

    internal long OperateOn(long worryLevel)
    {
        return Operation(worryLevel);
    }

    public override string ToString()
    {
        return OpString;
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as MonkeyOp);
    }

    public bool Equals(MonkeyOp? other)
    {
        return other is not null &&
               OpString == other.OpString;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(OpString);
    }

    internal static class OperationBuilder
    {
        internal static Func<long, long> Add(string other)
        {
            if (other == "old") return i => i + i;
            else if (long.TryParse(other, out long result)) return i => i + result;
            else throw new ArgumentException(@"Argument must be a string representation of an integer or 'old'");
        }

        internal static Func<long, long> Mul(string other)
        {
            if (other == "old") return i => i * i;
            else if (long.TryParse(other, out long result)) return i => i * result;
            else throw new ArgumentException(@"Argument must be a string representation of an integer or 'old'");
        }
    }

    public static bool operator ==(MonkeyOp? left, MonkeyOp? right)
    {
        {
            if (left is null)
            {
                if (right is null)
                {
                    return true;
                }

                return false;
            }
            // Equals handles case of null on right side.
            return left.Equals(right);
        };
    }

    public static bool operator !=(MonkeyOp? left, MonkeyOp? right)
    {
        return !(left == right);
    }
}
