namespace TuningTrouble;
using AOCSharedMethods;

public class CommunicationSystem
{
    static void Main(string[] args)
    {
        string fileLocation = InputProcessing.GetInputFilePath("\\TuningTrouble", "Day6Input.txt");
        string datastreamBuffer = File.ReadAllText(fileLocation);
        Console.WriteLine(FindStartOfPacket(datastreamBuffer));
        Console.WriteLine(FindStartOfMessage(datastreamBuffer));
    }

    public static int FindStartOfPacket(string datastreamBuffer)
    {
        string startingFour = datastreamBuffer.Substring(0, 4);
        Queue<char> packetQueue = new(startingFour);

        int bufferIndex;
        for (bufferIndex = 4; bufferIndex < datastreamBuffer.Length; bufferIndex++)
        {
            bool foundDuplicate = true;
            Queue<char> comparisonQueue = new(packetQueue);
            for (int i = 0; i < packetQueue.Count - 1; i++)
            {
                char comparisonChar = comparisonQueue.Dequeue();
                if (comparisonQueue.Contains(comparisonChar))
                {
                    foundDuplicate = true;
                    break;
                }
                else
                {
                    foundDuplicate = false;
                }
            }
            if (foundDuplicate)
            {
                packetQueue.Dequeue();
                packetQueue.Enqueue(datastreamBuffer[bufferIndex]);
            }
            else
            {
                break;
            }
        }
        return bufferIndex;
    }

    public static int FindStartOfMessage(string datastreamBuffer)
    {
        string startingFourteen = datastreamBuffer.Substring(0, 14);
        Queue<char> packetQueue = new(startingFourteen);

        int bufferIndex;
        for (bufferIndex = 14; bufferIndex < datastreamBuffer.Length; bufferIndex++)
        {
            bool foundDuplicate = true;
            Queue<char> comparisonQueue = new(packetQueue);
            for (int i = 0; i < packetQueue.Count - 1; i++)
            {
                char comparisonChar = comparisonQueue.Dequeue();
                if (comparisonQueue.Contains(comparisonChar))
                {
                    foundDuplicate = true;
                    break;
                }
                else
                {
                    foundDuplicate = false;
                }
            }
            if (foundDuplicate)
            {
                packetQueue.Dequeue();
                packetQueue.Enqueue(datastreamBuffer[bufferIndex]);
            }
            else
            {
                break;
            }
        }
        return bufferIndex;
    }
}