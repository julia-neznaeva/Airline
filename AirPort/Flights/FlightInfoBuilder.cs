using Airport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airport.Passengers;

namespace AirPort.Flights
{
    public abstract class FlightInfoBuilder
    {
        protected Flight _flight = new Flight();


		protected virtual void InitializeDirection()
		{ 
		}
		protected virtual void InitializeFlightNumber()
		{ 
		}
		protected virtual void InitializeDateTime()
		{ 
		}
		protected virtual void InitializeCity()
		{ 
		}
		protected virtual void InitializeAirline()
		{ 
		}
		protected virtual void InitializeTerminal()
		{ 
		}
		protected virtual void InitializeFlightStatus()
		{ 
		}
		protected virtual void InitializePassengers()
		{ 
		}

        public virtual Flight CreateFlight()
        {
			InitializeDirection();
			InitializeDateTime();
			InitializeCity();
			InitializeAirline();
			InitializeTerminal();
			InitializeFlightStatus();
			InitializePassengers();

			InitializeFlightNumber();
            return _flight;
        }
    }
}
