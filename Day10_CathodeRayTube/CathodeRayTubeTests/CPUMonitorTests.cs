using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CathodeRayTube;

namespace CathodeRayTubeTests;

internal class CPUMonitorTests
{
    [Test]
    public void GivenACPU_SignalStrengthMonitor_HoldsCorrectSignalStrength()
    {
        CPU testCPU = new();
        SignalStrengthMonitor testSSM = new();
        testCPU.ConnectMonitor(testSSM);
        int expected = 420;

        testCPU.AddX(15);
        testCPU.AddX(-11);
        testCPU.AddX(6);
        testCPU.AddX(-3);
        testCPU.AddX(5);
        testCPU.AddX(-1);
        testCPU.AddX(-8);
        testCPU.AddX(13);
        testCPU.AddX(4);
        testCPU.Noop();
        testCPU.AddX(-1);

        int actual = testSSM.SignalStrength;

        Assert.That(expected, Is.EqualTo(actual));
    }

}
