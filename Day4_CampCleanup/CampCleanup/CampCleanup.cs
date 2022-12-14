using System.Runtime.CompilerServices;

namespace Camp;

public class Cleanup
{
    static void Main(string[] args)
    {
        string fileLocation = "C:\\Users\\Spore\\source\\repos\\AdventOfCode2022\\Day4_CampCleanup\\Day4Input.txt";
        Console.WriteLine(SumOfFullyContainedAssignments(fileLocation));

    }

    public static int SumOfFullyContainedAssignments(string fileLocation)
    {
        int sum = 0;
        foreach (string assignmentPair in File.ReadLines(fileLocation))
        {
            if (OneAssignmentFullyContainsTheOther(assignmentPair)) sum++;
        }
        return sum;
    }

    public static bool OneAssignmentFullyContainsTheOther(string assignmentPair)
    {
        string[] splitAssignments = assignmentPair.Split(",");

        var firstBounds = ParseAssignmentToUpperAndLowerBounds(splitAssignments[0]);
        var secondBounds = ParseAssignmentToUpperAndLowerBounds(splitAssignments[1]);
        // Check if one set of bounds fully contains the other.
        return firstBounds.lower <= secondBounds.lower && firstBounds.upper >= secondBounds.upper || secondBounds.lower <= firstBounds.lower && secondBounds.upper >= firstBounds.upper;
    }

    public static (int upper, int lower) ParseAssignmentToUpperAndLowerBounds(string bound)
    {
        string[] splitBounds = bound.Split("-");
        int[] intBounds =
        {
            Int32.Parse(splitBounds[0]),
            Int32.Parse(splitBounds[1])
        };
        return (intBounds[0], intBounds[1]);
    }
}