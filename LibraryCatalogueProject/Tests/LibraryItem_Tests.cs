using LanguageExt.ClassInstances.Pred;
using LibraryCatalog.Code.LibraryItems;
using LibraryCatalogueProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace LibraryCatalog.Tests
{   
    [TestClass]
    public class LibraryItem_Tests
    {
        #region TEST LIBRARY

        public Dictionary<string, ILibraryItem> TestLibrary()
        {
            return new Dictionary<string, ILibraryItem>()
            {
                { "48039480", new Book("Harry Potter and the Sorcerer's Stone")},
                { "48039481", new MovieDVD("Christmas Movie")},
                { "50000004", new Magazine("Encyclopedia of Life")},
                { "50000006", new NewRelease("Animal Tales")},
            };
        }

        #endregion

        [TestMethod]
        public void SetIsCheckedOut_Expected_IsSetToTrueWhenItemIsCheckedOut_Test()
        {
            // Arrange
            var checkoutBook = new Library(TestLibrary());
            var title = "48039480";
            var customer = "Tom";

            // Act
            var actual = checkoutBook.CheckOutAnItem(title, customer);

            // Assert
            Assert.AreEqual(true, actual.IsCheckedOut);
        }

        [TestMethod]
        public void SetIsCheckedOut_Expected_WhoWasItCheckedOutTo_IsSetToCustomerWhenItemIsCheckedOut_Test()
        {
            // Arrange
            var checkoutBook = new Library(TestLibrary());
            var title = "48039480";
            var customer = "Tom";

            // Act
            var actual = checkoutBook.CheckOutAnItem(title, customer);

            // Assert
            Assert.AreEqual(customer, actual.WhoWasItCheckeoutTo);
        }

        [TestMethod]
        public void SetIsCheckedOut_Expected_CurrentDay_IsSetToADayItWasCheckedOutWhenItemIsCheckedOut_Test()
        {
            // Arrange
            var checkoutBook = new Library(TestLibrary());
            var title = "48039480";
            var customer = "Tom";

            // Act
            var actual = checkoutBook.CheckOutAnItem(title, customer);

            // Assert
            Assert.AreEqual(DateTime.Today.Day, actual.DayCheckedOut.Value.Day);
        }
    }
}
