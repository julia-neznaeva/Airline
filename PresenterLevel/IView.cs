using AirportLibrary;
using AirportLibrary.Flights;
using AirportLibrary.Passengers;
using System;
using System.Collections.Generic;


namespace PresenterLevel
{
    public interface IView
    {
        event EventHandler<EventArgs> DisplayFlightEventRaise;

        event EventHandler<FindFlightEventArgs> SearchFlightByNumberEventRaise;

        event EventHandler<FindFlightEventArgs> SearchFlightByCityEventRaise;

        event EventHandler<FindFlightEventArgs> SearchFlightByDateTimeEventRaise;

        event EventHandler<FindFlightEventArgs> SearchFlightEventRaise;

        event EventHandler<FlightFieldsEventArgs> DeleteFlightEventRaise;

        event EventHandler<FlightEventArgs> AddFlightEventRaise;

        event EventHandler<PassengerEventArgs> AddPassangerEventRaise;

        event EventHandler<FindPassengerEventArgs> SearchPassengerByPassportEventRaise;

        event EventHandler<FindPassengerEventArgs> SearchPassengerByFlightEventRaise;

        event EventHandler<FindPassengerEventArgs> SearchPassengerByNameEventRaise;

        event EventHandler<PassengerFieldsEventArgs> DeletePassengerEventRaise;

        event EventHandler<FlightFieldsEventArgs> EditFlightEventRaise;

        event EventHandler<FlightEventArgs> ReturnEditedFlightEventRaise;

        event EventHandler<PassengerFieldsEventArgs> EditePassengerEventRaise;

        void PrintMenu();
        void Print(Flight flight);
        void Print(IEnumerable<Flight> flights);
        void Print(Passenger passenger);
        void Print(IEnumerable<Passenger> passengers);
        void Edite(Flight flight);
        void Edite(Passenger passenger);
        void PrintError(string message);
    }
}
