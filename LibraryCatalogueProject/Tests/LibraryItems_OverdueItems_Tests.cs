using LibraryCatalog.Code.LibraryItems;
using LibraryCatalogueProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace LibraryCatalog.Tests
{
    [TestClass]
    public class LibraryItems_OverdueItems_Tests
    {
        #region FAKE LIBRARY
        public Dictionary<string, ILibraryItem> TestLibrary()
        {
            return new Dictionary<string, ILibraryItem>()
            {
                { "48039480", new Book("48039480", "Harry Potter and the Sorcerer's Stone")},
                { "48039481", new MovieDVD("48039481", "Christmas Movie")},
                { "50000004", new Magazine("50000004", "Encyclopedia of Life")},
                { "50000006", new NewRelease("50000006", "Animal Tales")},

                { "48039479", new Book("48039479", "Atomic Habits")},
                { "211505DV", new MovieDVD("211505DV", "Long Shot")},
                { "50000002", new Magazine("50000002", "National Geographics Kids")},
                { "70000013", new NewRelease("70000013", "Someone We Know")},
            };
        }
        #endregion

        // CheckOutAnItem Method Tests: 
        [TestMethod]
        public void CheckOutAnItem_CheckingOutItemThatDoesntExist_Expected_NULL_Test()
        {
            // Arrange
            var itemsCatalogue = new Library(TestLibrary());
            var date = DateTime.Today;
            var customer = "Tom";

            var isbnBook = "48039480";
            var isbnDVD = "48039481";
            var isbnMagazine = "50000004";
            var isbnNewRelease = "50000006";

            // chechout items:
            itemsCatalogue.CheckOutAnItem(isbnBook, customer, date);
            itemsCatalogue.CheckOutAnItem(isbnDVD, customer, date);
            itemsCatalogue.CheckOutAnItem(isbnMagazine, customer, date);
            itemsCatalogue.CheckOutAnItem(isbnNewRelease, customer, date);

            // get itmes by Customer name
            itemsCatalogue.CustomerItems(customer); // <-- should have FOUR items

            // Act
            // get overdue items:
            var overdueItems1 = itemsCatalogue.OverdueItemsByCustomerName(customer, date.AddDays(6)); // <-- should have TWO items
            itemsCatalogue.CustomerItems(customer); // <-- should have FOUR items

            foreach (var item in overdueItems1)
            {
                itemsCatalogue.ReturnAnItem(item.Item.ISBN, date);
            }

            // Assert overdue items list after returnig overdue items - Expected to be '0'.
            Assert.AreEqual(0, itemsCatalogue.OverdueItemsByCustomerName(customer, date.AddDays(6)).Count);

            // Assert customer items list after returnig overdue items - expected to be '2'.
            Assert.AreEqual(2, itemsCatalogue.CustomerItems(customer).Count);

        }
    }
}
