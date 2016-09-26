using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AirportLibrary.Passengers
{
    public class PredicatePassengerEventArgs: EventArgs
    {
        private Func<Passenger, bool> _predicate;
        public Func<Passenger, bool> Predicate => _predicate;

        public PredicatePassengerEventArgs(Func<Passenger, bool> predicate)
        {
            _predicate = predicate;
        }


    }
}
