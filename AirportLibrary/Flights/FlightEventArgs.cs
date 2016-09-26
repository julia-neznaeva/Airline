using AirportLibrary;
using System;

namespace PresenterLevel
{
    public class FlightEventArgs: EventArgs
    {
        private Flight _flight;
        public Flight Flight => _flight;
        public FlightEventArgs(Flight flight)
        {
            _flight = flight;
        }

    }
}