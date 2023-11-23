using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PojistovnaConsole
{
    internal class Customer
    {
        /// <summary>
        /// First Name. If the customer has more names before last name, use only the first one.
        /// </summary>
        public string FirstName { get; set; }
        public string LastName { get; set; }
        /// <summary>
        /// Phone number, suggested INCLUDING the country code (e.g. NA is +1)
        /// </summary>
        public string Email { get; set; }
        public string Phone { get; set; }
        public int Age { get; set; }
        /// <summary>
        /// Personal Identification Number. Refer to national standards. For US: SSN, For Czechia: Birth Number (Rodne Cislo), etc...
        /// </summary>
        public string PIN { get; set; }
        /// <summary>
        /// Creation date of the customer entity.
        /// </summary>
        public DateTime CreationDate { get; private set; }

        public Customer(string firstName, string lastName, string email, string phone, int age, string PIN)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
            Age = age;
            this.PIN = PIN;
            CreationDate = DateTime.Today;
        }

        public override string ToString()
        {
            return string.Format($"Recorded: {CreationDate.ToString("dd-MMMM-yyyy")} \n{FirstName} {LastName} \n\tE-mail: {Email} \n\tPhone number: {Phone} \n\tAge: {Age} \n\tPIN: {PIN}");
        }
    }
}
