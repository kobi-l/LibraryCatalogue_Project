using FluentAssertions;
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
        #region TEST LIBRARY
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

        const string Customer = "Tom";
        public Library CreateALibraryAndCheckoutItems()
        {
            // Arrange
            var library = new Library(TestLibrary());
            var currentDate = DateTime.Today;

            const string isbnBook = "48039480";
            const string isbnDVD = "48039481";
            const string isbnMagazine = "50000004";
            const string isbnNewRelease = "50000006";

            // chechout items:
            library.CheckOutAnItem(isbnBook, Customer, currentDate);
            library.CheckOutAnItem(isbnDVD, Customer, currentDate);
            library.CheckOutAnItem(isbnMagazine, Customer, currentDate);
            library.CheckOutAnItem(isbnNewRelease, Customer, currentDate);

            return library;
        }

        [TestMethod]
        public void OverdueItems_Adding6Days_ResultsInTwoOverdueItems()
        {
            // Arrange
            var library = CreateALibraryAndCheckoutItems();
            var currentDate = DateTime.Today;

            // Act
            currentDate = currentDate.AddDays(6);
            var overdueItems = library.OverdueItemsByCustomerName(Customer, currentDate); 

            // Assert
            // Asserting the overdue items list - Expected to be '2'.
            //Assert.AreEqual(2, overdueItems.Count);
            overdueItems.Count.Should().Be(2);
        }

        [TestMethod]
        public void OverdueItems_Adding6Days_CustomerItemsListIncludesAllItems()
        {
            // Arrange
            var library = CreateALibraryAndCheckoutItems();

            // Act
            var customerItems = library.CustomerItems(Customer); 

            // Assert
            // Asserting the CustomerItems list - Expected to be '4'.
            //Assert.AreEqual(4, customerItems.Count);

            customerItems.Count.Should().Be(4);
        }

        [TestMethod]
        public void OverdueItems_Adding6DaysAndReturnigOverdueItems_ExpectedZeroOverdueItems()
        {
            // Arrange
            var library = CreateALibraryAndCheckoutItems();
            var currentDate = DateTime.Today;

            // Act
            currentDate = currentDate.AddDays(6);
            var overdueItems = library.OverdueItemsByCustomerName(Customer, currentDate);

            foreach (var item in overdueItems)
                library.ReturnAnItem(item.Item.ISBN, currentDate);

            // Assert
            // Asserting the OverdueItems list - Expected to be '0'.
            //Assert.AreEqual(0, library.OverdueItemsByCustomerName(Customer, currentDate).Count);

            library.OverdueItemsByCustomerName(Customer, currentDate).Count.Should().Be(0);
        }

        [TestMethod]
        public void OverdueItems_Adding6DaysAndReturnigOverdueItems_ExpectedTwoInCustomerList()
        {
            // Arrange
            var library = CreateALibraryAndCheckoutItems();
            var currentDate = DateTime.Today;

            // Act
            currentDate = currentDate.AddDays(6);
            var overdueItems = library.OverdueItemsByCustomerName(Customer, currentDate);

            foreach (var item in overdueItems)
                library.ReturnAnItem(item.Item.ISBN, currentDate);

            // Assert
            // Asserting the CustomerItems list - Expected to be '2'.
            //Assert.AreEqual(2, library.CustomerItems(Customer).Count);

            library.CustomerItems(Customer).Count.Should().Be(2);
        }

        [TestMethod]
        public void OverdueItems_AddingDaysSameAsCheckoutPeriod_ExpectedTwoInCustomerList()
        {
            // Arrange
            var library = new Library(TestLibrary());
            var currentDate = DateTime.Today;

            // Checkout an items:
            library.CheckOutAnItem("211505DV", Customer, currentDate); // DVD

            // Act
            currentDate = currentDate.AddDays(2);
            var overdueItems = library.OverdueItemsByCustomerName(Customer, currentDate);

            // Assert
            // Asserting the OverdueItems list - Expected to be '0'.
            //Assert.AreEqual(0, overdueItems.Count);

            overdueItems.Count.Should().Be(0);
        }

        [TestMethod]
        public void OverdueItems_Adding6DaysAndCheckingOutMoreItems_ExpectedTwoInCustomerList()
        {
            // Arrange
            var library = CreateALibraryAndCheckoutItems();
            var currentDate = DateTime.Today;

            // Act
            currentDate = currentDate.AddDays(6);

            // Asserting the OverdueItems list - Expected to be '2'.
            var overdueItems = library.OverdueItemsByCustomerName(Customer, currentDate);
            Assert.AreEqual(2, overdueItems.Count);

            // Asserting CustomerItems list - Expected, 4.
            var customerItems = library.CustomerItems(Customer).Count;
            Assert.AreEqual(4, customerItems);

            // Checkout two more items:
            library.CheckOutAnItem("70000013", Customer, currentDate); // New Release
            library.CheckOutAnItem("211505DV", Customer, currentDate); // DVD

            // Asserting CustomerItems list - Expected, 6.
            customerItems = library.CustomerItems(Customer).Count;
            Assert.AreEqual(6, customerItems);

            // Add four more days:
            currentDate = currentDate.AddDays(8);

            // Asserting the OverdueItems list - Expected to be '6'.
            overdueItems = library.OverdueItemsByCustomerName(Customer, currentDate);
            Assert.AreEqual(6, overdueItems.Count);

            // Returning items
            foreach (var item in overdueItems)
                library.ReturnAnItem(item.Item.ISBN, currentDate);

            // Asserting the CustomerItems list - Expected to be '0'.
            Assert.AreEqual(0, library.CustomerItems(Customer).Count);

            // Asserting the OverdueItems list - Expected to be '0'.
            Assert.AreEqual(0, library.OverdueItemsByCustomerName(Customer, currentDate).Count);
        }
    }
}
