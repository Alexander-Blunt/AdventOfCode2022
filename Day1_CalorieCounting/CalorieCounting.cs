using System.Globalization;
using System.Runtime.CompilerServices;

namespace Day1_CalorieCounting;

public class CalorieCounting
{
    static void Main(string[] args)
    {
        string fileLocation = @"C:\Users\Spore\source\repos\AdventOfCode2022\Day1_CalorieCounting\Day1Input.txt";
        List<int> caloriesForEachElf = GetCaloriesForEachElf(fileLocation);

        Console.WriteLine(FindHighestCalorieTotal(caloriesForEachElf));
        Console.WriteLine(FindTotalOfHighetThree(caloriesForEachElf));
    }

    public static List<int> GetCaloriesForEachElf(string fileLocation)
    {
        List<int> caloriesForEachElf = new() { 0 };
        int elfNumber = 0;
        foreach (string line in File.ReadLines(fileLocation))
        {
            if (!String.IsNullOrEmpty(line)) caloriesForEachElf[elfNumber] += Int32.Parse(line);
            else
            {
                caloriesForEachElf.Add(0);
                elfNumber++;
            }
        }
        return caloriesForEachElf;
    }

    public static int FindHighestCalorieTotal(List<int> caloriesForEachElf)
    {
        int highest = caloriesForEachElf[0];
        // Used a for loop to avoid comparing the first item to itself.
        for (int i = 1; i < caloriesForEachElf.Count; i++)
        {
            if (highest < caloriesForEachElf[i]) highest = caloriesForEachElf[i];
        }
        return highest;
    }

    public static int FindTotalOfHighetThree(List<int> caloriesForEachElf)
    {
        // From highest to lowest.
        int[] highestThree = { caloriesForEachElf[0], 0, 0 };
        // Used a for loop to avoid comparing the first item to itself.
        for (int i = 1; i < caloriesForEachElf.Count; i++)
        {
            if (highestThree[0] < caloriesForEachElf[i])
            {
                highestThree[2] = highestThree[1];
                highestThree[1] = highestThree[0];
                highestThree[0] = caloriesForEachElf[i];
            }
            else if (highestThree[1] < caloriesForEachElf[i])
            {
                highestThree[2] = highestThree[1];
                highestThree[1] = caloriesForEachElf[i];
            }
            else if (highestThree[2] < caloriesForEachElf[i])
            {
                highestThree[2] = caloriesForEachElf[i];
            }
        }
        return highestThree.Sum();
    }
}