using RopeBridge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RopeBridgeTests;

public class RopePhysicsTests
{
    [Test]
    public void GivenAnInstructionSet_GetNumPositionsVisitedByTail_ReturnsCorrectNumber()
    {
        Rope testRope = new();
        string[] instructionArray = { "R 4", "U 4", "L 3", "D 1", "R 4", "D 1", "L 5", "R 2" };
        int expected = 13;

        int output = RopePhysics.GetNumPositionsVisitedByTail(instructionArray, testRope);

        Assert.That(output, Is.EqualTo(expected));
    }
}
