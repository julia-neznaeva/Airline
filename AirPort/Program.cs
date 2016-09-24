using AirportLibrary;
using System;
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
            interFace.Menu();
        }

       
    }
}
