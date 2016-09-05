using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirPort
{
    class Airport
    {
        const string _forRandString = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        static string[] cities = { "Kiev", "Kharkiv", "Dnipro", "Odesa", "Lviv", "Kryvyi Rih", "Mykolaiv", "Mariupol", "Vinnytsia", "Poltava", "Chernihiv" };
        static string[] airlines = { "Ukraine International Airlines", "Air Urga", "AtlasGlobal UA", "Dniproavia", "Motor Sich Airlines", "Kharkiv Airlines", "Kharkiv Airlines", "Kharkiv Airlines" };
        static int countFlights = 0;
        static Flight[] _flights = new Flight[1000];
        private Random rand = new Random(Environment.TickCount);
        public Flight[] Flights
        {
            get { return _flights; }
        }


        public Airport()
        {
            for (int i = 0; i < 20; i++)
            {
                _flights[i] = CreateNewFlight(rand);
                countFlights++;
            }
        }

        public void DeleteFlight(string flightNumber)
        {
            int indexFlight = 2; //FindFlight(flightNumber);
            for (int i = indexFlight; i < countFlights;)
            {
                _flights[i] = _flights[++i];
            }
            countFlights--;
        }

        public Flight Add()
        {
            countFlights++;
            Console.WriteLine("Please fill out the form");
            Console.Write("Select direction: ");
            for (int i = 0; i <= (int)Direction.Departure; i++)
            {
                Console.Write($"{(Direction)i} - {i} ");
            }
            Direction direction = (Direction)ConsoleHelper.ReadNumber(Console.ReadLine());
            Console.WriteLine("Only leters and digits. Max length is 6.");
            Console.Write("Flight number: ");
            string number = ConsoleHelper.ReadString(6, Console.ReadLine());
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

            return new Flight()
            {
                Direction = direction,
                FlightNumber = number,
                DateTime = dateTime,
                City = city,
                Airline = airline,
                Terminal = terminal,
                FlightStatus = status
            };
        }

        public Flight Edite(Flight flight)
        {
            Console.WriteLine();
            Console.WriteLine("Enter new value for fields. If field should not be edited  value press enter");
            string number = EditFligtNumber(flight.FlightNumber);
            DateTime date = EditDateTime(flight.DateTime);
            string city = EditeFlightCity(flight.City);
            string airline = EditAirline(flight.Airline);
            char terminal = EditeTerminal(flight.Terminal);
            Status status = EditeStatus(flight.FlightStatus);
            return new Flight()
            {
                Direction = flight.Direction,
                FlightNumber = number,
                DateTime = date,
                City = city,
                Airline = airline,
                Terminal = terminal,
                FlightStatus = status
            };
        }

        public void PrintArrivalFlights()
        {
            for (int i = 0; i < countFlights; i++)
            {
                if (_flights[i].Direction == Direction.Arrival)
                    Console.WriteLine(_flights[i]);
            }
        }

        public void PrintDepartureFlights()
        {
            for (int i = 0; i < countFlights; i++)
            {
                if (_flights[i].Direction == Direction.Departure)
                    Console.WriteLine(_flights[i]);
            }
        }

        public void PrintAllFlights()
        {
            for (int i = 0; i < countFlights; i++)
            {
                Console.WriteLine(string.Format("{0,3}{1}",i, _flights[i]));
            }
        }

        
        public bool FindByNumber(string flightNumber, out Flight flight)
        {
            for (int i = 0; i < countFlights; i++)
            {
                if (_flights[i].FlightNumber == flightNumber)
                {
                    flight = _flights[i];
                    return true;
                }
                i++;
            }
            flight = new Flight();
            return false;
        }

        //public bool FindByCity(string city, out Flight[] flight)
        //{
        //    for (int i = 0; i < countFlights; i++)
        //    {
        //        if (flights[i].City == city)
        //        {
        //            flight = flights[i];
        //            return true;
        //        }
        //        i++;
        //    }
        //    flight = new Flight();
        //    return false;
        //}

        //public bool FindByTime(DateTime dateTime, out Flight[] flight)
        //{
        //    for (int i = 0; i < countFlights; i++)
        //    {
        //        if (flights[i].DateTime == dateTime)
        //        {
        //            flight = flights[i];
        //            return true;
        //        }
        //        i++;
        //    }
        //    flight = new Flight();
        //    return false;
        //}

        #region helper methods for random creation flights

        public Flight CreateNewFlight(Random rand)
        {

            Direction direction = (Direction)rand.Next(0, 2);
            string flightNumber = GetRandomString(6, rand);
            DateTime dateTime = GetRandomTime(rand);
            string city = GetRandomCity(rand);
            string airline = GetRandomAirline(rand);
            char terminal = GetRandomTerminal(rand);
            Status flightStatus = (Status)rand.Next(0, 9);

            return new Flight()
            {
                Direction = direction,
                FlightNumber = flightNumber,
                City = city,
                Airline = airline,
                Terminal = terminal,
                FlightStatus = flightStatus,
                DateTime = dateTime

            };
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
            ;
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

        private string EditFligtNumber(string flightNumber)
        {
            Console.WriteLine();
            Console.WriteLine("Flight number:");
            Console.WriteLine("Only leters and digits. Max length is 6.");
            string newNumberFlight = string.Empty;
            do
            {
                Console.Write("Old value: ");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write(string.Format("{0:20} ", flightNumber));
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("New value: ");
                newNumberFlight = Console.ReadLine();
                if (newNumberFlight.Length > 6 || string.IsNullOrEmpty(newNumberFlight))
                {
                    Console.WriteLine("Value is not valid. Try again");
                }

            } while (newNumberFlight.Length > 6);

            if (newNumberFlight != "")
            {
                return newNumberFlight.ToUpper();
            }
            return flightNumber;
        }

        private static DateTime GetRandomTime(Random rand)
        {
            DateTime date = DateTime.Today;
            date = date.AddDays(rand.Next(0, 32));
            date = date.AddMinutes(rand.Next(0, 1441));
            return date;
        }

        private static char GetRandomTerminal(Random rand)
        {
            char result = _forRandString[rand.Next(0, _forRandString.Length - 9)];
            return result;
        }

        private static string GetRandomAirline(Random rand)
        {
            return airlines[rand.Next(0, airlines.Length)];
        }

        private static string GetRandomCity(Random rand)
        {
            return cities[rand.Next(0, cities.Length)];
        }

        private static string GetRandomString(int length, Random rand)
        {
            char[] str = new char[length];
            for (int i = 0; i < length; i++)
            {
                str[i] = _forRandString[rand.Next(0, _forRandString.Length)];
            }
            return new string(str);

        }
        #endregion


    }

}
