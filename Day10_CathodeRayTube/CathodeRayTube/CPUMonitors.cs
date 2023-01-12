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

public class SignalStrengthReader : ICPUMonitor
{
    public void CPUUpdate(int cycle, int xReg)
    {
        throw new NotImplementedException();
    }
}