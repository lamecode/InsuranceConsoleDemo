using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PojistovnaConsole
{
    public class MenuActions
    {
        public static void HandleKeyPress()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true); //true in ReadKey hides the key pressed

            switch (keyInfo.Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    CustomerListActions.AddCustomer();
                    break;

                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    CustomerListActions.ListCustomers();
                    break;

                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    CustomerListActions.SearchCustomer();
                    break;

                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("\nApplication will be terminated. Thank you for using this demo.");
                    Console.ResetColor();
                    Environment.Exit(0);
                    return;

                default:
                    Console.WriteLine("\nInvalid option.");
                    break;
            }
        }
    }
}