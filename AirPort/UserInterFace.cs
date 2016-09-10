using Airport.Passengers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport
{
    class UserInterFace
    {
        Airport _airport = new Airport();
        PassengerInfoBuilder _passengerBuilder = new PassengerConsoleBuilder();

        public void AddNewFlight()
        {
            Console.WriteLine("Please fill out the form");
            Console.Write("Select direction: ");
            for (int i = 0; i <= (int)Direction.Departure; i++)
            {
                Console.Write($"{(Direction)i} - {i} ");
            }
            Direction direction = (Direction)ConsoleHelper.ReadNumber(Console.ReadLine());
            Console.Write("Flight number: ");
            string number = _airport.GetRandomString(6);
            Console.WriteLine(number);
            Console.WriteLine("Enter Date and time in next format \"dd.mm.yyyy hh:mm:ss\"");
            Console.Write("Date and time: ");
            DateTime dateTime = ConsoleHelper.ReadDate(Console.ReadLine());
            Console.WriteLine("Enter city, max value of city name should be 15 symbols");
            Console.Write("City: ");
            string city = ConsoleHelper.ReadString(15, Console.ReadLine());
            Console.WriteLine("Enter airline, max value of airline name should be 40 symbols");
            Console.Write("Airline: ");
            string airline = ConsoleHelper.ReadString(40, Console.ReadLine());
            Console.WriteLine("Enter Terminal. Terminal name should be 1 symbols");
            Console.Write("Terminal: ");
            char terminal = ConsoleHelper.ReadString(1, Console.ReadLine()).ToCharArray().First();
            Console.WriteLine("Select status:");
            for (int i = 0; i <= (int)Status.InFlight; i++)
                Console.Write($"{(Status)i} - {i} ");
            Status status = (Status)ConsoleHelper.ReadNumber(Console.ReadLine());
            Flight flight = new Flight()
            {
                Direction = direction,
                FlightNumber = number,
                DateTime = dateTime,
                City = city,
                Airline = airline,
                Terminal = terminal,
                FlightStatus = status
            };
            _airport.Add(flight);
        }

        public void AddNewPassengerToFlight(string flightNumber)
        { 
            PrintFlights(_airport.FlightsList.Where(x=>x.FlightNumber==flightNumber).ToList());
            Flight flight = _airport.FindByNumber(flightNumber);
            
            if (_airport.FlightsList.Any(x => x.FlightNumber == flightNumber))
            {
                Console.WriteLine("Please fill out the form.");
                Console.Write("First name: ");
                _passengerBuilder.InitializeFirstName();
                Console.Write("Last name: ");
                _passengerBuilder.InitializeLastName();
                Console.Write("Sex. Select 0 if female select 1 if male: ");
                _passengerBuilder.InitializePassword();
                Console.WriteLine();
                Console.Write("Passport in next format SS NNNNNN:");
                _passengerBuilder.InitializePassword();
                Console.Write("Birthdate dd.mm.yyyy: ");
                _passengerBuilder.InitializeBirthday();
                Console.Write("Enter Ticket: ");
                flight.Passengers.Add(_passengerBuilder.CreatePassenger());

                Console.WriteLine(flight);
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("The flight doesn't exsist");
                Console.ReadLine();
            }

        }

        public void DeletePassenger(Passenger passenger)
        {
        }

        public void DeleteFlight()
        {
            Console.WriteLine("Enter flight number to delete");
            string number = Console.ReadLine();
            _airport.DeleteFlight(_airport.FindByNumber(number));
        }
        
        public void Search()
        {
            int a = ConsoleHelper.ReadNumber(Console.ReadLine());

            switch (a)
            {
                case 1:
                    Console.WriteLine("Enter number flight");
                    string number = Console.ReadLine().ToUpper();
                    Flight flight = _airport.FindByNumber(number);
                    if (flight == null)
                    {
                        Console.WriteLine($"Flight with {number} is not exist");
                    }
                    else {
                        Console.WriteLine(flight);
                    }
                    break;
                case 2:
                    Console.WriteLine("Enter city");
                    string city = Console.ReadLine();
                    List<Flight> result = _airport.FindByCity(city);
                    if (result == null)
                    {
                        Console.WriteLine($"Flight with {city} is not exist");
                    }
                    else
                    PrintFlights(result);
                    break;
                case 3:
                    Console.WriteLine("Enter date and time");
                    DateTime dateTime = ConsoleHelper.ReadDate(Console.ReadLine());
                    List<Flight> reslt = _airport.FindByTime(dateTime);
                    if (reslt == null)
                    {
                        Console.WriteLine($"Flight with {dateTime} is not exist");
                    }
                    PrintFlights(reslt);
                    break;
                default:
                    Console.WriteLine("Flight on nearest time");
                    List<Flight> rslt = _airport.FindByNearestDateTime();
                    if (rslt == null)
                    {
                        Console.WriteLine($"There are not flight on nearest time");
                    }
                    else {
                        PrintFlights(rslt);
                    }
                    break;
            }
        }

        public void PrintFlightDirection(Direction direction )
        {
            Console.WriteLine(string.Format("{0,10}|{1,8}|{2,20}|{3,15}|{4,35}|{5,8}|{6,10}", "Direction ", "Number", "Date Time", "City", "Airline", "Terminal", "Status"));
            PrintFlights(_airport.GetFlightsDirection(direction));
            Console.WriteLine();
        }

        public void PrintAllFlights()
        {
            Console.WriteLine(string.Format("{0,10}|{1,8}|{2,20}|{3,15}|{4,35}|{5,8}|{6,10}", "Direction ", "Number", "Date Time", "City", "Airline", "Terminal", "Status"));
            PrintFlights(_airport.FlightsList);
            Console.WriteLine();
        }
        
        private void PrintFlights(List<Flight> flights)
        {
            Console.WriteLine();
            foreach (Flight flight in flights)
            {
                Console.WriteLine(flight);
                flight.Passengers.ForEach((x) => Console.WriteLine(x));

            }
        }

        public void Edite()
        {
            Console.WriteLine("Enter flight number: ");
            Flight flight = (Flight)_airport.FindByNumber(ConsoleHelper.ReadString(6, Console.ReadLine()));
            Console.WriteLine("Enter new value for fields. If field should not be edited  value press enter");
            DateTime date = EditDateTime(flight.DateTime);
            string city = EditeFlightCity(flight.City);
            string airline = EditAirline(flight.Airline);
            char terminal = EditeTerminal(flight.Terminal);
            Status status = EditeStatus(flight.FlightStatus);
            Flight newFlight = new Flight()
            {
                Direction = flight.Direction,
                FlightNumber = flight.FlightNumber,
                DateTime = date,
                City = city,
                Airline = airline,
                Terminal = terminal,
                FlightStatus = status
            };
            _airport.Edite(newFlight);

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

        private static void OutputOldValue(Object value)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("Old value: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(value);
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write(" New value: ");
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void AddNewPassenger()
        {

        }



        
    }
}
