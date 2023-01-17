using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CathodeRayTube;

public class CPU
{
    public int CurrentCycle { get; private set; }
    public int XReg { get; private set; } = 1;

    public List<ICPUMonitor>? Monitors { get; private set; }

    public CPU()
    {
        CurrentCycle = 0;
        Monitors = new();
    }

    public void UpdateMonitors()
    {
        if (Monitors == null || Monitors.Count == 0) return;
        foreach (ICPUMonitor monitor in Monitors)
        {
            monitor.CPUUpdate(CurrentCycle, XReg);
        }
    }

    public void ConnectMonitor(ICPUMonitor monitor)
    {
        Monitors.Add(monitor);
    }

    public void DisconnectMonitor(ICPUMonitor monitor)
    {
        Monitors.Remove(monitor);
    }

    public void AddX(int v)
    {
        Noop();
        Noop();
        XReg += v;
    }

    public void Noop()
    {
        CurrentCycle++;
        UpdateMonitors();
    }
}
