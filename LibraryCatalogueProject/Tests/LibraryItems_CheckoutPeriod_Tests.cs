using LibraryCatalog.Code.CustomExceptions;
using LibraryCatalog.Code.LibraryItems;
using LibraryCatalogueProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace LibraryCatalog.Tests
{
    [TestClass]
    public class LibraryItems_CheckoutPeriod_Tests
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
        public void LengthOfCheckoutPeriod_CheckoutAMagazine_Expected_CheckoutPeriodIsSetTo7days_Test()
        {
            // Arrange
            var checkoutBook = new Library(TestLibrary());
            var magazine = "50000004"; // Magazine --> "Girl's World"
            var customer = "Tom";

            // Act
            var expectedDays = 7;

            var checkedOutItem = checkoutBook.CheckOutAnItem(magazine, customer);
            var actualDays = checkoutBook.DaysTillDue(checkedOutItem);

            // Assert
            Assert.AreEqual(expectedDays, actualDays);

            //OR this way:
            // ACT:
            //var checkedOutItem = checkoutBook.CheckOutAnItem(magazine, customer);
            //var actualDays = checkedOutItem.LengthOfCheckoutPeriod.TotalDays;
            // ASSERT:
            //Assert.AreEqual(expectedDays, actualDays);
        }

        [TestMethod]
        public void LengthOfCheckoutPeriod_CheckoutABook_Expected_CheckoutPeriodIsSetTo14days_Test()
        {
            // Arrange
            var checkoutBook = new Library(TestLibrary());
            var magazine = "48039480"; // Book "Harry Potter and the Sorcerer's Stone"
            var customer = "Tom";

            // Act
            var expectedPeriod = 14;

            var checkedOutItem = checkoutBook.CheckOutAnItem(magazine, customer);
            var actualPeriod = checkoutBook.DaysTillDue(checkedOutItem);

            // Assert
            Assert.AreEqual(expectedPeriod, actualPeriod);
        }

        [TestMethod]
        public void LengthOfCheckoutPeriod_CheckoutANewReleaseBook_Expected_CheckoutPeriodIsSetTo5days_Test()
        {
            // Arrange
            var checkoutBook = new Library(TestLibrary());
            var magazine = "50000006"; // NewRelease("Animal Tales")
            var customer = "Tom";

            // Act
            var expectedPeriod = 5;

            var checkedOutItem = checkoutBook.CheckOutAnItem(magazine, customer);
            var actualPeriod = checkoutBook.DaysTillDue(checkedOutItem);

            // Assert
            Assert.AreEqual(expectedPeriod, actualPeriod);
        }


        [TestMethod]
        public void LengthOfCheckoutPeriod_CheckoutADVD_Expected_CheckoutPeriodIsSetTo3days_Test()
        {
            // Arrange
            var checkoutBook = new Library(TestLibrary());
            var magazine = "48039481"; // MovieDVD("Christmas Movie")
            var customer = "Tom";

            // Act
            var expectedPeriod = 3;

            var checkedOutItem = checkoutBook.CheckOutAnItem(magazine, customer);
            var actualPeriod = checkoutBook.DaysTillDue(checkedOutItem);

            // Assert
            Assert.AreEqual(expectedPeriod, actualPeriod);
        }
    }
}
