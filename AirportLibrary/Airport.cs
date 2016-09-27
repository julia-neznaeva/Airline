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

        public List<Flight> GetFlightsDirection(Direction direction)
        {
            List<Flight> result = new List<Flight>();

            result = _flights.FindAll(x => x.Direction == direction);
       
            return result; 
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

        public List<Passenger> FindPassengerByName(string value)
        {
            List<Passenger> passengers = new List<Passenger>();
            foreach (var flight in _flights)
            {
                passengers.AddRange(flight.Passengers.Where(x => x.Firstname.Contains(value)));
                passengers.AddRange(flight.Passengers.Where(x => x.Lastname.Contains(value)));
            }
            return passengers;
        }

        public Passenger FindPassengerPassport(string passport)
        {
            Passenger passenger = new Passenger();
            foreach (var flight in _flights)
            {
                passenger =flight.Passengers.Where(x => x.Passport==passport).FirstOrDefault();
                break;
            }
            return passenger;
        }
        public List<Passenger> FindPassengerByFlightNumber(string flightNumber)
        {
            return FindByNumber(flightNumber).Passengers;
        }
        
    }

}
