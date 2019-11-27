using LibraryCatalog.Code.CustomExceptions;
using System;
using System.Collections.Generic;
using System.Xml;

namespace LibraryCatalogueProject
{
    class Program
    {
        #region XML FILE
        public static void ReadFromXML()
        {
            var readXML = XmlReader.Create(@"C:\WorkSpace\LibraryCatalogue.xml");
            while (readXML.Read())
            {
                switch (readXML.Name.ToString())
                {
                    case "ISBN":
                        Console.WriteLine("ISBN: " + readXML.ReadString());
                        break;
                    case "Type":
                        Console.WriteLine("Type: " + readXML.ReadString());
                        break;
                    case "Title":
                        Console.WriteLine("Title: " + readXML.ReadString());
                        break;
                }
            }
        }

        #endregion
        public static void Main(string[] args)
        {
            // 1. Create a new library and load library catalogue
            var booksLibrary = new Library(new PopulateCatalogue().GetItemsFromXmlDocument(@"C:\WorkSpace\LibraryCatalogue.xml"));

            // 2. Create a new customer
            var customer = new Customer("John", "Smith");

            // Checking out books:
            var bookName = "50000003"; // Magazine --> "Girl's World"
            CheckoutBook(customer, booksLibrary, bookName);
            Console.WriteLine("*****************");

            bookName = "70000011"; // NewReleaseBook --> "The Girl Who Lived Twice"
            CheckoutBook(customer, booksLibrary, bookName);
            Console.WriteLine("*****************");

            booksLibrary.SetDay(DateTime.Today.AddDays(2));

            //bookName = "70000011"; // NewReleaseBook --> "The Girl Who Lived Twice"
            //CheckoutBook(customer, booksLibrary, bookName);
            Console.WriteLine("*****************");

            bookName = "48039486"; // Book --> "Harry Potter and the Deathly Hallows"
            CheckoutBook(customer, booksLibrary, bookName);
            Console.WriteLine("*****************");

            // Add Days:
            booksLibrary.SetDay(DateTime.Today.AddDays(6));

            // Get book customer has:
            Console.WriteLine("Customer books: ");
            booksLibrary.CustomerItems(customer.FullName);
            Console.WriteLine("*****************");

            // Get overdue books:
            Console.WriteLine("Overdue books: ");
            booksLibrary.OverdueItemsByCustomerName(customer.FullName);
            Console.WriteLine("*****************");

            // Returning books:
            booksLibrary.ReturnAnItem("50000000");
            booksLibrary.ReturnAnItem("70000011");
            booksLibrary.ReturnAnItem("48039486");

            Console.ReadLine();
        }

        public static void CheckoutBook(Customer customer, Library libraryCatalogue, string bookName)
        {
            try
            {
                if (libraryCatalogue.CheckItemAvailability(bookName))
                {
                    var book = libraryCatalogue.CheckOutAnItem(bookName, customer.FullName);
                }

            }
            catch (LibraryItemAlreadyCheckedOutException ex)
            {
                Console.WriteLine($"Sorry, '{bookName}' book had been taken! " +
               $"It should be back in {((ex.LibraryItem.DayCheckedOut + ex.LibraryItem.LengthOfCheckoutPeriod - DateTime.Today)).Value.Days} days.\n");

                throw;
            }

            //if (libraryCatalogue.CheckBookAvailability(bookName))
            //{
            //    var book = libraryCatalogue.CheckOutBook(bookName, customer.FullName);
            //}
        }
    }
}
