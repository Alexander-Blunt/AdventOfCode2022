using AOCSharedMethods;
using System.Text;

namespace Day11App;

public class Program
{
    static void Main(string[] args)
    {
        // Read input file
        string fileLocation = InputProcessing.GetInputFilePath("Day11App", "Day11Input.txt");
        string rawString = File.ReadAllText(fileLocation);

        // Set up watcher and monkeys
        string[] monkeyStrings = rawString.Split("Monkey ", StringSplitOptions.RemoveEmptyEntries);
        Watcher watcher = new(new MonkeyDeserialiser());
        foreach (string monkeyString in monkeyStrings)
        {
            watcher.AddMonkeyFromString(monkeyString);
        }

        // Perform 20 rounds and collect results
        watcher.ObserveRounds(20);
        int[] monkeyBusiness = watcher.GetMonkeyBusiness();
        var businessList = monkeyBusiness.ToList();
        businessList.Sort();
        int businessTotal = businessList.Last() * businessList[^2];

        // Output results
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
        Console.WriteLine($"Total Monkey Business : {businessTotal}");

        // Reset watcher
        watcher = new(new MonkeyDeserialiser());
        foreach (string monkeyString in monkeyStrings)
        {
            watcher.AddMonkeyFromString(monkeyString);
        }

        // Perform 10000 rounds with overflow mitigation and collect results
        watcher.ObserveRounds(10000, false);
        monkeyBusiness = watcher.GetMonkeyBusiness();
        businessList = monkeyBusiness.ToList();
        businessList.Sort();
            long p2BusinessTotal = (long)businessList.Last() * (long)businessList[^2];

        // Output results
        sb.Clear();
        sb.AppendLine("Monkey Business Values:");
        sb.Append("{ ");
        foreach (int num in monkeyBusiness)
        {
            sb.Append($"{num}, ");
        }
        sb.Remove(sb.Length - 3, 1);
        sb.AppendLine("}");
        Console.WriteLine(sb.ToString());
        Console.WriteLine($"Total Monkey Business : {p2BusinessTotal}");
    }
}