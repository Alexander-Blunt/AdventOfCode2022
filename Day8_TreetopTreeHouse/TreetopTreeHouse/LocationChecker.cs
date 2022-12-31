using System.Diagnostics.CodeAnalysis;
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
            //Check East
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

            //Check West
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

            //Check North
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

            //Check South
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
    }
}