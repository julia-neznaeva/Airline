using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace AirportLibrary
{
    public class ConsoleHelper
    {
        public static string ReadString(int length, string str)
        {
            do
            {
                if (str.Length > length)
                {
                    Console.WriteLine("Value is not valid. Try again");
                    str = Console.ReadLine();
                }

            } while (str.Length > length);
            return str.ToUpper();
        }

        public static int ReadNumber(string str)
        {
            int result;
            while (true)
            {
                if (int.TryParse(str, out result))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Value is not valid. Try again");
                    str = Console.ReadLine();
                }
            }

            return result;
        }

        public static DateTime ReadDate(string str)
        {
            DateTime result;

            while (!DateTime.TryParse(str, new CultureInfo("ru-RU"), DateTimeStyles.None,  out result))
            {
                Console.WriteLine("Value is not valid. Try again");
                str = Console.ReadLine();

            }
               return result;

        }

    }
}
