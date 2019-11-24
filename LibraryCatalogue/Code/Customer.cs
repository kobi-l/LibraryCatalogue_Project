using LibraryCatalog.Code;
using LibraryCatalogueProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCatalogueProject
{
    public class Customer : ICustomer
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string FullName => FirstName + " " + LastName;

        //private string myVar;
        //public string ICustomer.FullName
        //{
        //    get { return FirstName + " " + LastName; }
        //    set { myVar = value; }
        //}

        public Customer(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
