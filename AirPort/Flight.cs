using System;

namespace AirPort
{
    internal class Flight
    {
        public Direction Direction { get; set; }
        public string FlightNumber { get; set; }
        public DateTime  DateTime { get; set; }
        public string City { get; set; }
        public string Airline { get; set; }
        public char Terminal { get; set; }
        public Status FlightStatus { get; set; }

        public override string ToString()
        {
            return string.Format("{0,10}|{1,8}|{2,20}|{3,15}|{4,35}|{5,8}|{6,10}", Direction, FlightNumber, DateTime, City, Airline, Terminal, FlightStatus);
        }
    }
}