using System;
using System.Collections.Generic;

namespace AirportLibrary
{
    public class Flight
    {
        public Direction Direction { get; set; }
        public string FlightNumber { get; set; }
        public DateTime  DateTime { get; set; }
        public string City { get; set; }
        public string Airline { get; set; }
        public string Terminal { get; set; }
        public Status FlightStatus { get; set; }
        public List<Passenger> Passengers { get; set; }

        public override string ToString()
        {
            return string.Format("{0,10}|{1,8}|{2,20}|{3,15}|{4,35}|{5,8}|{6,10}", Direction, FlightNumber, DateTime, City, Airline, Terminal, FlightStatus);
        }

        public void DeletePassanger(Passenger passenger)
        {
            Passengers.Remove(passenger);
        }

        public void AddPassenger(Passenger passenger)
        {
            Passengers.Add(passenger);
        }

        public void EditPassanger(Passenger passenger)
        {
            Passengers.RemoveAll(x => x.Passport == passenger.Passport);
            Passengers.Add(passenger);
        }

    }
}