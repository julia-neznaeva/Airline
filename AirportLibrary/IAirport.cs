using AirportLibrary;
using System.Collections.Generic;

namespace PresenterLevel
{
    public interface IAirport
    {
        List<Flight> Flights { get; }
        Flight FindByNumber(string flightNumber);
        void DeleteFlight(Flight flight);
    }
}