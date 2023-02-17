using AOCSharedMethods;

namespace HillClimbingAlgorithm;

internal class Program
{
    static void Main(string[] args)
    {
        string fileLocation = InputProcessing.GetInputFilePath("HillClimbingAlgorithm", "Day12Input.txt");
        string[] startMap = File.ReadAllLines(fileLocation);

        RouteFinder routeFinder = new(startMap);
        int shortestSteps = routeFinder.GetNumberOfStepsFromSToF();
        Console.WriteLine(shortestSteps);
    }
}