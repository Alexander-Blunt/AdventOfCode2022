using System.Reflection.Emit;

namespace Day11App;

public class MonkeyDeserialiser
{
    public Queue<long> DeserialiseStartingItems(string itemsLine)
    {
        long[] itemArray = itemsLine.Split(", ").Select(s => long.Parse(s)).ToArray();

        return new Queue<long>(itemArray);
    }

    public Monkey DeserialiseMonkey(string monkeyString)
    {
        string[] propertyStrings = monkeyString.Split(new string[] { ":", "\n" }, StringSplitOptions.TrimEntries);
        var items = DeserialiseStartingItems(propertyStrings[3]);
        var operation = propertyStrings[5];
        var testDivisor = DeserialiseTest(propertyStrings[7]);
        int trueReceiver = int.Parse(propertyStrings[9].Split(' ').Last());
        int falseReceiver = int.Parse(propertyStrings[11].Split(' ').Last());
        return new Monkey(items, operation, testDivisor, trueReceiver, falseReceiver);
    }

    public int DeserialiseTest(string testString)
    {
        if (!testString.Contains("divisible by ") ||
                !int.TryParse(testString.Split(' ').Last(), out int divisor))
        {
            throw new ArgumentException("Test must be in format 'divisible by x where x is an integer");
        }
        else
        {
            return divisor;
        }
    }
}