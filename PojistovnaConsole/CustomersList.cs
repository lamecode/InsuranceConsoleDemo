using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PojistovnaConsole
{
    internal class CustomersList
    {
        private static List<Customer> tempDatabase;

        // Public property to access TempDatabase
        public static List<Customer> TempDatabase
        {
            get
            {
                // Initialize TempDatabase if it's null
                if (tempDatabase == null)
                {
                    tempDatabase = new List<Customer>();
                }
                return tempDatabase;
            }
        }
        /// <summary>
        /// Adds a customer in plain simple way.
        /// </summary>
        /// <param name="customer"></param>
        public void AddCustomer(Customer customer)
        {
            TempDatabase.Add(customer);
        }

        /// <summary>
        /// Lists customers in the database. Each even record is yellow to differ from other records.
        /// </summary>
        public static void ListCustomers()
        {
            if (TempDatabase.Count <= 0)
            {
                // No results found
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("The database is empty or no results could be shown.");
                Console.ResetColor();
            }
            else
            {
                for (int i = 0; i < TempDatabase.Count; i++)
                {
                    if (i % 2 == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }

                    Console.WriteLine(TempDatabase[i]);
                }
            }

            Console.ResetColor();
            DrawMenu.ConfirmContinue();
        }
        /// <summary>
        /// Search customer databse for a specific customer.
        /// </summary>
        /// <param name="firstName">Customer's first name</param>
        /// <param name="lastName">Customer's second name</param>
        public static void Search(string firstName, string lastName)
        {
            List<Customer> results;

            if (!string.IsNullOrWhiteSpace(firstName) && !string.IsNullOrWhiteSpace(lastName))
            {
                // Both first name and last name are provided, searching for exact match
                results = TempDatabase.FindAll(s => s.FirstName == firstName && s.LastName == lastName);
            }
            else if (!string.IsNullOrWhiteSpace(firstName))
            {
                // Only first name is provided, searching for a partial match in first name
                results = TempDatabase.FindAll(s => s.FirstName.Contains(firstName));
            }
            else if (!string.IsNullOrWhiteSpace(lastName))
            {
                // Only last name is provided, searching for a partial match in last name
                results = TempDatabase.FindAll(s => s.LastName.Contains(lastName));
            }
            else
            {
                // No search criteria provided
                Console.WriteLine("Please provide at least one search criteria (first name or last name).");
                return;
            }

            if (results.Count > 0)
            {
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write($"There are {results.Count} entities that match your query. Those are: ");
                Console.ResetColor();
                Console.WriteLine();
                int resultsIndex = 0;
                foreach (Customer customer in results)
                {
                    if (resultsIndex % 2 == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                    }
                    Console.WriteLine(customer);
                    resultsIndex++;
                }
                Console.ResetColor();
                DrawMenu.ConfirmContinue();
            }
            else
            {
                // No results found
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("Search ended with 0 results.");
                Console.ResetColor();
                DrawMenu.ConfirmContinue();
            }
        }

    }
}
