using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PojistovnaConsole
{
    internal class DrawMenu
    {
        /// <summary>
        /// Draws colored header as intro.
        /// </summary>
        /// <param name="companyName">Name of your company</param>
        public static void Header(string companyName)
        {
            StripedLine(companyName.Length);
            Console.WriteLine(companyName);
            StripedLine(companyName.Length);
        }

        /// <summary>
        /// Creates a striped line.
        /// </summary>
        /// <param name="amount">Amount of dashes on single line</param>
        private static void StripedLine(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                if (i % 2 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("-");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("-");
                }
            }
            Console.WriteLine();
            Console.ResetColor();
        }

        /// <summary>
        /// Main navigation menu with all main app functions.
        /// </summary>
        public static void ExecutionMenu()
        {
            while (true)
            {
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Press a key to start an action:");
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("[ 1 ]");
                Console.ResetColor();
                Console.WriteLine("\tAdd new customer");

                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("[ 2 ]");
                Console.ResetColor();
                Console.WriteLine("\tList all customers");

                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("[ 3 ]");
                Console.ResetColor();
                Console.WriteLine("\tSearch for a specific customer");

                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("[ 4 ]");
                Console.ResetColor();
                Console.WriteLine("\tTerminate the application");
                Console.ResetColor();

                MenuActions.HandleKeyPress();
            }
        }

        /// <summary>
        /// Animation that says "Press any key to continue" and waits for user before clearing the console. Console Clear not included!
        /// </summary>
        /// <param name="character">Takes any character that will be animated. Leave empty for ">"</param>
        public static void ConfirmContinue(char character = '>')
        {
            Console.CursorVisible = false;
            Console.Write("Press any key to continue ");

            while (!Console.KeyAvailable)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(character + "  ");
                Console.Write(new string('\b', 3));
                Thread.Sleep(200);
                Console.Write(" " + character + " ");
                Console.Write(new string('\b', 3));
                Thread.Sleep(200);
                Console.Write("  " + character);
                Console.Write(new string('\b', 3));
                Thread.Sleep(200);
                Console.Write("   ");
                Console.Write(new string('\b', 3));
                Thread.Sleep(400);
                Console.ResetColor();
            }

            while (Console.KeyAvailable)
            {
                Console.ReadKey(true);
            }
        }
    }
}
