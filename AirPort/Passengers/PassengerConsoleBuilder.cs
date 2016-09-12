using System;
using Airport.Passengers;

namespace Airport
{
    internal class PassengerConsoleBuilder : PassengerInfoBuilder
    {

        public override void InitializeFirstName()
        {
            _passenger.Firstname = ConsoleHelper.ReadString(15, Console.ReadLine());
        }

        public override void InitializeLastName()
        {
            _passenger.Lastname = ConsoleHelper.ReadString(25, Console.ReadLine());
        }
        public override void InitializeSex()
        {
            _passenger.Sex = (Sex)ConsoleHelper.ReadNumber(Console.ReadLine()) ;
        }

        public override void InitializePassword()
        {
            _passenger.Passport = ConsoleHelper.ReadString(9, Console.ReadLine());
        }

        public override void InitializeBirthday()
        {
            _passenger.Birthday = ConsoleHelper.ReadDate(Console.ReadLine());
        }
        
        public override void InitializeTicket()
        {
           _passenger.Ticket = (TicketType)ConsoleHelper.ReadNumber(Console.ReadLine());
        }
    }
}