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

			// 3. Checking out items:
			var itemKey1 = "50000003"; // Magazine --> "Girl's World"
			CheckoutBook(customer, booksLibrary, itemKey1);
			Console.WriteLine("*****************");

			// 3.1 Adding '50000003' second time: <-- Expected message  - 'Girl's World' had been taken out! It should be back in 7 days.
			CheckoutBook(customer, booksLibrary, itemKey1);
			Console.WriteLine("*****************");

            // 3.2 Adding item that doesn't exists: <-- Expected EXCEPTION message - '500000033' item does not exist in our library.
            var itemKey2 = "500000033"; 
			CheckoutBook(customer, booksLibrary, itemKey2);
			Console.WriteLine("*****************");

			// 3.3 Adding a NewReleaseBook --> "The Guardians"
			var itemKey3 = "70000010"; 
			CheckoutBook(customer, booksLibrary, itemKey3);
			Console.WriteLine("*****************");

			// 3.4 Adding a Book --> "Harry Potter and the Deathly Hallows"
			var itemKey4 = "48039486"; 
			CheckoutBook(customer, booksLibrary, itemKey4);
			Console.WriteLine("*****************");

			// 3.5 Adding a DVD --> "Men In Black"
			var itemKey5 = "211504DV";  
			CheckoutBook(customer, booksLibrary, itemKey5);
			Console.WriteLine("*****************");

			// 4. Get book customer has:
			Console.WriteLine("Customer Items: ");
			foreach (var item in booksLibrary.CustomerItems(customer.FullName))
			{
				Console.WriteLine(item.ItemMessage);
			}
			Console.WriteLine("*****************");

			// 5. Get overdue books:
			Console.WriteLine("Overdue items: ");
			foreach (var item in booksLibrary.OverdueItemsByCustomerName(customer.FullName, DateTime.Today.AddDays(6)))
			{
				Console.WriteLine(item.ItemMessage);
			}
			Console.WriteLine("*****************");


			// 6. Returning books:
			Console.WriteLine("Returned items: ");
			var date = DateTime.Today.AddDays(6);
			ReturnMaterials(booksLibrary, itemKey1, date); // <-- Expected message - 'Item returned.Thank you!'
			ReturnMaterials(booksLibrary, itemKey2, date); // <-- Expected EXCEPTION message - '500000033' item does not exist in our library.
            ReturnMaterials(booksLibrary, itemKey3, date); // <-- Expected message - 'You owe the library $1.5 because 'The Guardians' is 1 days overdue. Item returned. Thank you!'
			ReturnMaterials(booksLibrary, itemKey4, date); // <-- Expected message - 'Item returned.Thank you!'
			ReturnMaterials(booksLibrary, itemKey5, date); // <-- Expected message - 'You owe the library $3.5 because 'Men In Black' is 3 days overdue. Item returned. Thank you!'

			Console.ReadLine();
		}

		public static void CheckoutBook(Customer customer, Library libraryCatalogue, string itemISBN)
		{
			try
			{
				if (libraryCatalogue.CheckItemAvailability(itemISBN))
				{
					var item = libraryCatalogue.CheckOutAnItem(itemISBN, customer.FullName, DateTime.Today);
					Console.WriteLine($"You just checked out '{item.Title}'. " +
					$"\nNote: Please return it in {item.LengthOfCheckoutPeriod.TotalDays} days.\n");
				}
			}
			catch (LibraryItemAlreadyCheckedOutException ex)
			{
				Console.WriteLine(ex.Message);
			}
			catch (LibraryItemDoesntExistException ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		public static void ReturnMaterials(Library libraryCatalogue, string itemKey, DateTime date)
		{
			try
			{
				Console.WriteLine(libraryCatalogue.ReturnAnItem(itemKey, date));
			}
			catch (LibraryItemDoesntExistException ex)
			{

				Console.WriteLine(ex.Message);
			}
		}
	}
}
