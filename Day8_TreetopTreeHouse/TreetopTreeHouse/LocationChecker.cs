using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography.X509Certificates;
using static System.Formats.Asn1.AsnWriter;

namespace TreetopTreeHouse;

public class Grove
{
    public int[,] TreeGrid { get; set; }

    public Grove(int[,] intGrid)
    {
        TreeGrid = intGrid;
    }

    public bool TreeIsVisible(int xLocation, int yLocation)
    {
        if (xLocation == 0 || xLocation == TreeGrid.GetLength(0) - 1 || yLocation == 0 || yLocation == TreeGrid.GetLength(1) - 1)
        {
            return true;
        }
        else
        {
            //Check Left
            bool isVisible = true;
            for (int k = xLocation - 1; k >= 0; k--)
            {
                if (TreeGrid[k, yLocation] >= TreeGrid[xLocation, yLocation])
                {
                    isVisible = false;
                    break;
                }
            }
            if (isVisible)
            {
                return true;
            }

            //Check Right
            isVisible = true;
            for (int k = xLocation + 1; k < TreeGrid.GetLength(0); k++)
            {
                if (TreeGrid[k, yLocation] >= TreeGrid[xLocation, yLocation])
                {
                    isVisible = false;
                    break;
                }
            }
            if (isVisible)
            {
                return true;
            }

            //Check Up
            isVisible = true;
            for (int k = yLocation - 1; k >= 0; k--)
            {
                if (TreeGrid[xLocation, k] >= TreeGrid[xLocation, yLocation])
                {
                    isVisible = false;
                    break;
                }
            }
            if (isVisible)
            {
                return true;
            }

            //Check Down
            isVisible = true;
            for (int k = yLocation + 1; k < TreeGrid.GetLength(1); k++)
            {
                if (TreeGrid[xLocation, k] >= TreeGrid[xLocation, yLocation])
                {
                    isVisible = false;
                    break;
                }
            }
            if (isVisible)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
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
        string inputLocation = @"C:\Users\Spore\source\repos\AdventOfCode2022\Day8_TreetopTreeHouse\TreetopTreeHouse\Day8Input.txt";
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