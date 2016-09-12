using Airport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirPort.Flights
{
    abstract class FlightInfoBuilder
    {
        protected Flight _flight;

        public FlightInfoBuilder()
        {
            _flight = new Flight();
        }

        public abstract void InitializeDirection();
        public abstract void InitializeFlightNumber();
        public abstract void InitializeDateTime();
        public abstract void InitializeCity();
        public abstract void InitializeAirline();
        public abstract void InitializeTerminal();
        public abstract void InitializeFlightStatus();
        public abstract void InitializePassengers();

        public Flight CreateFlight()
        {
            return _flight;
        }
    }
}
