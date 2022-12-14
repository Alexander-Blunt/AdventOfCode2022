using System.Globalization;
using System.Runtime.CompilerServices;

namespace Day1_CalorieCounting;

public class CalorieCounting
{
    static void Main(string[] args)
    {
        string fileLocation = "..\\..\\..\\Day1Input.txt";
        Console.WriteLine(FindHighestCalorieTotal(fileLocation));
        Console.WriteLine(FindTotalOfHighetThree(fileLocation));
    }

    public static int FindHighestCalorieTotal(string fileLocation)
    {
        List<int> totalCaloriesForEachElf = GetCaloriesForEachElf(fileLocation);

        int highest = totalCaloriesForEachElf[0];
        for (int i = 1; i < totalCaloriesForEachElf.Count; i++)
        {
            if (highest < totalCaloriesForEachElf[i]) highest = totalCaloriesForEachElf[i];
        }
        return highest;
    }

    public static int FindTotalOfHighetThree(string fileLocation)
    {
        List<int> totalCaloriesForEachElf = GetCaloriesForEachElf(fileLocation);

        int[] highestThree = { totalCaloriesForEachElf[0], 0, 0 };
        for (int i = 1; i < totalCaloriesForEachElf.Count; i++)
        {
            if (highestThree[0] < totalCaloriesForEachElf[i])
            {
                highestThree[2] = highestThree[1];
                highestThree[1] = highestThree[0];
                highestThree[0] = totalCaloriesForEachElf[i];
            }
            else if (highestThree[1] < totalCaloriesForEachElf[i])
            {
                highestThree[2] = highestThree[1];
                highestThree[1] = totalCaloriesForEachElf[i];
            }
            else if (highestThree[2] < totalCaloriesForEachElf[i])
            {
                highestThree[2] = totalCaloriesForEachElf[i];
            }
        }
        return highestThree.Sum();
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