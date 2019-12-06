using FluentAssertions;
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
                { "48039480", new Book("48039480", "Harry Potter and the Sorcerer's Stone")},
                { "48039481", new MovieDVD("48039481", "Christmas Movie")},
                { "50000004", new Magazine("50000004", "Encyclopedia of Life")},
                { "50000006", new NewRelease("50000006", "Animal Tales")},
            };
        }

        #endregion

        [TestMethod]
        public void LengthOfCheckoutPeriod_CheckoutAMagazine_Expected_CheckoutPeriodIsSetTo7days_Test()
        {
            // Arrange
            var checkoutBook = new Library(TestLibrary());
            var date = DateTime.Today;

            var magazine = "50000004"; // Magazine --> "Girl's World"
            var customer = "Tom";

            // Act
            var expectedDays = 7;

            var checkedOutItem = checkoutBook.CheckOutAnItem(magazine, customer, date);
            var actualDays = checkoutBook.DaysTillDue(checkedOutItem, date);

            // Assert
            Assert.AreEqual(expectedDays, actualDays);

            actualDays.Should().Be(actualDays);
        }

        [TestMethod]
        public void LengthOfCheckoutPeriod_CheckoutABook_Expected_CheckoutPeriodIsSetTo14days_Test()
        {
            // Arrange
            var checkoutBook = new Library(TestLibrary());
            var date = DateTime.Today;

            var magazine = "48039480"; // Book "Harry Potter and the Sorcerer's Stone"
            var customer = "Tom";

            // Act
            var expectedPeriod = 14;

            var checkedOutItem = checkoutBook.CheckOutAnItem(magazine, customer, date);
            var actualPeriod = checkoutBook.DaysTillDue(checkedOutItem, date);

            // Assert
            //Assert.AreEqual(expectedPeriod, actualPeriod);

            actualPeriod.Should().Be(expectedPeriod);
        }

        [TestMethod]
        public void LengthOfCheckoutPeriod_CheckoutANewReleaseBook_Expected_CheckoutPeriodIsSetTo5days_Test()
        {
            // Arrange
            var checkoutBook = new Library(TestLibrary());
            var date = DateTime.Today;

            var magazine = "50000006"; // NewRelease("Animal Tales")
            var customer = "Tom";

            // Act
            var expectedPeriod = 5;

            var checkedOutItem = checkoutBook.CheckOutAnItem(magazine, customer, date);
            var actualPeriod = checkoutBook.DaysTillDue(checkedOutItem, date);

            // Assert
            //Assert.AreEqual(expectedPeriod, actualPeriod);

            actualPeriod.Should().Be(expectedPeriod);
        }


        [TestMethod]
        public void LengthOfCheckoutPeriod_CheckoutADVD_Expected_CheckoutPeriodIsSetTo3days_Test()
        {
            // Arrange
            var checkoutBook = new Library(TestLibrary());
            var date = DateTime.Today;

            var magazine = "48039481"; // MovieDVD("Christmas Movie")
            var customer = "Tom";

            // Act
            var expectedPeriod = 3;

            var checkedOutItem = checkoutBook.CheckOutAnItem(magazine, customer, date);
            var actualPeriod = checkoutBook.DaysTillDue(checkedOutItem, date);

            // Assert
            //Assert.AreEqual(expectedPeriod, actualPeriod);

            actualPeriod.Should().Be(expectedPeriod);
        }

        [TestMethod]
        public void LengthOfCheckoutPeriod_CalculatesCorrectly_AfterAddingDays_Expected2Days_Test()
        {
            // Arrange
            var checkoutBook = new Library(TestLibrary());
            var date = DateTime.Today;

            var magazine = "48039481"; // MovieDVD("Christmas Movie")
            var customer = "Tom";

            // Act
            var checkedOutItem = checkoutBook.CheckOutAnItem(magazine, customer, date);
            
            var actualPeriod = checkoutBook.DaysTillDue(checkedOutItem, date.AddDays(1));
            var expectedPeriod = 2;

            // Assert
            //Assert.AreEqual(expectedPeriod, actualPeriod);

            actualPeriod.Should().Be(expectedPeriod);
        }

        [TestMethod]
        public void LengthOfCheckoutPeriod_DisplayedNegative_WhenExceedingAllowedPeriod_ExpectedNegative2Days_Test()
        {
            // Arrange
            var checkoutBook = new Library(TestLibrary());
            var date = DateTime.Today;

            var magazine = "48039481"; // MovieDVD("Christmas Movie")
            var customer = "Tom";

            // Act
            var checkedOutItem = checkoutBook.CheckOutAnItem(magazine, customer, date);

            var actualPeriod = checkoutBook.DaysTillDue(checkedOutItem, date.AddDays(5));
            var expectedPeriod = -2;

            // Assert
            // Assert.AreEqual(expectedPeriod, actualPeriod);

            actualPeriod.Should().Be(expectedPeriod);
        }
    }
}
