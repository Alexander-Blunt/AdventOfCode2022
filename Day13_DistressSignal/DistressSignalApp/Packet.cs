using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistressSignalApp;

public class Packet
{
    private readonly object[] _values;

    public Packet(object[] values)
    {
        _values = values;
    }
    public static bool Compare(Packet left, Packet right)
    {
        throw new NotImplementedException();
    }
}
