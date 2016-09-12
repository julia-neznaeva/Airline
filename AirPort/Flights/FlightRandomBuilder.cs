using Airport;
using Airport.Passengers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirPort.Flights
{
    class FlightRandomBuilder : FlightInfoBuilder
    {
        const string _forRandString = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private static string[] _cities = { "Kiev", "Kharkiv", "Dnipro", "Odesa", "Lviv", "Kryvyi Rih", "Mykolaiv", "Mariupol", "Vinnytsia", "Poltava", "Chernihiv" };
        private static string[] _airlines = { "Ukraine International Airlines", "Air Urga", "AtlasGlobal UA", "Dniproavia", "Motor Sich Airlines", "Pegasus", "Dubai Fly", "Kharkiv Airlines" };
        private static Random _rand = new Random(Environment.TickCount);
        private PassengerInfoBuilder _passengerBuilder = new PassengerRandomBuilder();

        public override void InitializeAirline()
        {
            _flight.Airline= _airlines[_rand.Next(0, _airlines.Length)];
        }

        public override void InitializeCity()
        {
            _flight.City = _cities[_rand.Next(0, _cities.Length)];
        }

        public override void InitializeDateTime()
        {
            DateTime date = DateTime.Today;
            date = date.AddDays(_rand.Next(0, 32));
            date = date.AddMinutes(_rand.Next(0, 1441));
            _flight.DateTime= date;
        }

        public override void InitializeDirection()
        {
           _flight.Direction = (Direction)_rand.Next(0, 2);
        }

        public override void InitializeFlightNumber()
        {
            char[] str = new char[6];
            for (int i = 0; i < str.Count(); i++)
            {
                str[i] = _forRandString[_rand.Next(0, _forRandString.Length)];
            }
            _flight.FlightNumber= new string(str);
        }

        public override void InitializeFlightStatus()
        {
            _flight.FlightStatus = (Status)_rand.Next(0, 9) ;
        }

        public override void InitializePassengers()
        {
            List<Passenger> passengers = new List<Passenger>();
            int count = _rand.Next(0, 21);
            for (int i = 0; i < count; i++)
            {
                _passengerBuilder.InitializeSex();
                _passengerBuilder.InitializeFirstName();
                _passengerBuilder.InitializeLastName();
                _passengerBuilder.InitializeBirthday();
                _passengerBuilder.InitializePassword();
                _passengerBuilder.InitializeTicket();
                passengers.Add(_passengerBuilder.CreatePassenger());
            }
            _flight.Passengers = passengers;
        }

        public override void InitializeTerminal()
        {
            _flight.Terminal = _forRandString[_rand.Next(0, _forRandString.Length - 9)];
            
        }
    }
}
