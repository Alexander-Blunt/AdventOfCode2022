using System.Security.Cryptography.X509Certificates;

namespace Day5SupplyStacks
{
    public class Program
    {
        static void Main(string[] args)
        {
            string fileLocation = "C:\\Users\\Spore\\source\\repos\\AdventOfCode2022\\Day5_SupplyStacks\\SupplyStacks\\Day5Input.txt";
            Console.WriteLine("Hello, World!");
        }
    }

    public class SupplyStacks
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
        // Setup the stacks
        public static List<Stack<char>> ConvertDiagramToStacks(List<string> diagram)
        {
            // Get Number of stacks, Equal to number of characters in last line once spaces are removed.
            string lastLineOfDiagram = diagram.Last();
            int numOfStacks = lastLineOfDiagram.Length / 4 + 1;
            List<Stack<char>> stacks = new();
            for (int i = 0; i < numOfStacks; i++)
            {
                stacks.Add(new());
            }
            // Loop through each line of the diagram from the bottom up, ignoring the bottom line.
            for (int rowIndex = diagram.Count - 2; rowIndex >= 0; rowIndex--)
            {
                for (int columnIndex = 1; columnIndex < diagram[rowIndex].Length; columnIndex += 4)
                {
                    int stackNumber = (columnIndex - 1) / 4;
                    if (diagram[rowIndex][columnIndex] != ' ')
                    {
                        stacks[stackNumber].Push(diagram[rowIndex][columnIndex]);
                    }
                }
            }
            return stacks;

        }
        // Read each line
        // Convert diagram to an array of stacks
        // Rest of file is instructions
        // Parse the instructions
        // Perform instructions
        // move instruction takes in from and to
    }
}