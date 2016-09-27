using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AirportLibrary;
using AirportLibrary.Flights;
using AirportLibrary.Passengers;

namespace PresenterLevel
{
     public class Presenter
    {
        IAirport _airport;
        IView _view;
        public Presenter(IView view)
        {
            _view = view;
            _airport = Airport.Create();

            _view.DisplayFlightEventRaise += OnDisplayFlightEventRaise;
            _view.SearchFlightEventRaise += OnSearchFlightEventRaise;
            _view.DeleteFlightEventRaise += OnDeleteFlightEventRaise;
            _view.AddFlightEventRaise += OnAddFlightEventRaise;
            _view.EditFlightEventRaise += OnEditFlightEventRaise;
            _view.EditePassengerEventRaise += OnEditePassengerEventRaise;
            _view.AddPassangerEventRaise += OnAddPassangerEventRaise;
            _view.SearchPassengerEventRaise += OnSearchPassengerEventRaise;
            _view.SearchPassengerByFlightEventRaise += OnSearchPassengerByFlightEventRaise;
            _view.DeletePassengerEventRaise += OnDeletePassengerEventRaise;
                
        }

        private void OnEditePassengerEventRaise(object sender, PassengerFieldsEventArgs e)
        {
            Passenger passenger = _airport.FindPassengerPassport(e.PassengerInfo);
            _view.Edite(passenger);
        }

        private void OnEditFlightEventRaise(object sender, FlightFieldsEventArgs e)
        {
            Flight flight = _airport.FindByNumber(e.FlightNumber);
            _view.Edite(flight);
        }

        private void OnDeletePassengerEventRaise(object sender, PassengerFieldsEventArgs e)
        {
            Passenger passender = new Passenger();
            foreach (Flight flight in _airport.Flights)
            {
                passender = flight.Passengers.Where(x => x.Passport == e.PassengerInfo).FirstOrDefault();
                flight.DeletePassanger(passender);
                break;
            }
        }

        private void OnAddFlightEventRaise(object sender, FlightEventArgs e)
        {
            _airport.Add(e.Flight);
        }

        private void OnDeleteFlightEventRaise(object sender, FlightFieldsEventArgs e)
        {
            _airport.DeleteFlight(_airport.Flights.Where(x => x.FlightNumber == e.FlightNumber).FirstOrDefault());
        }

        private void OnSearchFlightEventRaise(object sender, PredicateFlightEventArgs e)
        {
            List<Flight> flights = _airport.Flights.Where(e.Predicate).ToList();
           _view.Print(flights);
        }

        private void OnDisplayFlightEventRaise(object sender, EventArgs e)
        {
            _view.Print(_airport.Flights);
        }

        private void OnAddPassangerEventRaise(object sender, PassengerEventArgs e)
        {
           _airport.AddPassenger(e.FlightNumber, e.Passenger);
        }

        private void OnSearchPassengerByFlightEventRaise(object sender, FlightFieldsEventArgs e)
        {
            _view.Print(_airport.Flights.Where(x=>x.FlightNumber == e.FlightNumber).FirstOrDefault().Passengers);
        }

        private void OnSearchPassengerEventRaise(object sender, PredicatePassengerEventArgs e)
        {
            List<Passenger> passengers = new List<Passenger>();
            foreach (Flight flight in _airport.Flights)
            {
                passengers.AddRange(flight.Passengers.Where(e.Predicate));
            }
           _view.Print(passengers);
        }


    }
}
