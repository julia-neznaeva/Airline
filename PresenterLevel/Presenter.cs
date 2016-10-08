using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AirportLibrary;
using AirportLibrary.Flights;
using AirportLibrary.Passengers;
using AirportDbLevel;

namespace PresenterLevel
{
     public class Presenter
    {
        IAirport _airport;
        IView _view;

        public Presenter(IView view)
        {
            _view = view;
            _airport = AirportDB.Create();

            _view.DisplayFlightEventRaise += OnDisplayFlightEventRaise;
            _view.SearchFlightByNumberEventRaise += OnSearchFlightByNumberEventRaise;
            _view.SearchFlightByDateTimeEventRaise += OnSearchFlightByDateTimeEventRaise;
            _view.SearchFlightByCityEventRaise += OnSearchFlightByCityEventRaise;
            _view.SearchFlightEventRaise += OnSearchFlightEventRaise;
            _view.DeleteFlightEventRaise += OnDeleteFlightEventRaise;
            _view.AddFlightEventRaise += OnAddFlightEventRaise;
            _view.EditFlightEventRaise += OnEditFlightEventRaise;
            _view.ReturnEditedFlightEventRaise += OnReturnEditedFlightEventRaise;
            _view.EditePassengerEventRaise += OnEditePassengerEventRaise;
            _view.AddPassangerEventRaise += OnAddPassangerEventRaise;
            _view.SearchPassengerByFlightEventRaise += OnSearchPassengerEventRaise;
            _view.SearchPassengerByNameEventRaise += OnSearchPassengerByNameEventRaise;
            _view.SearchPassengerByPassportEventRaise += OnSearchPassengerByPassportEventRaise;
            _view.DeletePassengerEventRaise += OnDeletePassengerEventRaise;
        }

        private void OnSearchPassengerByPassportEventRaise(object sender, FindPassengerEventArgs  e)
        {
            _view.Print(_airport.FindPassengerPassport(e.Passport));
        }

        private void OnSearchPassengerByNameEventRaise(object sender, FindPassengerEventArgs e)
        {
            _view.Print(_airport.FindPassengerByName(e.Name));
        }

        private void OnSearchFlightByCityEventRaise(object sender, FindFlightEventArgs e)
        {
            _view.Print(_airport.FindByCity(e.City));
        }

        private void OnSearchFlightByDateTimeEventRaise(object sender, FindFlightEventArgs e)
        {
            _view.Print(_airport.FindByTime(e.DateTime));
        }

        private void OnSearchFlightByNumberEventRaise(object sender, FindFlightEventArgs e)
        {
            _view.Print(_airport.FindByNumber(e.FlightNumber));
        }

        private void OnSearchFlightEventRaise(object sender, FindFlightEventArgs e)
        {
            _view.Print(_airport.FindNearest());
        }

        private void OnReturnEditedFlightEventRaise(object sender, FlightEventArgs e)
        {
            _airport.Edite(e.Flight);
        }

        private void OnEditePassengerEventRaise(object sender, PassengerFieldsEventArgs e)
        {
            Passenger passenger = _airport.FindPassengerPassport(e.Passport);
            Flight result  = new Flight();
            
            _view.Edite(passenger);
        }

        private void OnEditFlightEventRaise(object sender, FlightFieldsEventArgs e)
        {
            Flight flight = _airport.FindByNumber(e.FlightNumber);
            _view.Edite(flight);
        }

        private void OnDeletePassengerEventRaise(object sender, PassengerFieldsEventArgs e)
        {
             _airport.DeletePassender(_airport.FindPassengerPassport(e.Passport), e.FlightNumber);
        }

        private void OnAddFlightEventRaise(object sender, FlightEventArgs e)
        {
            try
            {
                _airport.Add(e.Flight);
            }
            catch (AddFlightException ex)
            {
                _view.PrintError(ex.Message);
            }
        }

        private void OnDeleteFlightEventRaise(object sender, FlightFieldsEventArgs e)
        {
            Flight flight = _airport.FindByNumber(e.FlightNumber);
            if (flight != null)
                _airport.DeleteFlight(flight);
            else
                _view.PrintError("The flight is not exsist");
        }

        private void OnDisplayFlightEventRaise(object sender, EventArgs e)
        {
            _view.Print(_airport.GetFlights());
        }

        private void OnAddPassangerEventRaise(object sender, PassengerEventArgs e)
        {
            if (_airport.FindByNumber(e.FlightNumber)!=null)
                _airport.AddPassenger(e.FlightNumber, e.Passenger);
            else
                _view.PrintError("The flight is not exsist");
        }

        private void OnSearchPassengerByFlightEventRaise(object sender, FindPassengerEventArgs e)
        {
            _view.Print(_airport.FindPassengerByFlight(e.FlightNumber));
        }

        private void OnSearchPassengerEventRaise(object sender, FindPassengerEventArgs e)
        {
           _view.Print(_airport.FindPassengerByFlight(e.FlightNumber));

        }
    }
}
