using System.Globalization;
using System.Runtime.CompilerServices;

namespace Day1_CalorieCounting;

public class CalorieCounting
{
    static void Main(string[] args)
    {
        string fileLocation = "..\\..\\..\\Day1Input.txt";
        Console.WriteLine(FindHighestCalories(fileLocation));
    }

    // Create file stream.
    // Read file one line at a time, adding to an array representing the total of each elf.
    // Find highest total and return it.
    public static int FindHighestCalories(string fileLocation)
    {
        List<int> totalCaloriesForEachElf = GetCaloriesForEachElf(fileLocation);

        int highest = totalCaloriesForEachElf[0];
        for (int i = 1; i < totalCaloriesForEachElf.Count; i++)
        {
            if (highest < totalCaloriesForEachElf[i]) highest = totalCaloriesForEachElf[i];
        }
        return highest;
    }

    public static List<int> GetCaloriesForEachElf(string fileLocation)
    {
        List<int> outputList = new();
        outputList.Add(0);
        int index = 0;
        foreach (string line in File.ReadLines(fileLocation))
        {
            if (!String.IsNullOrEmpty(line)) outputList[index] += Int32.Parse(line);
            else
            {
                outputList.Add(0);
                index++;
            }
        }
        return outputList;

    }
}