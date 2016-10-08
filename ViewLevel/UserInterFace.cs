using AirportLibrary.Passengers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirportLibrary.Flights;
using PresenterLevel;
using AirportLibrary;


namespace ViewLevel
{
    public class UserInterFace : IView
    {
        PassengerInfoBuilder _passengerBuilder = new ConsolePassengerInfoBuilder();
        public event EventHandler<EventArgs> DisplayFlightEventRaise = delegate { };
        public event EventHandler<FindFlightEventArgs> SearchFlightByNumberEventRaise = delegate { };
        public event EventHandler<FindFlightEventArgs> SearchFlightByCityEventRaise = delegate { };
        public event EventHandler<FindFlightEventArgs> SearchFlightByDateTimeEventRaise = delegate { };
        public event EventHandler<FindFlightEventArgs> SearchFlightEventRaise = delegate { };
        public event EventHandler<FlightFieldsEventArgs> DeleteFlightEventRaise = delegate { };
        public event EventHandler<FlightEventArgs> AddFlightEventRaise = delegate { };
        public event EventHandler<FlightFieldsEventArgs> EditFlightEventRaise = delegate { };
        public event EventHandler<FlightEventArgs> ReturnEditedFlightEventRaise = delegate { };
        public event EventHandler<PassengerEventArgs> AddPassangerEventRaise = delegate { };
        public event EventHandler<PassengerFieldsEventArgs> EditePassengerEventRaise = delegate { };
        public event EventHandler<PassengerEventArgs> ReturnEditedPassengerEventRaise = delegate { };
        public event EventHandler<PassengerFieldsEventArgs> DeletePassengerEventRaise = delegate { };
        public event EventHandler<FindPassengerEventArgs> SearchPassengerByPassportEventRaise = delegate { };
        public event EventHandler<FindPassengerEventArgs> SearchPassengerByFlightEventRaise = delegate { };
        public event EventHandler<FindPassengerEventArgs> SearchPassengerByNameEventRaise = delegate { };



