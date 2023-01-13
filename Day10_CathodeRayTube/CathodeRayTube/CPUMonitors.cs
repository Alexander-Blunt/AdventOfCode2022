using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CathodeRayTube;

public interface ICPUMonitor
{
    public void CPUUpdate(int cycle, int xReg);
}

public class SignalStrengthMonitor : ICPUMonitor
{
    public int SignalStrength { get; private set; } = 0;

    public void CPUUpdate(int cycle, int xReg)
    {
        if ((cycle - 20) % 40 == 0) SignalStrength += cycle * xReg;
    }
}