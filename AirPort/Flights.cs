using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirPort
{
    class Airport
    {
        const string _forRandString = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        static string[] cities = { "Kiev", "Kharkiv", "Dnipro", "Odesa", "Lviv", "Kryvyi Rih", "Mykolaiv", "Mariupol", "Vinnytsia", "Poltava", "Chernihiv" };
        static string[] airlines = { "Ukraine International Airlines", "Air Urga", "AtlasGlobal UA", "Dniproavia", "Motor Sich Airlines", "Pegasus", "Dubai Fly", "Kharkiv Airlines" };
        List<Flight> _flights = new List<Flight>();
        private Random rand = new Random(Environment.TickCount);
        public List<Flight> FlightsList
        {
            get { return _flights; }
        }

        public Airport()
        {
            for (int i = 0; i < 20; i++)
            {
                _flights.Add(CreateNewFlight());
            }
        }

        public void DeleteFlight(Flight flight)
        {
            _flights.Remove(flight);
        }

        public void Add(Flight flight)
        {
            _flights.Add(flight);
        }

        public void Edite(Flight flight)
        {
            int index = -1;
            for (int i = 0; i < _flights.Count; i++)
            {
                if (_flights[i].FlightNumber.Equals(flight.FlightNumber))
                {
                    index = i;
                    break;
                }
            }
            _flights[index] = flight;
        }

        public List<Flight> GetFlightsDirection(Direction direction)
        {
            List<Flight> result = new List<Flight>();

            result = _flights.FindAll(x => x.Direction == direction);
       
            return result; 
        }
        
        public Flight FindByNumber(string flightNumber)
        {
            Flight result = new Flight();
            foreach (Flight flight in _flights)
            {
                if (flight.FlightNumber == flightNumber)
                {
                    result = flight;
                    break;
                }
            }
            return result;
        }

        public List<Flight> FindByCity(string city)
        {
            List<Flight> result = new List<Flight>();

            result = _flights.FindAll(x => x.City == city);

            return result;
        }

        public List<Flight> FindByTime(DateTime dateTime)
        {
            List<Flight> result = new List<Flight>();

            result = _flights.FindAll(x => x.DateTime == dateTime);

            return result;
        }

        public List<Flight> FindByNearestDateTime()
        {
            DateTime startDateTime = DateTime.Now;
            DateTime finishDateTime = startDateTime.AddHours(1);

            List<Flight> result = new List<Flight>();

            result = _flights.FindAll(x => x.DateTime > startDateTime && x.DateTime < finishDateTime);

            return result;
        }


        #region helper methods for random creation flights

        public Flight CreateNewFlight()
        {

            Direction direction = (Direction)rand.Next(0, 2);
            string flightNumber = GetRandomString(6);
            DateTime dateTime = GetRandomTime();
            string city = GetRandomCity();
            string airline = GetRandomAirline();
            char terminal = GetRandomTerminal();
            Status flightStatus = (Status)rand.Next(0, 9);

            return new Flight()
            {
                Direction = direction,
                FlightNumber = flightNumber,
                City = city,
                Airline = airline,
                Terminal = terminal,
                FlightStatus = flightStatus,
                DateTime = dateTime

            };
        }

        private DateTime GetRandomTime()
        {
            DateTime date = DateTime.Today;
            date = date.AddDays(rand.Next(0, 32));
            date = date.AddMinutes(rand.Next(0, 1441));
            return date;
        }

        private char GetRandomTerminal()
        {
            char result = _forRandString[rand.Next(0, _forRandString.Length - 9)];
            return result;
        }

        private string GetRandomAirline()
        {
            return airlines[rand.Next(0, airlines.Length)];
        }

        private string GetRandomCity()
        {
            return cities[rand.Next(0, cities.Length)];
        }

        public string GetRandomString(int length)
        {
            char[] str = new char[length];
            for (int i = 0; i < length; i++)
            {
                str[i] = _forRandString[rand.Next(0, _forRandString.Length)];
            }
            return new string(str);

        }
        #endregion


    }

}
