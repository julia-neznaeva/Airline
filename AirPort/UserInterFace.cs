using Airport.Passengers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirPort.Flights;

namespace Airport
{
    class UserInterFace
    {
        Airport _airport = new Airport();
        PassengerInfoBuilder _passengerBuilder = new ConsolePassengerInfoBuilder();
        public void AddNewFlight()
        {
            Console.WriteLine("Please fill out the form");
			FlightInfoBuilder builder = new ConsoleFlightInfoBuilder(_passengerBuilder);
            
			_airport.Add(builder.CreateFlight());
        }

        public void AddNewPassenger()
        {
            Console.WriteLine("Please enter Number of flight to add new passenger");
            String flightNumber = Console.ReadLine();
            Flight flight =_airport.FindByNumber(flightNumber);
            if (flight == null)
                Console.WriteLine($"The flight with the {flightNumber} flight number does not exsist");
            else
            {
                flight.AddPassenger( _passengerBuilder.CreatePassenger());
            }
            

        }
               
        public void DeletePassenger(string passportNumber)
        {
            Passenger passenger = new Passenger();
            foreach (var flight in _airport.FlightsList)
            {
                passenger = flight.Passengers.Where(x => x.Passport == passportNumber).FirstOrDefault();
                flight.DeletePassanger(passenger);
                break;
            }
        }
        
        public void DeleteFlight()
        {
            Console.WriteLine("Enter flight number to delete");
            string number = Console.ReadLine();
            _airport.DeleteFlight(_airport.FindByNumber(number));
        }

        public void EditPassenger()
        {
            Console.WriteLine("Please enter passenger passport number:");
            string number = ConsoleHelper.ReadString(9, Console.ReadLine());
            Passenger passenger = _airport.FindPassengerPassport(number).FirstOrDefault();
            Console.WriteLine("Enter new value for fields. If field should not be edited  value press enter");
            passenger.Firstname = EditFirstName(passenger.Firstname);
            passenger.Lastname = EditLastName(passenger.Lastname);
            passenger.Sex = EditSex(passenger.Sex);
            passenger.Birthday = EditBirthday(passenger.Birthday);
            passenger.Ticket = EditeTiket(passenger.Ticket);

        }

        private TicketType EditeTiket(TicketType ticket)
        {
            Console.WriteLine();
            return ticket;
        }

        private DateTime EditBirthday(DateTime birthday)
        {
            Console.WriteLine("Enter birthday");
            string date = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(date))
            {
                return birthday;
            }
            return ConsoleHelper.ReadDate(date);
        }

        private Sex EditSex(Sex sex)
        {
            Console.WriteLine("Enter 0 if female, 1 if male");
            OutputOldValue(sex);
            int sexValue;
            if( int.TryParse(Console.ReadLine(), out sexValue))
            {
                return (Sex)sexValue;
            }
            return sex;

        }

        private string EditLastName(string lastname)
        {
            Console.WriteLine("Enter last name");
            OutputOldValue(lastname);
            string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name)) { return lastname; }
            return name;
        }

        private string EditFirstName(string firstname)
        {
            Console.WriteLine();
            Console.WriteLine("Enter first name");
            OutputOldValue(firstname);
            string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name)) { return firstname; }
            return name;
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
            
            PrintFlights(_airport.GetFlightsDirection(direction));
            Console.WriteLine();
        }

        public void PrintAllFlights()
        {
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
        
    }
}
