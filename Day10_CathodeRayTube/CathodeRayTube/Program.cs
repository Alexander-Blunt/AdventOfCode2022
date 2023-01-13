namespace CathodeRayTube;

public class Program
{
    static void Main(string[] args)
    {
        string fileLocation = GetInputFilePath(@"\CathodeRayTube", "Day10Input.txt");

        string[] input = File.ReadAllLines(fileLocation);

        CPU cPU = new();
        SignalStrengthMonitor signalStrengthMonitor = new();
        cPU.ConnectMonitor(signalStrengthMonitor);

        foreach (string line in input)
        {
            if (line == "noop") cPU.Noop();
            else
            {
                int value = int.Parse(line.Substring(5));
                cPU.AddX(value);
            }
        }

        Console.WriteLine(signalStrengthMonitor.SignalStrength);
    }

    public static string GetInputFilePath(string parentDirName, string fileName)
    {
        string currentDirectory = Directory.GetCurrentDirectory();
        int parentDirIndex = currentDirectory.LastIndexOf(parentDirName);
        int lengthOfParentDirPath = parentDirName.Length + parentDirIndex;
        string fullParentPath = currentDirectory.Substring(0, lengthOfParentDirPath);

        string filePath = fullParentPath + @"\" + fileName;

        if (File.Exists(filePath)) return filePath;
        else throw new FileNotFoundException();
    }
}