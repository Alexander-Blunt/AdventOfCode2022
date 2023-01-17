using AOCSharedMethods;

namespace CathodeRayTube;

public class Program
{
    static void Main(string[] args)
    {
        string fileLocation = InputProcessing.GetInputFilePath(@"\CathodeRayTube", "Day10Input.txt");

        string[] input = File.ReadAllLines(fileLocation);

        CPU cPU = new();
        SignalStrengthMonitor signalStrengthMonitor = new();
        cPU.ConnectMonitor(signalStrengthMonitor);
        CRT cRT = new();
        cPU.ConnectMonitor(cRT);

        foreach (string line in input)
        {
            if (line == "noop") cPU.Noop();
            else
            {
                int value = int.Parse(line.Substring(5));
                cPU.AddX(value);
            }
        }

        Console.WriteLine($"Signal Strength = {signalStrengthMonitor.SignalStrength}");
        
        foreach (string line in cRT.Screen)
        {
            Console.WriteLine(line);
        }
    }
}