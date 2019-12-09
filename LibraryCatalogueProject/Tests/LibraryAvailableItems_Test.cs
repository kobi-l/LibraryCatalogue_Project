using LibraryCatalog.Code.LibraryItems;
using LibraryCatalogueProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using FluentAssertions;

namespace LibraryCatalog.Tests
{
    [TestClass]
    public class LibraryAvailableItems_Test
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

        const string Customer = "Customer";

        [TestMethod]
        public void AllLibraryItems_ExpectedToReturn_AllItemsInTheLibrary()
        {
            // Arrange
            var library = new Library(TestLibrary());

            // Act
            var itemsCount = library.AllLibraryItems().Count;

            // Assert
            //Assert.AreEqual(8, itemsCount);
            itemsCount.Should().Be(8); //<-- using the FluentAssertion
        }

        [TestMethod]
        public void AllLibraryItems_CheckingOutItemsWontAffectCount()
        {
            // Arrange
            var library = new Library(TestLibrary());
            var currentDate = DateTime.Today;
            var isbnBook = "48039479";

            // Act
            library.CheckOutAnItem(isbnBook, Customer, currentDate);
            var itemsCount = library.AllLibraryItems().Count;

            // Assert
            //Assert.AreEqual(8, itemsCount);
            itemsCount.Should().Be(8);
        }

        [TestMethod]
        public void AllLibraryItems_ListOfItemsIndicatesWhetherItemIsCheckedOut()
        {
            // Arrange
            var library = new Library(TestLibrary());
            var currentDate = DateTime.Today;
            var isbnBook = "48039479";

            // Act
            library.CheckOutAnItem(isbnBook, Customer, currentDate);
            var libraryItems = library.AllLibraryItems();

            var checkedOutItems = new List<ILibraryItem>();

            foreach (var item in libraryItems)
            {
                if (item.IsCheckedOut == true)
                {
                    checkedOutItems.Add(item);
                }
            }
            // Assert
            //Assert.AreEqual(1, checkedOutItems.Count);

            checkedOutItems.Count.Should().Be(1);
        }

        [TestMethod]
        public void AllLibraryItems_ListOfItemsIndicatesWhoWasItemIsCheckedOutTo()
        {
            // Arrange
            var library = new Library(TestLibrary());
            var currentDate = DateTime.Today;
            var isbnBook = "48039479";

            // Act
            library.CheckOutAnItem(isbnBook, Customer, currentDate);
            var libraryItems = library.AllLibraryItems();

            var checkedOutItems = new List<ILibraryItem>();

            foreach (var item in libraryItems)
            {
                if (item.IsCheckedOut == true)
                {
                    checkedOutItems.Add(item);
                }
            }
            // Assert
            //Assert.AreEqual(Customer, checkedOutItems[0].WhoWasItCheckeoutTo);

            checkedOutItems[0].WhoWasItCheckeoutTo.Should().Be(Customer);
        }

        [TestMethod]
        public void AllAvailableLibraryItems_ItemsListExcludesCheckedOutItems()
        {
            // Arrange
            var library = new Library(TestLibrary());
            var currentDate = DateTime.Today;
            var isbnBook = "48039479";

            // Act
            library.CheckOutAnItem(isbnBook, Customer, currentDate);
            var libraryItems = library.AllAvailableLibraryItems();

            // Assert
            //Assert.AreEqual(7, libraryItems.Count);
            libraryItems.Count.Should().Be(7);
        }
    }
}
