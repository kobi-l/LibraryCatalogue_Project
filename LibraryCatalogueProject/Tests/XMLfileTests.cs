using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibraryCatalogueProject;
using System.Collections.Generic;
using System.Linq;

namespace LibraryCatalogueProject.Tests
{
	[TestClass]
	public class Tests
	{
		#region FAKE LIBRARY
		public Dictionary<string, ILibraryItem> FakeLibrary()
		{
			return new Dictionary<string, ILibraryItem>();
			//{
			//	{ "48039480", new LibraryItem("Harry Potter and the Sorcerer's Stone", "Book", 3) },
			//	{ "48039481", new LibraryItem("Harry Potter and the Chamber of Secrets", "Book", 2)},
			//	{ "50000004", new LibraryItem("Encyclopedia of Life", "Magazine", 4)},
			//	{ "50000006", new LibraryItem("Animal Tales", "Magazine", 5)},
			//	{ "70000015", new LibraryItem("The Dutch House", "NewReleaseBook", 1)},
			//	{ "70000013", new LibraryItem("Someone We Know", "NewReleaseBook", 3)},
			//	{ "70000014", new LibraryItem("The Water Dancer", "NewReleaseBook", 2)}
			//};
		}
		#endregion

		[TestMethod]

		public void LibraryGetsPopulatedFromXmlFile()
		{
			// Arrange
			var count = FakeLibrary().Count; // returns 7 items

			// Act
			var libraryCatalogue = new Library(FakeLibrary());
			var expected = libraryCatalogue.LibraryCatalogue.Count(); // 7 items expected

			// Assert
			Assert.AreEqual(count, expected);
		}

		[TestMethod]
		public void LibraryItemsCanBeRetrievedByKey()
		{
			// Arrange
			var libraryCatalogue = new Library(FakeLibrary());

			// Act
			var valueByKey = libraryCatalogue.LibraryCatalogue["48039480"].Title;
			var expected = "Harry Potter and the Sorcerer's Stone";

			// Assert
			Assert.AreEqual(valueByKey, expected);
		}

		[TestMethod]
		public void LibraryItemsHave_ItemType_Book()
		{
			//Arrange
			var libraryCatalogue = new Library(FakeLibrary());

			//Act
			var bookType = libraryCatalogue.LibraryCatalogue["48039480"].ItemType;
			var expectedBook = "Book";

			//Assert
			Assert.AreEqual(expectedBook, bookType);
		}

		[TestMethod]
		public void LibraryItemsHave_ItemType_Magazine()
		{
			//Arrange
			var libraryCatalogue = new Library(FakeLibrary());

			//Act
			var bookType = libraryCatalogue.LibraryCatalogue["50000004"].ItemType;
			var expectedBook = "Magazine";

			//Assert
			Assert.AreEqual(expectedBook, bookType);
		}

		[TestMethod]
		public void LibraryItemsHave_ItemType_NewReleaseBook()
		{
			//Arrange
			var libraryCatalogue = new Library(FakeLibrary());

			//Act
			var bookType = libraryCatalogue.LibraryCatalogue["70000015"].ItemType;
			var expectedBook = "NewReleaseBook";

			//Assert
			Assert.AreEqual(expectedBook, bookType);
		}
	}
}
