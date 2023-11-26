using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PojistovnaConsole
{
    internal class CustomerListActions
    {
        /// <summary>
        /// Creates new customer using given information.
        /// </summary>
        public static void AddCustomer()
        {
            string firstName, lastName, email, phone, PIN;
            int age;

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("First name:");
                Console.ResetColor();
                firstName = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(firstName))
                {
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. First name cannot be empty.");
                    Console.ResetColor();
                }
            }

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Last name:");
                Console.ResetColor();
                lastName = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(lastName))
                {
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Last name cannot be empty.");
                    Console.ResetColor();
                }
            }

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("E-mail:");
                Console.ResetColor();
                email = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(email) && email.Contains('@'))
                {
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Email cannot be empty, and it must contain the '@' symbol. You can type the symbol using Right Alt + V or holding down ALT key, typing 64 on numeric keyboard and then releasing ALT key..");
                    Console.ResetColor();
                }
            }

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Phone Number:");
                Console.ResetColor();
                phone = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(phone))
                {
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Phone number cannot be empty.");
                    Console.ResetColor();
                }
            }

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Age:");
                Console.ResetColor();
                string ageInput = Console.ReadLine();
                if (int.TryParse(ageInput, out age) && age > 0 && age < 110)
                {
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Please enter a valid age using numbers only (1-109).");
                    Console.ResetColor();
                }
            }

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Personal identification number:");
                Console.ResetColor();
                PIN = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(PIN))
                {
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Personal identification number cannot be empty.");
                    Console.ResetColor();
                }
            }

            CustomersList.TempDatabase.Add(new Customer(firstName, lastName, email, phone, age, PIN));
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Entry successfuly recorded");
            Console.ResetColor();
            DrawMenu.ConfirmContinue();
        }

        /// <summary>
        /// Will list all customers in database.
        /// </summary>
        public static void ListCustomers()
        {
            CustomersList.ListCustomers();
        }

        /// <summary>
        /// Will search for a specific customer.
        /// </summary>
        public static void SearchCustomer()
        {
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(" Search mode ");
            Console.WriteLine(" Use part of FIRST and/or LAST name. Initials search is supported. Using both names will produce more specific results. ");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("First name:");
            string firstName = Console.ReadLine();
            Console.WriteLine("Last name:");
            string lastName = Console.ReadLine();

            CustomersList.Search(firstName, lastName);
        }
    }
}

