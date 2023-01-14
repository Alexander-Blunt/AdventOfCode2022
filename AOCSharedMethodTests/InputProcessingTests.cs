using Microsoft.VisualStudio.TestPlatform.TestHost;
using AOCSharedMethods;

namespace AOCSharedMethodTests;

public class InputProcessingTests
{
    [Test]
    public void GivenAFileAndParent_GetInputFilePath_ReturnsCorrectPath()
    {
        string expected = "C:\\Users\\Spore\\source\\repos\\AdventOfCode2022\\AOCSharedMethodTests\\InputProcessingTests.cs";
        string parentDir = @"\AOCSharedMethodTests";
        string fileName = "InputProcessingTests.cs";

        string actual = InputProcessing.GetInputFilePath(parentDir, fileName);

        Assert.That(actual, Is.EqualTo(expected));
    }
}