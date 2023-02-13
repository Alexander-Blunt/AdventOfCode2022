using System.Reflection.Emit;

namespace Day11App;

public class MonkeyDeserialiser
{
    public Queue<int> DeserialiseStartingItems(string itemsLine)
    {
        int[] itemArray = itemsLine.Split(", ").Select(s => int.Parse(s)).ToArray<int>();

        return new Queue<int>(itemArray);
    }

    public Monkey DeserialiseMonkey(string monkeyString)
    {
        string[] propertyStrings = monkeyString.Split(new string[] { ":", "\n" }, StringSplitOptions.TrimEntries);
        var items = DeserialiseStartingItems(propertyStrings[3]);
        var operation = propertyStrings[5];
        var test = propertyStrings[7];
        int trueReceiver = int.Parse(propertyStrings[9].Split(' ').Last());
        int falseReceiver = int.Parse(propertyStrings[11].Split(' ').Last());
        return new Monkey(items, operation, test, trueReceiver, falseReceiver);
    }
}