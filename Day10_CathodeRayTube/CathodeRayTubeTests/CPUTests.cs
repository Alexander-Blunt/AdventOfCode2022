using CathodeRayTube;

namespace CathodeRayTubeTests;

public class CPUTests
{
    CPU testCPU;
    [SetUp]
    public void Setup()
    {
        testCPU = new();
    }

    [Test]
    public void GivenACPU_Noop_Adds1ToCycles()
    {
        int expected = 1;
        testCPU.Noop();
        int actual = testCPU.CurrentCycle;

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void GivenACPU_Add_Adds2ToCycles()
    {
        int expected = 2;
        testCPU.Add(3);
        int actual = testCPU.CurrentCycle;

        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase(2, 3)]
    [TestCase(0, 1)]
    [TestCase(-2, -1)]
    public void GivenACPU_Add_AddsCorrectNumberToXReg(int input, int expected)
    {
        testCPU.Add(input);
        int actual = testCPU.XReg;

        Assert.That(actual, Is.EqualTo(expected));
    }
}