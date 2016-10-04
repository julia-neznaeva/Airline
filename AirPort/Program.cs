using AirportDb;
using AirportLibrary;
using PresenterLevel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewLevel;

namespace AirportProgram
{
    class Program
    {
        //static UserInterFace interFace = new UserInterFace();

        static void Main(string[] args)
        {
            Console.WindowWidth = 150;
            Console.Title = "Airport";

            //IView _view = new UserInterFace();
            //Presenter presenter = new Presenter(_view);
            //_view.PrintMenu();

            Class1.DoWork();
            Console.ReadLine();

            

           // interFace.Menu();
        }

       
    }
}
