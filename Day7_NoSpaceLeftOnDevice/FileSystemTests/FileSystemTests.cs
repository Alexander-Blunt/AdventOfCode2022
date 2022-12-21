using FileSystem;

namespace FileSystemTests;

public class Tests
{
    [Test]
    public void GivenAnInputString_FileItem_CreatesExpectedFile()
    {
        string[] sizeAndName = { "140", "AFile" };
        FileItem testFile = new(sizeAndName);

        Assert.That(testFile.Name, Is.EqualTo(sizeAndName[1]));
        Assert.That(testFile.Size, Is.EqualTo(140));
    }

    [Test]
    public void GivenAFile_Add_AddsTheFileToADirectoryCorrectly()
    {
        DirectoryItem testDirectory = new("/");
        string[] fileDetails = { "14848514", "b.txt" };
        FileItem expectedFile = new(fileDetails);
        string lsLine = "14848514 b.txt";

        testDirectory.Add(lsLine);

        Assert.That(testDirectory.Contents[0].Size, Is.EqualTo(expectedFile.Size));
        Assert.That(testDirectory.Contents[0].Name, Is.EqualTo(expectedFile.Name));
    }
}