using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibraryCatalogueProject;
using System.Collections.Generic;
using System.Linq;

namespace LibraryCatalogueProject.Tests
{
	[TestClass]
	public class Tests
	{
		[TestMethod]
		public void LibraryPopulatesFromXmlFile()
		{
            //Arrange
            #region FAKE LIBRARY
            var dictionary = new Dictionary<string, Book>()
            {
                { "48039480", new Book("Harry Potter and the Sorcerer's Stone", "Book") },
				{ "48039481", new Book("Harry Potter and the Chamber of Secrets", "Book")},
				{ "50000004", new Book("Encyclopedia of Life", "Magazine")},
				{ "50000006", new Book("Animal Tales", "Magazine")},
				{ "70000015", new Book("The Dutch House", "NewReleaseBook")},
				{ "70000013", new Book("Someone We Know", "NewReleaseBook")},
				{ "70000014", new Book("The Water Dancer", "NewReleaseBook")}
            };
            #endregion

            var count = dictionary.Count(); // returns 7 items
            var libraryCatalogue = new LibraryCatalogue(dictionary);

            var expected = libraryCatalogue.BookCollection.Count(); // 7 items expected

            //Assert
            Assert.AreEqual(count, expected);
        }

        [TestMethod]
		public void Test2()
		{
			//Arrange


			//Act


			//Assert
		}

		[TestMethod]
		public void Test3()
		{
			//Arrange


			//Act


			//Assert
		}
	}
}
