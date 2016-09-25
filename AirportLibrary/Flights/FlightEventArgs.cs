using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AirportLibrary.Flights
{
    public class FlightNumberEventArgs: EventArgs
    {
        String _flightsNumber;

        public FlightNumberEventArgs(String flightsNumber)
        {
            _flightsNumber = flightsNumber;
        }

        public String FlightNumber=> _flightsNumber;

    }
}
