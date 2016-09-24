using Airport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PresenterLevel
{
    public interface IView
    {
        event EventHandler<EventArgs> DisplayFlightEventRaise;

        void Print(Flight flight);

        void Print(List<Flight> flights);
        
    }
}
