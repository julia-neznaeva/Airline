using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AirportLibrary;
using AirportLibrary.Flights;

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
        }

        private void OnDeleteFlightEventRaise(object sender, FlightNumberEventArgs e)
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

    }
}
