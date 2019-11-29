using LibraryCatalog.Code.CustomExceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
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
			string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"../../../LibraryCatalogue.xml");

			var booksLibrary = new Library(new PopulateCatalogue().GetItemsFromXmlDocument(path));
			//var booksLibrary = new Library(new PopulateCatalogue().GetItemsFromXmlDocument(@"LibraryCatalogue.xml"));
			//var booksLibrary = new Library(new PopulateCatalogue().GetItemsFromXmlDocument(@"C:\dev\Other Projects\Kobi\LibraryCatalogue_Project\LibraryCatalogue.xml"));

			// 2. Create a new customer
			var customer = new Customer("John", "Smith");

			// Checking out items:
			var itemKey = "50000003"; // Magazine --> "Girl's World"
			CheckoutBook(customer, booksLibrary, itemKey);
			Console.WriteLine("*****************");

            CheckoutBook(customer, booksLibrary, itemKey);
            Console.WriteLine("*****************");

            itemKey = "500000033"; // Magazine --> "Girl's World"
            CheckoutBook(customer, booksLibrary, itemKey);
            Console.WriteLine("*****************");

            itemKey = "70000010"; // NewReleaseBook --> "The Guardians"
            CheckoutBook(customer, booksLibrary, itemKey);
			Console.WriteLine("*****************");

			itemKey = "48039486"; // Book --> "Harry Potter and the Deathly Hallows"
			CheckoutBook(customer, booksLibrary, itemKey);
			Console.WriteLine("*****************");

            itemKey = "211504DV"; // DVD --> "Men In Black"
            CheckoutBook(customer, booksLibrary, itemKey);
            Console.WriteLine("*****************");

			// Get book customer has:
			Console.WriteLine("Customer Items: ");

            foreach (var item in booksLibrary.CustomerItems(customer.FullName))
            {
                Console.WriteLine(item);
            }
            //Console.WriteLine(booksLibrary.CustomerItems(customer.FullName));
			Console.WriteLine("*****************");

            // Add Days:
            booksLibrary.SetDay(DateTime.Today.AddDays(6));

            // Get overdue books:
            Console.WriteLine("Overdue items: ");
            Console.WriteLine(booksLibrary.OverdueItemsByCustomerName(customer.FullName));
			Console.WriteLine("*****************");

            // Returning books:
            Console.WriteLine(booksLibrary.ReturnAnItem("50000000")); // <-- item that doesn't exist.
            Console.WriteLine(booksLibrary.ReturnAnItem("50000003"));
            Console.WriteLine(booksLibrary.ReturnAnItem("70000010"));
            Console.WriteLine(booksLibrary.ReturnAnItem("48039486"));
            Console.WriteLine(booksLibrary.ReturnAnItem("211504DV"));

            Console.ReadLine();
		}

		public static void CheckoutBook(Customer customer, Library libraryCatalogue, string itemName)
		{
			try
			{
				if (libraryCatalogue.CheckItemAvailability(itemName, out var message))
				{
                    var book = libraryCatalogue.CheckOutAnItem(itemName, customer.FullName);
                    Console.WriteLine($"You just checked out '{book.Title}'. " +
                    $"\nNote: Please return it in {book.LengthOfCheckoutPeriod.TotalDays} days.\n");
                }
                else
                    Console.WriteLine(message);
			}
			catch (LibraryItemAlreadyCheckedOutException ex)
			{

                Console.WriteLine(ex.Message);
                //Console.WriteLine($"Sorry, '{itemName}' book had been taken! " +
			   //$"It should be back in {((ex.LibraryItem.DayCheckedOut + ex.LibraryItem.LengthOfCheckoutPeriod - DateTime.Today)).Value.Days} days.\n");

				//throw;
			}

			//if (libraryCatalogue.CheckBookAvailability(bookName))
			//{
			//    var book = libraryCatalogue.CheckOutBook(bookName, customer.FullName);
			//}
		}
	}
}
