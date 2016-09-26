using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AirportLibrary.Passengers
{
    public class PassengerEventArgs: EventArgs
    {
        string _flightNumber;
        Passenger _passenger;

        public Passenger Passenger => _passenger;
        public String FlightNumber => _flightNumber;

        public PassengerEventArgs(string flightNumber, Passenger passenger)
        {
            _flightNumber = flightNumber;
            _passenger = passenger;

        }
    }
}
