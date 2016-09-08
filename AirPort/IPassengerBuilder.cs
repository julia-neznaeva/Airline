using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirPort
{
    interface IPassengerBuilder
    {
        void SetFirstName(string firstName);
        void SetLastName(string lastName);
        void SetSex(Sex sex);
        void SetPassport(string passport);
        void SetBirthDay(DateTime BirthDay);
        void SetTicket(Ticket tiket);
        Passenger Create();

    }
}
