using System;
using System.Linq;
using AirportLibrary.Passengers;

namespace AirportLibrary.Flights
{
	public class ConsoleFlightInfoBuilder : FlightInfoBuilder
	{
		private static Random _rand = new Random(Environment.TickCount);
		private PassengerInfoBuilder _pbuilder;
		public ConsoleFlightInfoBuilder(PassengerInfoBuilder pbuilder)
		{
			_pbuilder = pbuilder;
		}

		protected override void InitializeDirection(Flight flight)
		{
			Console.Write("Select direction: ");
			for (int i = 0; i <= (int)Direction.Departure; i++)
			{
				Console.Write($"{(Direction)i} - {i} ");
			}
			Direction direction = (Direction)ConsoleHelper.ReadNumber(Console.ReadLine());
			flight.Direction = direction;
		}

		protected override void InitializeFlightNumber(Flight flight)
		{
            Console.WriteLine("Please enter flight number. Flight number should be 6 symbols");
			Console.Write("Flight number: ");
            flight.FlightNumber = ConsoleHelper.ReadString(6, Console.ReadLine());
		}

		protected override void InitializeDateTime(Flight flight)
		{
			Console.WriteLine("Enter Date and time in next format \"dd.mm.yyyy hh:mm:ss\"");
			Console.Write("Date and time: ");
			DateTime dateTime = ConsoleHelper.ReadDate(Console.ReadLine());
			flight.DateTime = dateTime;
		}

		protected override void InitializeCity(Flight flight)
		{
			Console.WriteLine("Enter city, max value of city name should be 15 symbols");
			Console.Write("City: ");
			string city = ConsoleHelper.ReadString(15, Console.ReadLine());
			flight.City = city;
		}

		protected override void InitializeAirline(Flight flight)
		{
			Console.WriteLine("Enter airline, max value of airline name should be 40 symbols");
			Console.Write("Airline: ");
			string airline = ConsoleHelper.ReadString(40, Console.ReadLine());
			flight.Airline = airline;
		}

		protected override void InitializeTerminal(Flight flight)
		{
			Console.WriteLine("Enter Terminal. Terminal name should be 1 symbols");
			Console.Write("Terminal: ");
			char terminal = ConsoleHelper.ReadString(1, Console.ReadLine()).ToCharArray().First();
			flight.Terminal = terminal;
		}

		protected override void InitializeFlightStatus(Flight flight)
		{
			Console.WriteLine("Select status:");
			for (int i = 0; i <= (int)Status.InFlight; i++)
				Console.Write($"{(Status)i} - {i} ");
			Status status = (Status)ConsoleHelper.ReadNumber(Console.ReadLine());
			flight.FlightStatus = status;
		}

		protected override void InitializePassengers(Flight flight)
		{
			flight.Passengers.Add(_pbuilder.CreatePassenger());
		}

        private string GetRandomString(int v)
		{
			string _forRandString = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
			char[] str = new char[6];
			for (int i = 0; i < str.Count(); i++)
			{
				str[i] = _forRandString[_rand.Next(0, _forRandString.Length)];
			}
			return new string(str);
		}

        public override Flight CreateFlight()
        {
            Flight flight = new Flight();
            InitializeDirection(flight);
            InitializeDateTime(flight);
            InitializeCity(flight);
            InitializeAirline(flight);
            InitializeTerminal(flight);
            InitializeFlightStatus(flight);
            InitializeFlightNumber(flight);
            return flight;
        }
    }
}
