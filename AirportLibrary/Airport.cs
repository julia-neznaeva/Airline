using AirportLibrary.Flights;
using PresenterLevel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportLibrary
{
    public class Airport : IAirport
    {
        List<Flight> _flights = new List<Flight>();

        private FlightInfoBuilder _flightBuilder;

        public static Airport Create()
        {
           return new Airport();
        }

        public List<Flight> Flights
        {
            get { return _flights; }
        }

        private Airport()
        {
            _flightBuilder = new RandomFlightInfoBuilder();
            for (int i = 0; i < 20; i++)
            {
                _flights.Add(_flightBuilder.CreateFlight());
            }
        }

        public void DeleteFlight(Flight flight)
        {
            _flights.Remove(flight);
        }

        public void Add(Flight flight)
        {
            if (_flights.Any(x => x.FlightNumber == flight.FlightNumber))
            {
                throw new AddFlightException("Flight with that flight number already exsist");
            }
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

        public void AddPassenger(string flightNumber, Passenger passender)
        {
            Flight flight = _flights.Where(x => x.FlightNumber == flightNumber).FirstOrDefault();
            flight.AddPassenger(passender);
        }
       
        public Flight FindByNumber(string flightNumber)
        {
            Flight result = null;
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

        public Passenger FindPassengerPassport(string passport)
        {
            Passenger passenger = new Passenger();
            foreach (var flight in _flights)
            {
                passenger =flight.Passengers.Where(x => x.Passport==passport).FirstOrDefault();
            }
            return passenger;
        }

        public IEnumerable<Flight> FindByCity(string city)
        {
            return _flights.Where(x => x.City == city);
        }

        public IEnumerable<Flight>FindByTime(DateTime dateTime)
        {
            return _flights.Where(x => x.DateTime == dateTime);
        }

        public IEnumerable<Flight> FindNearest()
        {
            DateTime startDateTime = DateTime.Now;
            DateTime finishDateTime = startDateTime.AddHours(1);
            return _flights.Where(x => x.DateTime > startDateTime && x.DateTime < finishDateTime);
        }

        public IEnumerable<Passenger> FindPassengerByName(string name)
        {
            List<Passenger> result = new List<Passenger>();
            foreach (var flight in _flights)
            {
                result.AddRange(flight.Passengers.Where(x => x.Firstname.Contains(name) | x.Lastname.Contains(name)));
            }
            return result; 
           
        }
        public IEnumerable<Passenger> FindPassengerByFlight(string flightNumber)
        {
            return FindByNumber(flightNumber).Passengers;
        }

        public bool  DeletePassender(Passenger passender, string flightNumber)
        {
            Flight flight = FindByNumber(flightNumber);
            if (flight == null)
                return false;
            else
            {
                flight.DeletePassanger(passender);
                return true;
            }
        }

        public IEnumerable<Flight> GetFlights()
        {
            return _flights;
        }
    }

}
