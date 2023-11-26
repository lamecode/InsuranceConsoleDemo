using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            while (true)
            {
                string firstName, lastName, email, phone, PIN;
                int age;

                while (true)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("First name:");
                    Console.ResetColor();
                    firstName = Console.ReadLine();

                    /* REGEX: Disallow numbers.
                     * The entry can contain up to two spaces.
                     * Disallow consecutive spaces. */
                    string namePattern = @"^[^\d]*(?:[^\d ]+[ ]?[^\d ]*){0,2}$"; //EDIT THE NOTE ABOVE IF YOU EDIT THIS LINE!
                    Regex nameRegex = new Regex(namePattern);

                    if (!string.IsNullOrWhiteSpace(firstName) && nameRegex.IsMatch(firstName))
                    {
                        break;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid input. First name cannot be empty and cannot contain numbers and consecutive spaces. Max two spaces per input.");
                        Console.ResetColor();
                    }
                }

                // Validate last name
                while (true)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Last name:");
                    Console.ResetColor();
                    lastName = Console.ReadLine();

                    /* REGEX: The entry cannot consist only of numbers. 
                     * The entry can only end with numbers, not start with them. 
                     * The entry can only contain one undivided number sequence, not more numbers separated by any other symbol. */
                    string namePattern = @"^[a-zA-Z]+(?:[a-zA-Z0-9]*[0-9])?$"; //EDIT THE NOTE ABOVE IF YOU EDIT THIS LINE!
                    Regex nameRegex = new Regex(namePattern);

                    if (!string.IsNullOrWhiteSpace(lastName) && nameRegex.IsMatch(lastName))
                    {
                        break;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid input. Last name cannot be empty, consist only of numbers, start with numbers, or contain multiple divided numbers.");
                        Console.ResetColor();
                    }
                }

                while (true)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("E-mail:");
                    Console.ResetColor();
                    email = Console.ReadLine();

                    if (!string.IsNullOrWhiteSpace(email) && email.Length >= 7 && email.Contains('@') && email.Contains('.'))
                    {
                        break;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("Invalid input. Email must be at least 7 characters long, and it must contain the '@' symbol and a period ('.'). You can type '@' using ");
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.Write(" Right Alt ");
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(" + ");
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.Write(" V ");
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(" or holding down ");
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write(" Left Alt ");
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(" and typing ");
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.Write(" 64 ");
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(" on the numeric keyboard and then releasing the ");
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write(" ALT ");
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(" key.\n");

                    }
                }

                while (true)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Phone Number:");
                    Console.ResetColor();
                    phone = Console.ReadLine();

                    // Define a regular expression pattern for valid phone numbers (at least six numeric digits)
                    string pattern = @"^[0-9()+\[\]. ]{6,}$";
                    Regex regex = new Regex(pattern);

                    if (regex.IsMatch(phone))
                    {
                        if (!phone.StartsWith("+") && !phone.StartsWith("00"))
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("You did not enter a country code. Are you sure you wish to continue? (Y/N)");
                            Console.ResetColor();

                            ConsoleKeyInfo key = Console.ReadKey(true);
                            if (key.Key != ConsoleKey.Y)
                                continue; // Restart the loop if the user does not wish to continue
                        }
                        break;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid input. Please enter a valid phone number with at least six numeric digits, and may include symbols like (, ), [, ], +, ., and space.");
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

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Is the entry correct? (Y/N)");
                Console.ResetColor();

                ConsoleKeyInfo confirmKey = Console.ReadKey(true);
                if (confirmKey.Key == ConsoleKey.Y)
                {
                    // If the entry is CORRECT, exit the loop and finish the method
                    CustomersList.TempDatabase.Add(new Customer(firstName, lastName, email, phone, age, PIN));
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("Entry successfully recorded");
                    Console.ResetColor();
                    DrawMenu.ConfirmContinue();
                    break;
                }
                else if (confirmKey.Key == ConsoleKey.N)
                {
                    // If the entry is INCORRECT, start over by continuing the loop
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine(" Restarting data entry... ");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Please enter Y for yes or N for no.");
                    Console.ResetColor();
                }
            }
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

