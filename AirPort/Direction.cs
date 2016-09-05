using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirPort
{
    enum Direction
    {
        Arrival,
        Departure
    }

    enum Status
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
