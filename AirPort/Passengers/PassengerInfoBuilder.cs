using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Passengers
{
    abstract class PassengerInfoBuilder
    {
        protected Passenger _passenger = new Passenger();

        public abstract void InitializeFirstName();
        public abstract void InitializeLastName();
        public abstract void InitializePassword();
        public abstract void InitializeSex();
        public abstract void InitializeBirthday();
        public abstract void InitializeTicket();

        public Passenger CreatePassenger()
        {
            return _passenger;
        }



    }
}
