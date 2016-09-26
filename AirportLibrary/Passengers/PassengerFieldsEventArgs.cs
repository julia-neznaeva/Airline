using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AirportLibrary.Passengers
{
    public class PassengerFieldsEventArgs: EventArgs
    {
        string _passport;
        
        public string PassengerInfo => _passport;

        public PassengerFieldsEventArgs(string passport)
        {
            _passport = passport;
        }
    }
}
