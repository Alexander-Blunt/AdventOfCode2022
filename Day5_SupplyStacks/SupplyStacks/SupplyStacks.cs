using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Day5SupplyStacks;

public class Program
{
    static void Main(string[] args)
    {
        string fileLocation = "C:\\Users\\Spore\\source\\repos\\AdventOfCode2022\\Day5_SupplyStacks\\SupplyStacks\\Day5Input.txt";
        string[] rawInput = File.ReadAllLines(fileLocation);

        InputProcessing.SplitInputIntoDiagramAndInstructions(rawInput, out var diagram, out var instructions);

        SupplyStacks cargoStacks = new(diagram);
        int[,] parsedInstructions = InputProcessing.ParseInstructions(instructions);
        
        for (int i = 0; i < parsedInstructions.GetLength(0); i++)
        {
            int[] instruction = { parsedInstructions[i, 0],
            parsedInstructions[i, 1], parsedInstructions[i, 2] };
            cargoStacks.FollowInstruction9001(instruction);
        }
        string output = "";
        foreach (Stack<char> stack in cargoStacks.StackList)
        {
            output += stack.First<char>();
        }

        Console.WriteLine(output);
    }
}

public class SupplyStacks
{
    public List<Stack<char>> StackList { get; }

    public SupplyStacks (List<string> diagram)
    {
        string lastLineOfDiagram = diagram.Last();
        int numOfStacks = lastLineOfDiagram.Length / 4 + 1;
        StackList = new();
        for (int i = 0; i < numOfStacks; i++)
        {
            StackList.Add(new());
        }
        // Loop through each line of the diagram from the bottom up, ignoring the bottom line.
        for (int rowIndex = diagram.Count - 2; rowIndex >= 0; rowIndex--)
        {
            for (int columnIndex = 1; columnIndex < diagram[rowIndex].Length; columnIndex += 4)
            {
                int stackNumber = (columnIndex - 1) / 4;
                if (diagram[rowIndex][columnIndex] != ' ')
                {
                    StackList[stackNumber].Push(diagram[rowIndex][columnIndex]);
                }
            }
        }
    }

    public SupplyStacks (List<Stack<char>> stackList)
    {
        StackList = stackList;
    }

    public void FollowInstruction9000(int[] instruction)
    {
        for (int i = 0; i < instruction[0]; i++)
        {
            char cargoToMove = StackList[instruction[1]-1].Pop();
            StackList[instruction[2]-1].Push(cargoToMove);
        }
    }

    public void FollowInstruction9001(int[] instruction)
    {
        Stack<char> cargoToMove = new("");
        for (int i = 0; i < instruction[0]; i++)
        {
            cargoToMove.Push(StackList[instruction[1] - 1].Pop());
        }

        for (int i = 0; i < instruction[0]; i++)
        {
            StackList[instruction[2] - 1].Push(cargoToMove.Pop());
        }
    }
}

public class InputProcessing
{
    public static void SplitInputIntoDiagramAndInstructions(string[] input, out List<string> diagram, out List<string> instructions)
    {
        instructions = new();
        diagram = new();
        for (int i = 0; i < input.Length; i++)
        {
            if (!String.IsNullOrEmpty(input[i]))
            {
                diagram.Add(input[i]);
            }
            else
            {
                i++;
                for (; i < input.Length; i++)
                {
                    instructions.Add(input[i]);
                }
            }
        }
    }

    public static int[,] ParseInstructions(List<string> instructions)
    {
        int[,] parsedInstructions = new int[instructions.Count, 3];
        for (int i = 0; i < instructions.Count; i++)
        {
            string[] splitLine = instructions[i].Split(' ');
            int j = 0;
            foreach (string word in splitLine)
            {
                // Filter numbers from each instruction line and convert to int32.
                if (int.TryParse(word, out int parsedWord))
                {
                    parsedInstructions[i, j] = parsedWord;
                    j++;
                }
            }
        }
        return parsedInstructions;
    }
}