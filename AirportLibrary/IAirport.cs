using AirportLibrary;
using System;
using System.Collections.Generic;

namespace PresenterLevel
{
    public interface IAirport
    {
        Flight FindByNumber(string flightNumber);
        Passenger FindPassengerPassport(string passport);
        void DeleteFlight(Flight flight);
        void Add(Flight flight);
        void AddPassenger(string flightNumber, Passenger passender);
        void Edite(Flight flight);
        IEnumerable<Flight> FindByCity(string city);
        IEnumerable<Flight> FindByTime(DateTime dateTime);
        IEnumerable<Flight> FindNearest();
        IEnumerable<Passenger> FindPassengerByName(string name);
        IEnumerable<Passenger> FindPassengerByFlight(string flightNumber);
        bool DeletePassender(Passenger passender, string flightNumber);
        IEnumerable<Flight> GetFlights();
    }
}