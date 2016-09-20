﻿using Airport;
using Airport.Passengers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirPort.Flights
{
    class RandomFlightInfoBuilder : FlightInfoBuilder
    {
        const string _forRandString = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private static string[] _cities = { "Kiev", "Kharkiv", "Dnipro", "Odesa", "Lviv", "Kryvyi Rih", "Mykolaiv", "Mariupol", "Vinnytsia", "Poltava", "Chernihiv" };
        private static string[] _airlines = { "Ukraine International Airlines", "Air Urga", "AtlasGlobal UA", "Dniproavia", "Motor Sich Airlines", "Pegasus", "Dubai Fly", "Kharkiv Airlines" };
        private static Random _rand = new Random(Environment.TickCount);
        private PassengerInfoBuilder _passengerBuilder = new RandomPassengerInfoBuilder();

        protected override void InitializeAirline()
        {
            _flight.Airline= _airlines[_rand.Next(0, _airlines.Length)];
        }

        protected override void InitializeCity()
        {
            _flight.City = _cities[_rand.Next(0, _cities.Length)];
        }

        protected override void InitializeDateTime()
        {
            DateTime date = DateTime.Today;
            date = date.AddDays(_rand.Next(0, 32));
            date = date.AddMinutes(_rand.Next(0, 1441));
            _flight.DateTime= date;
        }

        protected override void InitializeDirection()
        {
           _flight.Direction = (Direction)_rand.Next(0, 2);
        }

        protected override void InitializeFlightNumber()
        {
            char[] str = new char[6];
            for (int i = 0; i < str.Count(); i++)
            {
                str[i] = _forRandString[_rand.Next(0, _forRandString.Length)];
            }
            _flight.FlightNumber= new string(str);
        }

        protected override void InitializeFlightStatus()
        {
            _flight.FlightStatus = (Status)_rand.Next(0, 9) ;
        }

        protected override void InitializePassengers()
        {
            List<Passenger> passengers = new List<Passenger>();
            int count = _rand.Next(0, 21);
            for (int i = 0; i < count; i++)
            {
                passengers.Add(_passengerBuilder.CreatePassenger());
            }
            _flight.Passengers = passengers;
        }

        protected override void InitializeTerminal()
        {
            _flight.Terminal = _forRandString[_rand.Next(0, _forRandString.Length - 9)];
            
        }
    }
}