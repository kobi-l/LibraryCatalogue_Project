using FluentAssertions;
using LibraryCatalog.Code.Adapter;
using LibraryCatalog.Code.Enums;
using LibraryCatalog.Code.LibraryItems;
using LibraryCatalogueProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCatalog.Tests
{
    [TestClass]
    public class LibraryItems_ItemsByType_Tests
    {
        #region TEST LIBRARY
        public Dictionary<string, ILibraryItem> TestLibrary()
        {
            return new Dictionary<string, ILibraryItem>()
            {
                { "211505DV", new MovieDVD("211505DV", "Long Shot")},
                { "211503DV", new MovieDVD("211503DV", "The art of self-defense")},
                { "48039481", new MovieDVD("48039481", "Christmas Movie")},

                { "70000013", new NewRelease("70000013", "Someone We Know")},
                { "50000006", new NewRelease("50000006", "Animal Tales")},
                { "70000012", new NewRelease("70000012", "The Turn Of the Key")},
                { "70000014", new NewRelease("70000014", "The Water Dancer")},

                { "48039480", new Book("48039480", "Harry Potter and the Sorcerer's Stone")},
                { "48039479", new Book("48039479", "Atomic Habits")},

                { "50000004", new Magazine("50000004", "Encyclopedia of Life")}
            };
        }

        #endregion

        const string Customer = "Customer";

        [TestMethod]
        public void LibraryItemsByType_GetBooks_AllBooksReturned()
        {
            // Arrange
            var library = new Library(TestLibrary());
            var date = DateTime.Today;

            // Act
            var allBooks = library.LibraryItemsByType("Book", date);

            // Assert
            Assert.AreEqual(2, allBooks.Count);
        }

        [TestMethod]
        public void LibraryItemStatus_ItemAvailable_ExpectedStatus_Available()
        {
            // Arrange
            var library = new Library(TestLibrary());
            var date = DateTime.Today;
            var itemType = "Magazine";

            // Act
            var listOfItems = library.LibraryItemsByType(itemType, date);
            var expectedStatus = LibraryItemStatus.Available;

            // Assert
            //Assert.AreEqual(expectedStatus, listOfItems[0].ItemStatus);

            listOfItems[0].ItemStatus.Should().Be(expectedStatus);
        }

        [TestMethod]
        public void LibraryItemStatus_ItemCheckedOut_ExpectedStatus_CheckedOut()
        {
            // Arrange
            var library = new Library(TestLibrary());
            var date = DateTime.Today;
            var itemType = "Magazine";
            var itemIsbn = "50000004";

            // Act
            library.CheckOutAnItem(itemIsbn, Customer, date);
            date = date.AddDays(6);

            var listOfItems = library.LibraryItemsByType(itemType, date);
            var expectedStatus = LibraryItemStatus.CheckedOut;

            // Assert
            //Assert.AreEqual(expectedStatus, listOfItems[0].ItemStatus);

            listOfItems[0].ItemStatus.Should().Be(expectedStatus);
        }

        [TestMethod]
        public void LibraryItemStatus_ItemDue_ExpectedStatus_Due()
        {
            // Arrange
            var library = new Library(TestLibrary());
            var date = DateTime.Today;
            var itemType = "Magazine";
            var itemIsbn = "50000004";

            // Act
            library.CheckOutAnItem(itemIsbn, Customer, date);
            date = date.AddDays(7);

            var listOfItems = library.LibraryItemsByType(itemType, date);
            var expectedStatus = LibraryItemStatus.Due;

            // Assert
            // Assert.AreEqual(expectedStatus, listOfItems[0].ItemStatus);

            listOfItems[0].ItemStatus.Should().Be(expectedStatus);
        }

        [TestMethod]
        public void LibraryItemStatus_ItemOverdue_ExpectedStatus_Overdue()
        {
            // Arrange
            var library = new Library(TestLibrary());
            var date = DateTime.Today;
            var itemType = "Magazine";
            var itemIsbn = "50000004";

            // Act
            library.CheckOutAnItem(itemIsbn, Customer, date);
            date = date.AddDays(8);

            var listOfItems = library.LibraryItemsByType(itemType, date);
            var expectedStatus = LibraryItemStatus.Overdue;

            // Assert
            //Assert.AreEqual(expectedStatus, listOfItems[0].ItemStatus);

            listOfItems[0].ItemStatus.Should().Be(expectedStatus);
        }
    }
}
