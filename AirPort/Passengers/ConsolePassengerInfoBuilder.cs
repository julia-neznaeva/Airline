using System;
using Airport.Passengers;

namespace Airport
{
    internal class ConsolePassengerInfoBuilder : PassengerInfoBuilder
    {

        protected override void InitializeFirstName()
        {
			Console.Write("First name: ");
            _passenger.Firstname = ConsoleHelper.ReadString(15, Console.ReadLine());
        }

        protected override void InitializeLastName()
        {
			Console.Write("Last name: ");
            _passenger.Lastname = ConsoleHelper.ReadString(25, Console.ReadLine());
        }
        protected override void InitializeSex()
        {
			Console.Write("Sex. Select 0 if female select 1 if male: ");
            _passenger.Sex = (Sex)ConsoleHelper.ReadNumber(Console.ReadLine()) ;
        }

        protected override void InitializePassword()
        {
			Console.Write("Passport in next format SS NNNNNN: ");
            _passenger.Passport = ConsoleHelper.ReadString(9, Console.ReadLine());
        }

        protected override void InitializeBirthday()
        {
			Console.Write("Birthdate dd.mm.yyyy: ");
            _passenger.Birthday = ConsoleHelper.ReadDate(Console.ReadLine());
        }
        
        protected override void InitializeTicket()
        {
			Console.Write("Enter Ticket: ");
           _passenger.Ticket = (TicketType)ConsoleHelper.ReadNumber(Console.ReadLine());
        }
    }
}