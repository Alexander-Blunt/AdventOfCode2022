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

    [Test]
    public void GivenACPUAndInstructions_CRT_HoldsCorrectImage()
    {
        CPU testCPU = new();
        CRT testCRT = new();
        testCPU.ConnectMonitor(testCRT);
        string[] expected = {
                 "##..##..##..##..##..##..##..##..##..##.." ,
                 "###...###...###...###...###...###...###." ,
                 "####....####....####....####....####...." ,
                 "#####.....#####.....#####.....#####....." ,
                 "######......######......######......####" ,
                 "#######.......#######.......#######....."
            };

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
        testCPU.AddX(5);
        testCPU.AddX(-1);
        testCPU.AddX(5);
        testCPU.AddX(-1);
        testCPU.AddX(5);
        testCPU.AddX(-1);
        testCPU.AddX(5);
        testCPU.AddX(-1);
        testCPU.AddX(-35);
        testCPU.AddX(1);
        testCPU.AddX(24);
        testCPU.AddX(-19);
        testCPU.AddX(1);
        testCPU.AddX(16);
        testCPU.AddX(-11);
        testCPU.Noop();
        testCPU.Noop();
        testCPU.AddX(21);
        testCPU.AddX(-15);
        testCPU.Noop();
        testCPU.Noop();
        testCPU.AddX(-3);
        testCPU.AddX(9);
        testCPU.AddX(1);
        testCPU.AddX(-3);
        testCPU.AddX(8);
        testCPU.AddX(1);
        testCPU.AddX(5);
        testCPU.Noop();
        testCPU.Noop();
        testCPU.Noop();
        testCPU.Noop();
        testCPU.Noop();
        testCPU.AddX(-36);
        testCPU.Noop();
        testCPU.AddX(1);
        testCPU.AddX(7);
        testCPU.Noop();
        testCPU.Noop();
        testCPU.Noop();
        testCPU.AddX(2);
        testCPU.AddX(6);
        testCPU.Noop();
        testCPU.Noop();
        testCPU.Noop();
        testCPU.Noop();
        testCPU.Noop();
        testCPU.AddX(1);
        testCPU.Noop();
        testCPU.Noop();
        testCPU.AddX(7);
        testCPU.AddX(1);
        testCPU.Noop();
        testCPU.AddX(-13);
        testCPU.AddX(13);
        testCPU.AddX(7);
        testCPU.Noop();
        testCPU.AddX(1);
        testCPU.AddX(-33);
        testCPU.Noop();
        testCPU.Noop();
        testCPU.Noop();
        testCPU.AddX(2);
        testCPU.Noop();
        testCPU.Noop();
        testCPU.Noop();
        testCPU.AddX(8);
        testCPU.Noop();
        testCPU.AddX(-1);
        testCPU.AddX(2);
        testCPU.AddX(1);
        testCPU.Noop();
        testCPU.AddX(17);
        testCPU.AddX(-9);
        testCPU.AddX(1);
        testCPU.AddX(1);
        testCPU.AddX(-3);
        testCPU.AddX(11);
        testCPU.Noop();
        testCPU.Noop();
        testCPU.AddX(1);
        testCPU.Noop();
        testCPU.AddX(1);
        testCPU.Noop();
        testCPU.Noop();
        testCPU.AddX(-13);
        testCPU.AddX(-19);
        testCPU.AddX(1);
        testCPU.AddX(3);
        testCPU.AddX(26);
        testCPU.AddX(-30);
        testCPU.AddX(12);
        testCPU.AddX(-1);
        testCPU.AddX(3);
        testCPU.AddX(1);
        testCPU.Noop();
        testCPU.Noop();
        testCPU.Noop();
        testCPU.AddX(-9);
        testCPU.AddX(18);
        testCPU.AddX(1);
        testCPU.AddX(2);
        testCPU.Noop();
        testCPU.Noop();
        testCPU.AddX(9);
        testCPU.Noop();
        testCPU.Noop();
        testCPU.Noop();
        testCPU.AddX(-1);
        testCPU.AddX(2);
        testCPU.AddX(-37);
        testCPU.AddX(1);
        testCPU.AddX(3);
        testCPU.Noop();
        testCPU.AddX(15);
        testCPU.AddX(-21);
        testCPU.AddX(22);
        testCPU.AddX(-6);
        testCPU.AddX(1);
        testCPU.Noop();
        testCPU.AddX(2);
        testCPU.AddX(1);
        testCPU.Noop();
        testCPU.AddX(-10);
        testCPU.Noop();
        testCPU.Noop();
        testCPU.AddX(20);
        testCPU.AddX(1);
        testCPU.AddX(2);
        testCPU.AddX(2);
        testCPU.AddX(-6);
        testCPU.AddX(-11);
        testCPU.Noop();
        testCPU.Noop();
        testCPU.Noop();

        var actual = testCRT.Screen;
        Assert.That(actual, Is.EqualTo(expected));
    }
}
