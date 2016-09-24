using System;
using Airport.Passengers;

namespace Airport
{
    public class ConsolePassengerInfoBuilder : PassengerInfoBuilder
    {

        protected override void InitializeFirstName(Passenger passenger)
        {
			Console.Write("First name: ");
            passenger.Firstname = ConsoleHelper.ReadString(15, Console.ReadLine());
        }

        protected override void InitializeLastName(Passenger passenger)
        {
			Console.Write("Last name: ");
            passenger.Lastname = ConsoleHelper.ReadString(25, Console.ReadLine());
        }
        protected override void InitializeSex(Passenger passenger)
        {
			Console.Write("Sex. Select 0 if female select 1 if male: ");
            passenger.Sex = (Sex)ConsoleHelper.ReadNumber(Console.ReadLine()) ;
        }

        protected override void InitializePassword(Passenger passenger)
        {
			Console.Write("Passport in next format SS NNNNNN: ");
            passenger.Passport = ConsoleHelper.ReadString(9, Console.ReadLine());
        }

        protected override void InitializeBirthday(Passenger passenger)
        {
			Console.Write("Birthdate dd.mm.yyyy: ");
            passenger.Birthday = ConsoleHelper.ReadDate(Console.ReadLine());
        }
        
        protected override void InitializeTicket(Passenger passenger)
        {
			Console.Write("Enter Ticket: ");
           passenger.Ticket = (TicketType)ConsoleHelper.ReadNumber(Console.ReadLine());
        }
    }
}