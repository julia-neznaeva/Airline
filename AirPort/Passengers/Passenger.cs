using AirPort.Passengers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirPort
{
    public class Passenger
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Passport { get; set; }
        public DateTime Birthday { get; set; }
        public Sex Sex { get; set; }
        public Ticket Ticket { get; set; }
        private Random _random = new Random(System.Environment.TickCount);
        private int _minAge = 12;
        private int _maxAge = 90;
        const string _forRandString = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

       // Passenger() { }

        Passenger(string firtstName, string lastName, string passport, DateTime birthday, Sex sex, Ticket ticket)
        {
            Firstname = firtstName;
            Lastname = lastName;
            Passport = passport;
            Birthday = birthday;
            Sex = sex;
            Ticket = ticket;
        }


        Passenger()
        {
            Sex = (Sex)_random.Next(1, 3);
            Firstname = NameHelper.GetFirstName(Sex);
            Lastname = NameHelper.GetLastName();
            Birthday = GetBirthday();
            Passport = GetPassportNumber();
            Ticket = new Ticket();
            
        }

        private DateTime GetBirthday()
        {
            int minYear = DateTime.Today.Year - _maxAge;
            int maxYear = DateTime.Today.Year - _minAge;
            DateTime minDate = new DateTime().AddDays(minYear);
            DateTime maxDate = new DateTime().AddDays(maxYear);
            int countPossibleDays = (maxDate.Date - minDate).Days;
            return minDate.AddDays(_random.Next(0, countPossibleDays));
        }

        private string GetPassportNumber()
        {
            string seria = _forRandString[_random.Next(0, _forRandString.Length - 10)] + _forRandString[_random.Next(0, _forRandString.Length - 10)].ToString();
            StringBuilder number = null;
            for (int i = 0; i < 6; i++)
            {
                number = number.Append( _forRandString[_random.Next(_forRandString.Length - 10, _forRandString.Length)]);
            }
            return $"{seria} {number}";
        }
        
    }
}
