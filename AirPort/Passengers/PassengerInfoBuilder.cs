using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Passengers
{
    public abstract class PassengerInfoBuilder
    {
        protected Passenger _passenger = new Passenger();

        protected abstract void InitializeFirstName();
        protected abstract void InitializeLastName();
        protected abstract void InitializePassword();
        protected abstract void InitializeSex();
        protected abstract void InitializeBirthday();
        protected abstract void InitializeTicket();

        public Passenger CreatePassenger()
        {
			InitializeFirstName();
			InitializeLastName();
			InitializePassword();
			InitializeSex();
			InitializeBirthday();
			InitializeTicket();
            return _passenger;
        }



    }
}
