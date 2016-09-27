using AirportLibrary;
using System.Collections.Generic;

namespace PresenterLevel
{
    public interface IAirport
    {
        List<Flight> Flights { get; }

        Flight FindByNumber(string flightNumber);

        Passenger FindPassengerPassport(string passport);

        void DeleteFlight(Flight flight);

        void Add(Flight flight);

        void AddPassenger(string flightNumber, Passenger passender);



    }
}