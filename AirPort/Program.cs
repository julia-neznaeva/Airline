﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport
{
    class Program
    {
        static UserInterFace interFace = new UserInterFace();

        static void Main(string[] args)
        {
            Console.WindowWidth = 150;
            Console.Title = "Airport";

            int a =0;
            while (a < 9) {
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

                a = int.Parse(Console.ReadLine());
                switch (a)
                {
                    case 1:
                        interFace.PrintFlightDirection(Direction.Arrival);
                        interFace.PrintFlightDirection(Direction.Departure);
                        Console.WriteLine("");
                        break;
                    case 2:
                        Console.WriteLine(@"Select search:
            1. By number
            2. By city
            3. By Time
            4. Nearest flight (1 hour)");
                        interFace.Search();
                        Console.WriteLine();
                        break;
                    case 3:
                        interFace.AddNewFlight();
                        Console.WriteLine();
                        break;
                    case 4:
                        interFace.DeleteFlight();
                        Console.WriteLine();
                        break;
                    case 5:
                        interFace.Edite();
                        Console.WriteLine();
                        break;
                    case 6:
                        interFace.AddNewPassenger();
                        Console.WriteLine();
                        break;
                    case 7:
                        interFace.EditPassenger();
                        Console.WriteLine();
                        break;
                    case 8:
                        interFace.DeletePassenger();
                        Console.WriteLine();
                        break;
                    case 9:
                        break;
                    default:
                        Console.WriteLine("Exit");
                        break;
                }
            }
        }
    }
}
