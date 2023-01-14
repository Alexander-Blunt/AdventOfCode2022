using Day5SupplyStacks;

namespace Day5SupplyStacksTests
{
    public class SupplyStackTests
    {

        string[] input =
          { "    [D]    ",
            "[N] [C]    ",
            "[Z] [M] [P]",
            " 1   2   3 ",
            "",
            "move 1 from 2 to 1",
            "move 3 from 1 to 3",
            "move 2 from 2 to 1",
            "move 1 from 1 to 2" };
        List<string> expectedDiagram = new()
          { "    [D]    ",
            "[N] [C]    ",
            "[Z] [M] [P]",
            " 1   2   3 " };
        List<string> expectedInstructions = new()
          { "move 1 from 2 to 1",
            "move 3 from 1 to 3",
            "move 2 from 2 to 1",
            "move 1 from 1 to 2" };
        int[,] expectedParsedInstructions = 
          { { 1, 2, 1 },
            { 3, 1, 3 },
            { 2, 2, 1 },
            { 1, 1, 2 } };

        [Test]
        public void ValidInput_SplitInputIntoDiagramAndInstructions_ReturnsCorrectDiagram()
        {
            InputProcessing.SplitInputIntoDiagramAndInstructions(input, out var diagram, out var instructions);
            Assert.That(diagram, Is.EqualTo(expectedDiagram), "Diagram is different from expected");
        }

        [Test]
        public void ValidInput_SplitInputIntoDiagramAndInstructions_ReturnsCorrectInstructions()
        {
            InputProcessing.SplitInputIntoDiagramAndInstructions(input, out var diagram, out var instructions);
            Assert.That(instructions, Is.EqualTo(expectedInstructions), "Diagram is different from expected");
        }

        [Test]
        public void ValidInput_ConvertDiagramToStacks_ReturnsCorrectStacks()
        {
            List<Stack<char>> expectedInitialStacks = new()
        { new("ZN"), new("MCD"), new("P") };
            SupplyStacks testStack = new(expectedDiagram);
            Assert.That(testStack.StackList, Is.EqualTo(expectedInitialStacks));
        }

        [Test]
        public void ValidInput_ParseInstructions_RetrunsCorrectInstructions()
        {
            Assert.That(InputProcessing.ParseInstructions(expectedInstructions), Is.EqualTo(expectedParsedInstructions));
        }

        [Test]
        public void ValidInput_FollowInstruction9000_CorrectlyAltersStacks()
        {
            //Arrange
            List<Stack<char>> stackList = new()
        { new("ZN"), new("MCD"), new("P") };
            SupplyStacks inputSupplyStacks = new(stackList);
            int[] inputInstruction = { 2, 2, 1 };
            List<Stack<char>> expectedFinalStacks = new() { new("ZNDC"), new("M"), new("P") };

            //Act
            inputSupplyStacks.FollowInstruction9000(inputInstruction);

            Assert.That(inputSupplyStacks.StackList, Is.EqualTo(expectedFinalStacks));
        }

        [Test]
        public void ValidInput_FollowInstruction9001_CorrectlyAltersStacks()
        {
            //Arrange
            List<Stack<char>> stackList = new()
        { new("ZN"), new("MCD"), new("P") };
            SupplyStacks inputSupplyStacks = new(stackList);
            int[] inputInstruction = { 2, 2, 1 };
            List<Stack<char>> expectedFinalStacks = new() { new("ZNCD"), new("M"), new("P") };

            //Act
            inputSupplyStacks.FollowInstruction9001(inputInstruction);

            Assert.That(inputSupplyStacks.StackList, Is.EqualTo(expectedFinalStacks));
        }
    }
}