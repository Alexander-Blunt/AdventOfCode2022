using System.IO;

namespace RucksackReorganization;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(Rucksack.FindDuplicates(@"C:\Users\Spore\source\repos\AdventOfCode2022\Day3\ReorganizeRucksack\Day3input.txt"));
        Console.WriteLine(Rucksack.FindBadges(@"C:\Users\Spore\source\repos\AdventOfCode2022\Day3\ReorganizeRucksack\Day3input.txt"));
    }
}

public class Rucksack
{
    public int CompartmentSize { get; }
    public string Compartment1 { get; }
    public string Compartment2 { get; }

    Rucksack(string contents)
    {
        CompartmentSize = contents.Length / 2;
        Compartment1 = contents.Substring(0, CompartmentSize);
        Compartment2 = contents.Substring(CompartmentSize);
    }

    public static int GetPriority(char item)
    {
        string alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        int priority = 0;
        foreach (char letter in alphabet)
        {
            priority++;
            if (letter == item)
            {
                return priority;
            }
        }
        return 0;
    }
     public static int FindDuplicates(string fileLocation)
     {
        // create array of rucksacks
        string[] input = File.ReadAllLines(fileLocation);
        Rucksack[] sacks = new Rucksack[input.Length];
        for (int i = 0; i < input.Length; i++)
        {
            sacks[i] = new Rucksack(input[i]);
        }

        int finalSum = 0;
        foreach (Rucksack sack in sacks)
        {
            foreach (char item in sack.Compartment1)
            {
                if (sack.Compartment2.Contains(item))
                {
                    finalSum += GetPriority(item);
                    break;
                }
            }
        }
        return finalSum;
     }
    public static int FindBadges(string fileLocation)
    {
        string[] input = File.ReadAllLines(fileLocation);
        int finalSum = 0;
        for (int i = 0; i < input.Length; i+=3)
        {
            foreach (char item in input[i])
            {
                if (input[i + 1].Contains(item) && input[i + 2].Contains(item))
                {
                    finalSum += GetPriority(item);
                    break;
                }
            }
        }
        return finalSum;
    }
}
