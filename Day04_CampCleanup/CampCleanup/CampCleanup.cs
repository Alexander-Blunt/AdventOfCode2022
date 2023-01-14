using AOCSharedMethods;
using System.Runtime.CompilerServices;

namespace Camp;

public class Cleanup
{
    static void Main(string[] args)
    {
        string fileLocation = InputProcessing.GetInputFilePath("\\CampCleanup", "Day4Input.txt");
        Console.WriteLine(SumOfFullyContainedAssignments(fileLocation));
        Console.WriteLine(SumOfOverlappingAssignments(fileLocation));
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

    public static int SumOfOverlappingAssignments(string fileLocation)
    {
        int sum = 0;
        foreach (string assignmentPair in File.ReadLines(fileLocation))
        {
            if (AssignmentsOverlap(assignmentPair)) sum++;
        }
        return sum;
    }

    public static bool AssignmentsOverlap(string assignmentPair)
    {
        GetBoundsForEachAssignment(assignmentPair, out var firstBounds, out var secondBounds);
        return !(firstBounds.lower > secondBounds.upper || firstBounds.upper < secondBounds.lower);
    }

    public static bool OneAssignmentFullyContainsTheOther(string assignmentPair)
    {
        GetBoundsForEachAssignment(assignmentPair, out var firstBounds, out var secondBounds);
        bool firstContainsAllSecond = firstBounds.lower <= secondBounds.lower && secondBounds.upper <= firstBounds.upper;
        bool secondContainsAllFirst = secondBounds.lower <= firstBounds.lower && firstBounds.upper <= secondBounds.upper;
        return firstContainsAllSecond || secondContainsAllFirst;
    }

    public static void GetBoundsForEachAssignment(string assignmentPair, out (int lower, int upper) firstBounds, out (int lower, int upper) secondBounds)
    {
        string[] splitAssignments = assignmentPair.Split(",");

        firstBounds = ParseAssignmentToUpperAndLowerBounds(splitAssignments[0]);
        secondBounds = ParseAssignmentToUpperAndLowerBounds(splitAssignments[1]);
    }

    public static (int lower, int upper) ParseAssignmentToUpperAndLowerBounds(string bound)
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