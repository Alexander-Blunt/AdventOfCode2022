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
            SupplyStacks.SplitInputIntoDiagramAndInstructions(input, out var diagram, out var instructions);
            Assert.That(diagram, Is.EqualTo(expectedDiagram), "Diagram is different from expected");
        }

        [Test]
        public void ValidInput_SplitInputIntoDiagramAndInstructions_ReturnsCorrectInstructions()
        {
            SupplyStacks.SplitInputIntoDiagramAndInstructions(input, out var diagram, out var instructions);
            Assert.That(instructions, Is.EqualTo(expectedInstructions), "Diagram is different from expected");
        }

        [Test]
        public void ValidInput_ConvertDiagramToStacks_ReturnsCorrectStacks()
        {
            List<Stack<char>> expectedInitialStacks = new()
        { new("ZN"), new("MCD"), new("P") };
            Assert.That(SupplyStacks.ConvertDiagramToStacks(expectedDiagram), Is.EqualTo(expectedInitialStacks));
        }

        [Test]
        public void ValidInput_ParseInstructions_RetrunsCorrectInstructions()
        {
            Assert.That(SupplyStacks.ParseInstructions(expectedInstructions), Is.EqualTo(expectedParsedInstructions));
        }

        [Test]
        public void ValidInput_FollowInstruction9000_CorrectlyAltersStacks()
        {
            //Arrange
            List<Stack<char>> inputStacks = new()
        { new("ZN"), new("MCD"), new("P") }; ;
            int[] inputInstruction = { 2, 2, 1 };
            List<Stack<char>> expectedFinalStacks = new() { new("ZNDC"), new("M"), new("P") };

            //Act
            SupplyStacks.FollowInstruction9000(inputInstruction, ref inputStacks);

            Assert.That(inputStacks, Is.EqualTo(expectedFinalStacks));
        }

        [Test]
        public void ValidInput_FollowInstruction9001_CorrectlyAltersStacks()
        {
            //Arrange
            List<Stack<char>> inputStacks = new()
        { new("ZN"), new("MCD"), new("P") }; ;
            int[] inputInstruction = { 2, 2, 1 };
            List<Stack<char>> expectedFinalStacks = new() { new("ZNCD"), new("M"), new("P") };

            //Act
            SupplyStacks.FollowInstruction9001(inputInstruction, ref inputStacks);

            Assert.That(inputStacks, Is.EqualTo(expectedFinalStacks));
        }
    }
}