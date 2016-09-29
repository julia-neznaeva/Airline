using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AirportLibrary.Flights
{
    public class AddFlightException : Exception
    {
        public AddFlightException(string message) : base(message)
        {
        }
    }
}
