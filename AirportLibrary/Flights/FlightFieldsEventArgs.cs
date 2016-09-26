using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AirportLibrary.Flights
{
    public class FlightFieldsEventArgs: EventArgs
    {
        private string _flightNumber;

        public string FlightNumber => _flightNumber;

        public FlightFieldsEventArgs(string flightNumber)
        {
            _flightNumber = flightNumber;
        }
    }
}
