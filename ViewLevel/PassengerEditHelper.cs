using AirportLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ViewLevel
{
    class PassengerEditHelper: EditHelper
    {
        Passenger _passenger;

        public PassengerEditHelper(Passenger passenger)
        {
            _passenger = passenger;
        }

        public  void EditPassenger()
        {
            Console.WriteLine("Enter new value for fields. If field should not be edited  value press enter");
            _passenger.Firstname = EditFirstName(_passenger.Firstname);
            _passenger.Lastname = EditLastName(_passenger.Lastname);
            _passenger.Sex = EditSex(_passenger.Sex);
            _passenger.Birthday = EditBirthday(_passenger.Birthday);
            _passenger.Ticket = EditeTiket(_passenger.Ticket);

        }

        private  TicketType EditeTiket(TicketType ticket)
        {
            Console.WriteLine();
            return ticket;
        }

        private  DateTime EditBirthday(DateTime birthday)
        {
            Console.WriteLine("Enter birthday");
            string date = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(date))
            {
                return birthday;
            }
            return ConsoleHelper.ReadDate(date);
        }

        private  Sex EditSex(Sex sex)
        {
            Console.WriteLine("Enter 0 if female, 1 if male");
            OutputOldValue(sex);
            int sexValue;
            if (int.TryParse(Console.ReadLine(), out sexValue))
            {
                return (Sex)sexValue;
            }
            return sex;
        }

        private  string EditLastName(string lastname)
        {
            Console.WriteLine("Enter last name");
            OutputOldValue(lastname);
            string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name)) { return lastname; }
            return name;
        }

        private  string EditFirstName(string firstname)
        {
            Console.WriteLine();
            Console.WriteLine("Enter first name");
            OutputOldValue(firstname);
            string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name)) { return firstname; }
            return name;
        }


    }
}
