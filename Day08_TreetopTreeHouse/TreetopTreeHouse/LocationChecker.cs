using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography.X509Certificates;
using static System.Formats.Asn1.AsnWriter;
using AOCSharedMethods;

namespace TreetopTreeHouse;

public class Grove
{
    public int[,] TreeGrid { get; set; }

    public Grove(int[,] intGrid)
    {
        TreeGrid = intGrid;
    }

    private bool TreeIsVisibleFrom(int xLocation, int yLocation, string direction)
    {
        int start = 0;
        int finish = 0;
        ref int xOfTreeToCompare = ref xLocation;
        ref int yOfTreeToCompare = ref yLocation;
        int i = 0;
        switch (direction.ToLower())
        {
            case "left":
                finish = xLocation;
                xOfTreeToCompare = ref i;
                break;
            case "right":
                start = xLocation + 1;
                finish = TreeGrid.GetLength(0);
                xOfTreeToCompare = ref i;
                break;
            case "up":
                finish = yLocation;
                yOfTreeToCompare = ref i;
                break;
            case "down":
                start = yLocation + 1;
                finish = TreeGrid.GetLength(1);
                yOfTreeToCompare = ref i;
                break;
            default:
                throw new ArgumentException("Direction must be one of the following: \"left\", \"right\", \"up\" or \"down\".");
        }

        for (i = start; i < finish; i++)
        {
            if (TreeGrid[xOfTreeToCompare, yOfTreeToCompare] >= TreeGrid[xLocation, yLocation])
            {
                return false;
            }
        }
        return true;
    }

    public bool TreeIsVisible(int xLocation, int yLocation)
    {
        if (xLocation == 0 || xLocation == TreeGrid.GetLength(0) - 1 || yLocation == 0 || yLocation == TreeGrid.GetLength(1) - 1)
        {
            return true;
        }
        else if (
            TreeIsVisibleFrom(xLocation, yLocation, "left") ||
            TreeIsVisibleFrom(xLocation, yLocation, "right") ||
            TreeIsVisibleFrom(xLocation, yLocation, "up") ||
            TreeIsVisibleFrom(xLocation, yLocation, "down"))
        {
            return true;
        }
        else return false;
    }

    public int GetScenicScore(int xLocation, int yLocation)
    {
        //Get left score
        int leftScore = 0;
        for (int k = xLocation - 1; k >= 0; k--)
        {
            leftScore++;
            if (TreeGrid[k, yLocation] >= TreeGrid[xLocation, yLocation])
            {
                break;
            }
        }

        //Get right score
        int rightScore = 0;
        for (int k = xLocation + 1; k < TreeGrid.GetLength(0); k++)
        {
            rightScore++;
            if (TreeGrid[k, yLocation] >= TreeGrid[xLocation, yLocation])
            {
                break;
            }
        }

        //Get up score
        int upScore = 0;
        for (int k = yLocation - 1; k >= 0; k--)
        {
            upScore++;
            if (TreeGrid[xLocation, k] >= TreeGrid[xLocation, yLocation])
            {
                break;
            }
        }

        //Get down score
        int downScore = 0;
        for (int k = yLocation + 1; k < TreeGrid.GetLength(1); k++)
        {
            downScore++;
            if (TreeGrid[xLocation, k] >= TreeGrid[xLocation, yLocation])
            {
                break;
            }
        }
        return leftScore * rightScore * upScore * downScore;
    }
}

public class Program
{
    static void Main(string[] args)
    {
        string inputLocation = InputProcessing.GetInputFilePath(@"\TreetopTreeHouse", "Day8Input.txt");
        string[] inputArray = File.ReadAllLines(inputLocation);

        int xLength = inputArray.Length;
        int yLength = inputArray[0].Length;
        int[,] intGrid = new int[xLength, yLength];

        for (int i = 0; i < xLength; i++)
        {
            for (int j = 0; j < yLength; j++)
            {
                intGrid[i, j] = int.Parse(inputArray[i][j].ToString());
            }
        }

        Grove inputGrove = new(intGrid);
        int sumOfVisibleTrees = 0;
        for (int i = 0; i < xLength; i++)
        {
            for (int j = 0; j < yLength; j++)
            {
                if (inputGrove.TreeIsVisible(i, j)) sumOfVisibleTrees++;
            }
        }

        Console.WriteLine(sumOfVisibleTrees);

        int highestScenicScore = 0;
        for (int i = 0; i < xLength; i++)
        {
            for (int j = 0; j < yLength; j++)
            {
                int scenicScore = inputGrove.GetScenicScore(i, j);
                if (scenicScore > highestScenicScore)
                {
                    highestScenicScore = scenicScore;
                }
            }
        }

        Console.WriteLine(highestScenicScore);
    }
}