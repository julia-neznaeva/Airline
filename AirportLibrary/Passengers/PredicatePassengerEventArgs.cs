using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AirportLibrary.Passengers
{
    public class FindPassengerEventArgs: EventArgs
    {
        public string Name { get; set; }

        public string Passport { get; set; }

        public string FlightNumber { get; set; } 


    }
}
