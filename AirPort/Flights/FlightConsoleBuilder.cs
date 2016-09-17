using System;
using System.Linq;
using Airport;
using Airport.Passengers;

namespace AirPort.Flights
{
	public class FlightConsoleBuilder : FlightInfoBuilder
	{
		private static Random _rand = new Random(Environment.TickCount);
		private PassengerInfoBuilder _pbuilder;
		public FlightConsoleBuilder(PassengerInfoBuilder pbuilder)
		{
			_pbuilder = pbuilder;
		}

		protected override void InitializeDirection()
		{
			Console.Write("Select direction: ");
			for (int i = 0; i <= (int)Direction.Departure; i++)
			{
				Console.Write($"{(Direction)i} - {i} ");
			}
			Direction direction = (Direction)ConsoleHelper.ReadNumber(Console.ReadLine());
			_flight.Direction = direction;
		}

		protected override void InitializeFlightNumber()
		{
			Console.Write("Flight number: ");
			string number = GetRandomString(6);
			Console.WriteLine(number);
			_flight.FlightNumber = number;
		}

		protected override void InitializeDateTime()
		{
			Console.WriteLine("Enter Date and time in next format \"dd.mm.yyyy hh:mm:ss\"");
			Console.Write("Date and time: ");
			DateTime dateTime = ConsoleHelper.ReadDate(Console.ReadLine());
			_flight.DateTime = dateTime;
		}

		protected override void InitializeCity()
		{
			Console.WriteLine("Enter city, max value of city name should be 15 symbols");
			Console.Write("City: ");
			string city = ConsoleHelper.ReadString(15, Console.ReadLine());
			_flight.City = city;
		}

		protected override void InitializeAirline()
		{
			Console.WriteLine("Enter airline, max value of airline name should be 40 symbols");
			Console.Write("Airline: ");
			string airline = ConsoleHelper.ReadString(40, Console.ReadLine());
			_flight.Airline = airline;
		}

		protected override void InitializeTerminal()
		{
			Console.WriteLine("Enter Terminal. Terminal name should be 1 symbols");
			Console.Write("Terminal: ");
			char terminal = ConsoleHelper.ReadString(1, Console.ReadLine()).ToCharArray().First();
			_flight.Terminal = terminal;
		}

		protected override void InitializeFlightStatus()
		{
			Console.WriteLine("Select status:");
			for (int i = 0; i <= (int)Status.InFlight; i++)
				Console.Write($"{(Status)i} - {i} ");
			Status status = (Status)ConsoleHelper.ReadNumber(Console.ReadLine());
			_flight.FlightStatus = status;
		}

		protected override void InitializePassengers()
		{
			_flight.Passengers.Add(_pbuilder.CreatePassenger());
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
	}
}
