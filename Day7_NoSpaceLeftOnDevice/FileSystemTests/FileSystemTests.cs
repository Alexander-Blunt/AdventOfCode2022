using FileSystem;

namespace FileSystemTests;

public class Tests
{
    DirectoryItem testRoot;

    [SetUp]
    public void Setup()
    {
        testRoot = new();
    }

    [Test]
    public void GivenADirectory_Size_ReturnsSumOfContents()
    {
        testRoot.Add("a");
        testRoot.Add("b", 10);
        testRoot.ChangeDirectory("a").Add("c", 10);

        int expected = 20;
        int output = testRoot.Size;

        Assert.That(output, Is.EqualTo(expected));
    }
}