using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportLibrary.Flights
{
    public abstract class FlightInfoBuilder
    {
       
		protected virtual void InitializeDirection(Flight flight)
		{ 
		}
		protected virtual void InitializeFlightNumber(Flight flight)
		{ 
		}
		protected virtual void InitializeDateTime(Flight flight)
		{ 
		}
		protected virtual void InitializeCity(Flight flight)
		{ 
		}
		protected virtual void InitializeAirline(Flight flight)
		{ 
		}
		protected virtual void InitializeTerminal(Flight flight)
		{ 
		}
		protected virtual void InitializeFlightStatus(Flight flight)
		{ 
		}
		protected virtual void InitializePassengers(Flight flight)
		{ 
		}

        public virtual Flight CreateFlight()
        {
            Flight flight = new Flight();
			InitializeDirection(flight);
			InitializeDateTime(flight);
			InitializeCity(flight);
			InitializeAirline(flight);
			InitializeTerminal(flight);
			InitializeFlightStatus(flight);
            InitializeFlightNumber(flight);
            return flight;
        }
    }
}
