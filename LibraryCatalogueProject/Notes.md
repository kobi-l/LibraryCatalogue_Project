using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCatalog
{
	class Notes
	{
	#region BOOKS LIBRARY

		public static Dictionary<string, Book> GetBooks()
		{
		    // Creating a dictionary using the Collection Initializer and returning it:
		    return new Dictionary<string, Book>()
		    {
		        { "Book 1", new Book("Harry Potter and the Sorcerer's Stone", 544, 48039485) },
		        { "Book 2", new Book("Harry Potter and the Chamber of Secrets", 367, 48039486)},
		        { "Book 3", new Book("Harry Potter and the Prisoner of Azkaban", 467, 48039487)},
		        { "Book 4", new Book("Harry Potter and the Goblet of Fire", 465, 48039488)},
		        { "Book 5", new Book("Harry Potter and the Order of the Phoenix", 433, 48039489)},
		        { "Book 6", new Book("Harry Potter and the Half-Blood Prince", 245, 48039410)},
		        { "Book 7", new Book("Harry Potter and the Deathly Hallows", 245, 48039410)}

		    };
		}
		#endregion


		#region XML FILE

		// using XmlReader ???
		public static Dictionary<string, string> GetBooksUsingXmlReader()
		{
			var newDictionary = new Dictionary<string, string>();

			var readXML = XmlReader.Create(@"C:\WorkSpace\LibraryCatalogue.xml");

			string key, value;
			while (readXML.Read())
			{
				switch (readXML.Name.ToString())
				{
					case "ISBN":
						key = readXML.ReadString();
						break;
					case "Title":
						value = readXML.ReadString();
						break;
				}
			}
			//newDictionary.Add(key, value);

			return newDictionary;
		}

		// using XmlDocument ??? 
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
			foreach (var book in newDictionary)
			{
			    if (book.Value.ItemType == "NewReleaseBook")
			        Console.WriteLine($"New Release Books: {book.Key} - {book.Value.Title}");

			    if (book.Value.ItemType == "Magazine")
			        Console.WriteLine($"Magazines: {book.Key} - {book.Value.Title}");

			    if (book.Value.ItemType == "Book")
			        Console.WriteLine($"Books: {book.Key} - {book.Value.Title}");
			    Console.Write(Environment.NewLine);
			}

			return newDictionary;
		}

		// using XElement ???
		public static Dictionary<string, string> GetBooksUsingXElement()
		{
			var libraryItems = XElement.Load(@"C:\WorkSpace\LibraryCatalogue.xml").Elements("Items").ToString();
			var newDictionary = new Dictionary<string, string>();

			string key, value;

			foreach (var element in libraryItems)
			{
				var elements = XElement.Parse(libraryItems);

				key = elements.Attribute("ISBN").Value;
				value = elements.Attribute("Title").Value;
				newDictionary.Add(key, value);
			}

			foreach (var book in newDictionary)
			{
				Console.WriteLine($"{book.Key}: {book.Value}");
			}


			return newDictionary;
		}

		// using XDocument ???
		public static Dictionary<string, string> GetBooksXDocument()
		{
			XmlDocument doc = new XmlDocument();
			doc.LoadXml(@"C:\WorkSpace\LibraryCatalogue.xml");

			var d = new Dictionary<string, string>();

			foreach (XmlNode n in doc)
			{
				d.Add(n.Attributes.GetNamedItem("ISBN").Value, n.Attributes.GetNamedItem("Title").Value);
			}

			foreach (var item in d)
			{
				Console.WriteLine($"{item.Key}: {item.Value}");
			}

			return d;
		}


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


		public TimeSpan SetCheckoutPeriodByItemType(ILibraryItem book)
        {
            if (book.ItemType == "Magazine")
                LengthOfCheckoutPeriod = TimeSpan.FromDays(7);
            else if (book.ItemType == "NewReleaseBook")
                LengthOfCheckoutPeriod = TimeSpan.FromDays(5);
            else if (book.ItemType == "Book")
                LengthOfCheckoutPeriod = TimeSpan.FromDays(14);
            else
                Console.WriteLine("Unrecognized Type");

			 return LengthOfCheckoutPeriod;
        }
		

		public void ReadFromXML()
        {
            var readXML = XmlReader.Create(@"C:\WorkSpace\LibraryCatalogue.xml");
            var newDictionary = new Dictionary<string, ILibraryItem>();

            while (readXML.Read())
            {
				switch (readXML.Name.ToString())
                {
                    case "Book":
                        var book = CreateBook(item.ChildNodes[2].InnerText, TimeSpan.Parse(item.ChildNodes[3].InnerText));
                        newDictionary.Add(isbnKey, book);
                        break;
                    case "Magazine":
                        CreateMagazine(int isbn, string bookTitle, TimeSpan lengthOfCheckoutPeriod);
                        break;
                    case "NewRelease":
                        CreateNewRelease(int isbn, string bookTitle, TimeSpan lengthOfCheckoutPeriod);
                        break;
                }
            }
        }		



		#endregion
	}
}
