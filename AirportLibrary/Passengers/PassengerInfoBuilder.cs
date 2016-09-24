using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportLibrary.Passengers
{
    public abstract class PassengerInfoBuilder
    {
        protected abstract void InitializeFirstName(Passenger passenger);
        protected abstract void InitializeLastName(Passenger passenger);
        protected abstract void InitializePassword(Passenger passenger);
        protected abstract void InitializeSex(Passenger passenger);
        protected abstract void InitializeBirthday(Passenger passenger);
        protected abstract void InitializeTicket(Passenger passenger);

        public Passenger CreatePassenger()
        {
            Passenger  passenger  = new Passenger();
            InitializeFirstName(passenger);
			InitializeLastName(passenger);
			InitializePassword(passenger);
			InitializeSex(passenger);
			InitializeBirthday(passenger);
			InitializeTicket(passenger);
            return passenger;
        }



    }
}
