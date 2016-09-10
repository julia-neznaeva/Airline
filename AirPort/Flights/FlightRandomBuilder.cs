using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirPort.Flights
{
    class FlightRandomBuilder : FlightInfoBuilder
    {
        const string _forRandString = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        static string[] cities = { "Kiev", "Kharkiv", "Dnipro", "Odesa", "Lviv", "Kryvyi Rih", "Mykolaiv", "Mariupol", "Vinnytsia", "Poltava", "Chernihiv" };
        static string[] airlines = { "Ukraine International Airlines", "Air Urga", "AtlasGlobal UA", "Dniproavia", "Motor Sich Airlines", "Pegasus", "Dubai Fly", "Kharkiv Airlines" };


        public override void InitializeAirline()
        {
            throw new NotImplementedException();
        }

        public override void InitializeCity()
        {
            throw new NotImplementedException();
        }

        public override void InitializeDateTime()
        {
            throw new NotImplementedException();
        }

        public override void InitializeDirection()
        {
            throw new NotImplementedException();
        }

        public override void InitializeFlightNumber()
        {
            throw new NotImplementedException();
        }

        public override void InitializeFlightStatus()
        {
            throw new NotImplementedException();
        }

        public override void InitializePassengers()
        {
            throw new NotImplementedException();
        }

        public override void InitializeTerminal()
        {
            throw new NotImplementedException();
        }
    }
}
