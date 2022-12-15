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
        // Setup the stacks
        // Read each line
        // Convert lines up to blank (diagram) to an array of lists?
        // Rest of file is instructions
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
        // Parse the instructions
        // Perform instructions
        // move instruction takes in from and to.
    }
}