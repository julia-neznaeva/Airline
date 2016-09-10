using Airport.Passengers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport
{
    public class Passenger
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public Sex Sex { get; set; }
        public string Passport { get; set; }
        public DateTime Birthday { get; set; }
        public Ticket Ticket { get; set; }

        internal Passenger() { }

        internal Passenger(string firtstName, string lastName, string passport, DateTime birthday, Sex sex, Ticket ticket)
        {
            Firstname = firtstName;
            Lastname = lastName;
            Sex = sex;
            Passport = passport;
            Birthday = birthday;
            Ticket = ticket;
        }

        public override string ToString()
        {
           return string.Format("{0, 15}|{1, 25}{2, 8}|{3, 10}|{4,15}|{5,10}", Firstname, Lastname, (Sex)Sex, Passport, Birthday.ToShortDateString(), Ticket);
        }
    }
}
