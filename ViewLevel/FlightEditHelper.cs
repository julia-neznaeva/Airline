using AirportLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ViewLevel
{
    class FlightEditHelper: EditHelper
    {
        Flight _flight;

       internal FlightEditHelper(Flight flight)
        {
            _flight = flight;
        }

        public Flight Edite()
        {
            Flight flight = new Flight();
            Console.WriteLine("Enter flight number: ");
            Console.WriteLine("Enter new value for fields. If field should not be edited  value press enter");
            flight.DateTime = EditDateTime(_flight.DateTime);
            flight.City = EditeFlightCity(_flight.City);
            flight.Airline = EditAirline(_flight.Airline);
            flight.Terminal = EditeTerminal(_flight.Terminal);
            flight.FlightStatus = EditeStatus(_flight.FlightStatus);
            flight.FlightNumber = _flight.FlightNumber;
            flight.Passengers = _flight.Passengers;
            return flight;
        }

        private string EditAirline(string airline)
        {
            Console.WriteLine();
            Console.WriteLine("Enter airline, max value of airline name should be 40 symbols");
            OutputOldValue(airline);
            string str = Console.ReadLine();
            if (string.IsNullOrEmpty(str))
            {
                return airline;
            }
            else return ConsoleHelper.ReadString(40, str);
        }

        private Status EditeStatus(Status flightStatus)
        {
            Console.WriteLine();
            Console.WriteLine("Select status:");
            for (int i = 0; i <= (int)Status.InFlight; i++)
                Console.Write($"{(Status)i} - {i} ");
            Console.WriteLine();
            OutputOldValue(flightStatus);
            string str = Console.ReadLine();
            if (string.IsNullOrEmpty(str))
            {
                return flightStatus;
            }
            else return (Status)ConsoleHelper.ReadNumber(str);

        }

        private char EditeTerminal(char terminal)
        {
            Console.WriteLine();
            Console.WriteLine("Enter Terminal. Terminal name should be 1 symbols");
            OutputOldValue(terminal);
            string str = Console.ReadLine();
            if (string.IsNullOrEmpty(str))
            {
                return terminal;
            }
            else return ConsoleHelper.ReadString(1, str).ToCharArray().First(); ;
        }

        private string EditeFlightCity(string city)
        {
            Console.WriteLine();
            Console.WriteLine("Enter city, max value of city name should be 15 symbols");
            OutputOldValue(city);
            string str = Console.ReadLine();
            if (string.IsNullOrEmpty(str))
            {
                return city;
            }
            else return ConsoleHelper.ReadString(15, str);
        }

        private DateTime EditDateTime(DateTime dateTime)
        {

            Console.WriteLine();
            Console.WriteLine("Enter Date and time in next format \"dd.mm.yyyy hh:mm:ss\"");
            OutputOldValue(dateTime);
            string str = Console.ReadLine();
            if (string.IsNullOrEmpty(str))
            {
                return dateTime;
            }
            else return ConsoleHelper.ReadDate(str);
        }
    }
}
