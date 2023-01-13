using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CathodeRayTube;

namespace CathodeRayTubeTests;

internal class ProgramTests
{
    [Test]
    public void GivenAFileAndParent_GetInputFilePath_ReturnsCorrectPath()
    {
        string expected = "C:\\Users\\Spore\\source\\repos\\AdventOfCode2022\\Day10_CathodeRayTube\\CathodeRayTubeTests\\ProgramTests.cs";
        string parentDir = @"\CathodeRayTubeTests";
        string fileName = "ProgramTests.cs";

        string actual = Program.GetInputFilePath(parentDir, fileName);

        Assert.That(actual, Is.EqualTo(expected));
    }
}
