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
        public event EventHandler<PredicateFlightEventArgs> SearchFlightEventRaise = delegate { };
        public event EventHandler<FlightFieldsEventArgs> DeleteFlightEventRaise = delegate { };
        public event EventHandler<FlightEventArgs> AddFlightEventRaise = delegate { };
        public event EventHandler<FlightFieldsEventArgs> EditFlightEventRaise = delegate { };
        public event EventHandler<FlightEventArgs> ReturnEditedFlightEventRaise = delegate { };
        public event EventHandler<PassengerEventArgs> AddPassangerEventRaise = delegate { };
        public event EventHandler<PassengerFieldsEventArgs> EditePassengerEventRaise = delegate { };
        public event EventHandler<PassengerEventArgs> ReturnEditedPassengerEventRaise = delegate { };
        public event EventHandler<PassengerFieldsEventArgs> DeletePassengerEventRaise = delegate { };
        public event EventHandler<PredicatePassengerEventArgs> SearchPassengerEventRaise = delegate { };
        public event EventHandler<FlightFieldsEventArgs> SearchPassengerByFlightEventRaise = delegate { };

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
                                SearchFlightEventRaise(this,  new PredicateFlightEventArgs(x=>x.FlightNumber == number));
                                break;
                            case 2:
                                Console.Write("Enter city: ");
                                string city = Console.ReadLine();
                                SearchFlightEventRaise(this, new PredicateFlightEventArgs(x => x.City == city));
                                break;
                            case 3:
                                Console.Write("Enter date and time: ");
                                DateTime dateTime = ConsoleHelper.ReadDate(Console.ReadLine());
                                SearchFlightEventRaise(this, new PredicateFlightEventArgs(x => x.DateTime.Equals(dateTime)));
                                break;
                            default:
                                Console.Write("Flight on nearest time: ");
                                DateTime startDateTime = DateTime.Now;
                                DateTime finishDateTime = startDateTime.AddHours(1);
                                SearchFlightEventRaise(this, new PredicateFlightEventArgs(x => x.DateTime > startDateTime && x.DateTime < finishDateTime));
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
                        AddPassangerEventRaise(this, new PassengerEventArgs(flightNumb, _passengerBuilder.CreatePassenger()));
                        Console.WriteLine();
                        break;
                    case 7:
                        Console.Write("Please enter passenger passport");
                        string pasengerPassport = Console.ReadLine();
                        EditePassengerEventRaise(this, new PassengerFieldsEventArgs(pasengerPassport));
                        Console.WriteLine();
                        break;
                    case 8:
                        
                        Console.WriteLine("Please enter passenger passport: ");
                        string info = Console.ReadLine();
                        DeletePassengerEventRaise(this, new PassengerFieldsEventArgs(info));
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
                                SearchPassengerEventRaise(this, new PredicatePassengerEventArgs( x => x.Firstname.Contains(name)| x.Lastname.Contains(name)));
                                break;
                            case 2:
                                Console.Write("Enter flight number: ");
                                string number = Console.ReadLine();
                                SearchPassengerByFlightEventRaise(this, new FlightFieldsEventArgs(number));
                                break;
                            default:
                                Console.Write("Enter passport: ");
                                string passport = Console.ReadLine();
                                SearchPassengerEventRaise(this, new PredicatePassengerEventArgs(x => x.Passport.Contains(passport)));
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

        public void Print(List<Flight> flights)
        {
            flights.ForEach(x => Print(x));
        }

        public void Print(Passenger passenger)
        {
            Console.WriteLine(passenger); 
        }
         public void Print(List<Passenger> passengers)
        {
            passengers.ForEach(x=>Print(x));
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
