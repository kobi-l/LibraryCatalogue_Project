using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day12_Inheritance
{
    public class Person
    {
        protected string FirstName;
        protected string LastName;
        protected int IdNumber;

        // Constructor
        public Person(string firstName, string lastName, int identification)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.IdNumber = identification;
        }

        // Print person data
        public void PrintPerson()
        {
            Console.WriteLine($"Name: {LastName}, {FirstName}" + "\nID: " + $"{IdNumber}");
        }
    }
}
