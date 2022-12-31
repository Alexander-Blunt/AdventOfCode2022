using TreetopTreeHouse;

namespace TreetopTreeHouseTests;

public class GroveTests
{
    [TestCase(0, 3, true)]
    [TestCase(3, 0, true)]
    [TestCase(0, 4, true)]
    [TestCase(4, 0, true)]
    [TestCase(1, 1, true)]
    [TestCase(2, 2, false)]
    [TestCase(1, 3, false)]
    public void GivenATreeGridPosition_IsTreeVisible_ReturnsTreeVisibility(int x, int y, bool expected)
    {
        int[,] intGrid =
        {
            { 3, 0, 3, 7, 3 },
            { 2, 5, 5, 1, 2 },
            { 6, 5, 3, 3, 2 },
            { 3, 3, 5, 4, 9 },
            { 3, 5, 3, 9, 0 }
        };
        Grove treeGrid = new(intGrid);

        bool output = treeGrid.TreeIsVisible(x, y);

        Assert.That(output, Is.EqualTo(expected));
    }
}