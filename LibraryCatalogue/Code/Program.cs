using LibraryCatalogueProject;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;

namespace LibraryCatalogueProject
{
    class Program
    {
        #region XML FILE

        // using XmlDocument 
        public static Dictionary<string, Book> GetBooksUsingXmlDocument()
        {
            var newDictionary = new Dictionary<string, Book>();

            XmlDocument doc = new XmlDocument();
            doc.Load(@"C:\WorkSpace\LibraryCatalogue.xml");

            XmlNode root = doc.SelectSingleNode("LibraryItems");
            XmlNodeList node = root.SelectNodes("Item");

            foreach (XmlNode item in node)
                newDictionary.Add(item.ChildNodes[0].InnerText, new Book((item.ChildNodes[2].InnerText), (item.ChildNodes[1].InnerText)));

            // write to console
            //foreach (var book in newDictionary)
            //{
            //    if (book.Value.ItemType == "NewReleaseBook")
            //        Console.WriteLine($"New Release Books: {book.Key} - {book.Value.Title}");

            //    if (book.Value.ItemType == "Magazine")
            //        Console.WriteLine($"Magazines: {book.Key} - {book.Value.Title}");

            //    if (book.Value.ItemType == "Book")
            //        Console.WriteLine($"Books: {book.Key} - {book.Value.Title}");
            //    Console.Write(Environment.NewLine);
            //}

            return newDictionary;
        }

        // read from XML
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
            var booksLibrary = new LibraryCatalogue(GetBooksUsingXmlDocument());

            // 2. Create a new customer
            var customer = new Customer("John", "Smith");

            // Checking out books:
            var bookName = "500000035"; // Magazine --> "Girl's World"
            CheckoutBook(customer, booksLibrary, bookName);
            Console.WriteLine("*****************");

            bookName = "70000011"; // NewReleaseBook --> "The Girl Who Lived Twice"
            CheckoutBook(customer, booksLibrary, bookName);
            Console.WriteLine("*****************");

            bookName = "48039486"; // Book --> "Harry Potter and the Deathly Hallows"
            CheckoutBook(customer, booksLibrary, bookName);
            Console.WriteLine("*****************");

            // Add Days:
            booksLibrary.SetDay(DateTime.Today.AddDays(6));

            // Get book customer has:
            Console.WriteLine("Customer books: ");
            booksLibrary.CustomerBooks(customer.FullName);
            Console.WriteLine("*****************");

            // Get overdue books:
            booksLibrary.OverdueBooksByCustomerName(customer.FullName);
            Console.WriteLine("*****************");

            // Returning books:
            booksLibrary.ReturnBook("50000000");
            booksLibrary.ReturnBook("70000011");
            booksLibrary.ReturnBook("48039486");

            Console.ReadLine();
        }

        public static void CheckoutBook(Customer customer, LibraryCatalogue libraryCatalogue, string bookName)
        {
            if (libraryCatalogue.CheckBookAvailability(bookName))
            {
                var book = libraryCatalogue.CheckOutBook(bookName, customer.FullName);
            }
        }
    }
}
