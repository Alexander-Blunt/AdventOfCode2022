using AOCSharedMethods;
using System.Text;

namespace Day11App;

public class Program
{
    static void Main(string[] args)
    {
        Watcher watcher = new(new MonkeyDeserialiser());
        string rawString = File.ReadAllText(InputProcessing.GetInputFilePath("Day11App", "Day11Input.txt"));
        string[] monkeyStrings = rawString.Split("Monkey ", StringSplitOptions.RemoveEmptyEntries);
        foreach (string monkeyString in monkeyStrings)
        {
            watcher.AddMonkeyFromString(monkeyString);
        }

        watcher.ObserveRounds(20);
        int[] monkeyBusiness = watcher.GetMonkeyBusiness();
        StringBuilder sb = new();
        sb.AppendLine("Monkey Business Values:");
        sb.Append("{ ");
        foreach (int num in monkeyBusiness)
        {
            sb.Append($"{num}, ");
        }
        sb.Remove(sb.Length - 3, 1);
        sb.AppendLine("}");
        Console.WriteLine(sb.ToString());

        var businessList = monkeyBusiness.ToList();
        businessList.Sort();
        int businessTotal = businessList.Last() * businessList[^2];
        Console.WriteLine($"Total Monkey Business : {businessTotal}");
    }
}