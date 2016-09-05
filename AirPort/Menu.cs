using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirPort
{
    class Menu
    {
        UserInterFace interFace = new UserInterFace();

        public void InputMenu()
        {
            int a;
            Console.WriteLine(@"Please,  type the number:
            1. View flights
            2. Search flights
            3. Add new flight
            4. Delete some flight
            5. Edit flight
            6. Exit
            ");

            a = int.Parse(Console.ReadLine());
            switch (a)
            {
                case 1:
                    interFace.PrintArrivalFlight();
                    interFace.PrintDepartureFlight();
                    Console.WriteLine("");
                    break;
                case 2:
                    interFace.PrintAllFlights();
                    interFace.Search();
                    Console.WriteLine("");
                    break;
                case 3:
                    interFace.AddNewFlight();
                    interFace.PrintAllFlights();
                    Console.WriteLine("");
                    break;
                case 4:
                    interFace.PrintAllFlights();
                    interFace.DeleteFlight();
                    interFace.PrintAllFlights();
                    Console.WriteLine("");
                    break;
                case 5:
                    
                    Console.WriteLine("");
                    break;

                default:
                    Console.WriteLine("Exit");
                    break;
            }
            Console.WriteLine("Press any key");
            Console.ReadLine();

        }
    }




}


