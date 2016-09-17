using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport
{
    public enum Direction
    {
        Arrival,
        Departure
    }

    public enum Status
    {
        CheckIn,
        GateClosed,
        Arrives,
        DepartestAt,
        Unknown,
        Canseled,
        ExpectedAt,
        Delayed,
        InFlight
    }
}
