using Day5SupplyStacks;

namespace Day5SupplyStacksTests
{
    public class SupplyStackTests
    {
        [SetUp]
        public void Setup()
        {

        }

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
            List<string> inputDiagram = new()
              { "    [D]    ",
                "[N] [C]    ",
                "[Z] [M] [P]",
                " 1   2   3 " };
            List<Stack<char>> expectedStacks = new() { new("ZN"), new("MCD"), new("P") };
            Assert.That(SupplyStacks.ConvertDiagramToStacks(inputDiagram), Is.EqualTo(expectedStacks));
        }
    }
}