        public void PrintMenu()
        {
            int selectedMenuClause = 0;
            while (selectedMenuClause < 11)
            {
                Console.WriteLine(@"Please,  type the number:
            1. View flights
            2. Search flights
            3. Add flight
            4. Delete flight
            5. Edit flight
            6. Add passenger
            7. Edit passenger
            8. Delete passenger
            9. Search passenger
            10. Exit
            ");

                selectedMenuClause = int.Parse(Console.ReadLine());
                switch (selectedMenuClause)
                {
                    case 1:
                        DisplayFlightEventRaise(this, EventArgs.Empty);
                        Console.WriteLine("");
                        break;
                    case 2:
                        Console.WriteLine(@"Select search:
            1. By number
            2. By city
            3. By Time
            4. Nearest flight (1 hour)");

                        int selectedFlightSearch = ConsoleHelper.ReadNumber(Console.ReadLine());

                        switch (selectedFlightSearch)
                        {
                            case 1:
                                Console.Write("Enter number flight: ");
                                string number = Console.ReadLine().ToUpper();
                                var findFlightEventArgs = new FindFlightEventArgs();
                                findFlightEventArgs.FlightNumber = number;
                                SearchFlightByNumberEventRaise(this, findFlightEventArgs);
                                break;
                            case 2:
                                Console.Write("Enter city: ");
                                string city = Console.ReadLine();
                                var findFlightEventArgs2 = new FindFlightEventArgs();
                                findFlightEventArgs2.City = city;
                                SearchFlightByCityEventRaise(this, findFlightEventArgs2);
                                break;
                            case 3:
                                Console.Write("Enter date and time: ");
                                DateTime dateTime = ConsoleHelper.ReadDate(Console.ReadLine());
                                var findFlightEventArgs3 = new FindFlightEventArgs();
                                findFlightEventArgs3.DateTime = dateTime;
                                SearchFlightByDateTimeEventRaise(this, findFlightEventArgs3);
                                break;
                            default:
                                Console.Write("Flight on nearest time: ");
                                var findFlightEventArgs4 = new FindFlightEventArgs();
                                SearchFlightEventRaise(this, findFlightEventArgs4);
                                break;
                        }
                        break;
                    case 3:
                        Console.WriteLine("Please fill out the form");
                        FlightInfoBuilder builder = new ConsoleFlightInfoBuilder(_passengerBuilder);
                        AddFlightEventRaise(this, new FlightEventArgs(builder.CreateFlight()));
                        Console.WriteLine();
                        break;
                    case 4:
                        Console.Write("Enter flight number to delete: ");
                        string flightNumber = Console.ReadLine();
                        DeleteFlightEventRaise(this, new FlightFieldsEventArgs(flightNumber));
                        Console.WriteLine();
                        break;
                    case 5:
                        Console.WriteLine("Enter flight number to edit: ");
                        string flNumber = Console.ReadLine();
                        EditFlightEventRaise(this, new FlightFieldsEventArgs(flNumber));
                        Console.WriteLine();
                        break;
                    case 6:
                        Console.WriteLine("Please enter Number of flight to add new passenger: ");
                        string flightNumb = Console.ReadLine();
                        AddPassangerEventRaise(this, new PassengerEventArgs(_passengerBuilder.CreatePassenger(), flightNumb));
                        Console.WriteLine();
                        break;
                    case 7:
                        Console.Write("Please enter passenger passport");
                        string passengerPassport = Console.ReadLine();
                         Console.WriteLine("Please enter fligtNumber: ");
                        EditePassengerEventRaise(this, new PassengerFieldsEventArgs(passengerPassport, null));
                        Console.WriteLine();
                        break;
                    case 8:
                        
                        Console.WriteLine("Please enter passenger passport: ");
                        string info = Console.ReadLine();
                        Console.WriteLine("Please enter fligtNumber: ");
                        DeletePassengerEventRaise(this, new PassengerFieldsEventArgs(info,  Console.ReadLine()));

                        break;
                    case 9:
                        Console.WriteLine(@"Select search:
            1. By name or lastname
            2. By flight number
            3. By passport");
                        int selectedPassengerSearch = ConsoleHelper.ReadNumber(Console.ReadLine());

                        switch (selectedPassengerSearch)
                        {
                            case 1:
                                Console.Write("Enter name or lastname: ");
                                string name = Console.ReadLine();
                                var findPassengerEventArgs = new FindPassengerEventArgs();
                                findPassengerEventArgs.Name = name;
                                SearchPassengerByNameEventRaise(this, findPassengerEventArgs);
                                break;
                            case 2:
                                Console.Write("Enter flight number: ");
                                string number = Console.ReadLine();
                                var findPassengerEventArgs1 = new FindPassengerEventArgs();
                                findPassengerEventArgs1.FlightNumber = number;
                                SearchPassengerByFlightEventRaise(this, findPassengerEventArgs1);
                                break;
                            default:
                                Console.Write("Enter passport: ");
                                string passport = Console.ReadLine();
                                var findPassengerEventArgs2 = new FindPassengerEventArgs();
                                findPassengerEventArgs2.Passport = passport;
                                SearchPassengerByPassportEventRaise(this, findPassengerEventArgs2);
                                break;
                               }
                        break;
                    case 10:
                        break;
                    default:
                        Console.WriteLine("Exit");
                        break;
                }
            }
        }
        public void Print(Flight flight)
        {
            Console.WriteLine(flight);
        }

        public void Print(IEnumerable<Flight> flights)
        {
            flights.ToList().ForEach(x => Print(x));
        }

        public void Print(Passenger passenger)
        {
            Console.WriteLine(passenger); 
        }
         public void Print(IEnumerable<Passenger> passengers)
        {
            passengers.ToList().ForEach(x=>Print(x));
        }

        public void Edite(Flight flight)
        {
            FlightEditHelper flightEditHelper = new FlightEditHelper(flight);
            Flight editedFlight =flightEditHelper.Edite();
            ReturnEditedFlightEventRaise(this, new FlightEventArgs(editedFlight));
        }

        public void Edite(Passenger passenger)
        {
            PassengerEditHelper passengerEditHelper = new PassengerEditHelper(passenger);
            passengerEditHelper.Edit();
        }

        public void PrintError(string message)
        {
            Console.ForegroundColor=ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
