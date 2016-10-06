using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AirportLibrary.Passengers
{
    public class PassengerFieldsEventArgs: EventArgs
    {
        string _passport;
        string _flightNumber;
        public string Passport => _passport;
        public string FlightNumber => _flightNumber;
        public PassengerFieldsEventArgs(string passport, string flightNumber)
        {
            _passport = passport;
            _flightNumber = flightNumber;
        }
    }
}
