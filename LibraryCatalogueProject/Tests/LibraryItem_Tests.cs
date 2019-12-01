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

        [TestMethod]
        public void _ReturningAnItem_IsCheckedOut_GetsSetToFALSE_Test()
        {
            // Arrange
            var checkoutBook = TestLibrary();
            var library = new Library(checkoutBook);
            var customer = "Tom";
            var title = "48039481"; // <-- DVD, 3 days

            library.CheckOutAnItem(title, customer);

            var expectedIsCheckedOut = false;

            // Act
            library.ReturnAnItem(title);
            var actual = checkoutBook[title].IsCheckedOut;

            // Assert
            Assert.AreEqual(expectedIsCheckedOut, actual);
        }

        [TestMethod]
        public void _ReturningAnItem_DayCheckedOut_GetsSetToNULL_Test()
        {
            // Arrange
            var checkoutBook = TestLibrary();
            var library = new Library(checkoutBook);
            var customer = "Tom";
            var title = "48039481"; // <-- DVD, 3 days

            library.CheckOutAnItem(title, customer);

            // Act
            library.ReturnAnItem(title);
            var actual = checkoutBook[title].DayCheckedOut;

            // Assert
            Assert.AreEqual(null, actual);
        }

        [TestMethod]
        public void _ReturningAnItem_CustomerCheckedOutTo_GetsSetToNULL_Test()
        {
            // Arrange
            var checkoutBook = TestLibrary();
            var library = new Library(checkoutBook);
            var customer = "Tom";
            var title = "48039481"; // <-- DVD, 3 days

            library.CheckOutAnItem(title, customer);

            // Act
            library.ReturnAnItem(title);
            var actual = checkoutBook[title].WhoWasItCheckeoutTo;

            // Assert
            Assert.AreEqual(null, actual);
        }
    }
}
