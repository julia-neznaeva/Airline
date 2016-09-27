using AirportLibrary;
using AirportLibrary.Flights;
using AirportLibrary.Passengers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PresenterLevel
{
    public interface IView
    {
        event EventHandler<EventArgs> DisplayFlightEventRaise;

        event EventHandler<PredicateFlightEventArgs> SearchFlightEventRaise;

        event EventHandler<FlightFieldsEventArgs> DeleteFlightEventRaise;

        event EventHandler<FlightEventArgs> AddFlightEventRaise;

        event EventHandler<PassengerEventArgs> AddPassangerEventRaise;

        event EventHandler<PredicatePassengerEventArgs> SearchPassengerEventRaise;

        event EventHandler<FlightFieldsEventArgs> SearchPassengerByFlightEventRaise;

        event EventHandler<PassengerFieldsEventArgs> DeletePassengerEventRaise;

        event EventHandler<FlightFieldsEventArgs> EditFlightEventRaise;

        event EventHandler<PassengerFieldsEventArgs> EditePassengerEventRaise;

        void PrintMenu();

        void Print(Flight flight);

        void Print(List<Flight> flights);

        void Print(Passenger passenger);

        void Print(List<Passenger> passengers);
        
    }
}
