using System;

namespace AirportLibrary
{

    public class PredicateFlightEventArgs : EventArgs
    {

        private Func<Flight, bool> _predicate;

        public Func<Flight, bool> Predicate => _predicate;

        public PredicateFlightEventArgs(Func<Flight, bool> predicate)
        {
            _predicate = predicate;
        }



    }
}