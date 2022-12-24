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

    [Test]
    public void GivenADirectory_ChangeDirectory_ReturnsCorrectDirectory()
    {
        testRoot.Add("a");
        ChildDirectory expected = (ChildDirectory) testRoot.Contents["a"];

        ChildDirectory output = (ChildDirectory) testRoot.ChangeDirectory("a");

        Assert.That(output, Is.EqualTo(expected));
    }

    [Test]
    public void GivenAChildDirectory_ChangeDirectoryTwoDots_ReturnsParentDirectory()
    {
        testRoot.Add("a");
        DirectoryItem expected = testRoot;

        DirectoryItem childDirectory = (DirectoryItem) testRoot.Contents["a"];
        DirectoryItem output = childDirectory.ChangeDirectory("..");

        Assert.That(output, Is.EqualTo(expected));
    }
}