using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ViewLevel
{
     class EditHelper
    {
        protected static void OutputOldValue(Object value)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("Old value: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(value);
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write(" New value: ");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
