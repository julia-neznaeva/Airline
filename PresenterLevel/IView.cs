using AirportLibrary;
using AirportLibrary.Flights;
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
         
        void PrintMenu();

        void Print(Flight flight);

        void Print(List<Flight> flights);




        
    }
}
