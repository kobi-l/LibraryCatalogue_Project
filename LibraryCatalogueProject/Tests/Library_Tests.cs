using LibraryCatalog.Code.CustomExceptions;
using LibraryCatalog.Code.LibraryItems;
using LibraryCatalogueProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryCatalog.Tests
{
    [TestClass]
    public class Library_Tests
    {
        #region FAKE LIBRARY
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


        // CheckOutAnItem Method Tests: 
        [TestMethod]
        public void CheckOutAnItem_CheckingOutItemThatDoesntExist_Expected_NULL_Test()
        {
            // Arrange
            var checkoutBook = new Library(TestLibrary());
            var title = "48039480123";
            var customer = "Tom";

            // Act
            var actual = checkoutBook.CheckOutAnItem(title, customer);

            // Assert
            Assert.AreEqual(null, actual);
        }

        [TestMethod]
        public void CheckOutAnItem_Expected_SuccessfulCheckout_Test()
        {
            // Arrange
            var checkoutBook = new Library(TestLibrary());
            var title = "48039480";
            var customer = "Tom";

            // Act
            var actual = checkoutBook.CheckOutAnItem(title, customer);

            // Assert
            Assert.AreNotEqual(null, actual);
        }


        // CheckItemAvailability Method Tests:

        [TestMethod]
        public void CheckItemAvailability_InvalidItem_MessageExpected_SorryWeDontHaveIt_Test()
        {
            // Arrange
            var checkoutBook = new Library(TestLibrary());
            var title = "48039480454";

            // Act
            checkoutBook.CheckItemAvailability(title, out string message);
            var expectedMessage = $"Sorry, we don't have '{title}' book.\n";

            // Assert
            Assert.AreEqual(expectedMessage, message);
        }

        [TestMethod]
        public void CheckItemAvailabilityMethod_ValidItem_Expected_ReturnsTrue_Test()
        {
            // Arrange
            var checkoutBook = new Library(TestLibrary());
            var title = "48039481"; 

            // Act
            var expected = true;
            var actual = checkoutBook.CheckItemAvailability(title, out string message);
            
            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CheckItemAvailabilityMethod_ValidCheckedOutItem_Expected_CustomExceptionMessage_Test()
        {
            // Arrange
            var checkoutBook = new Library(TestLibrary());
            var title = "48039481"; //<-- DVD, checkout period 3 days
            var customer = "Tom";

            // Act
            checkoutBook.CheckOutAnItem(title, customer);
            var expectedMessage = $"Sorry, 'Christmas Movie' had been taken out! It should be back in 3 days.\n";

            // Act
            Action act = () => checkoutBook.CheckItemAvailability(title, out string message);

            // Assert
            var exception = Assert.ThrowsException<LibraryItemAlreadyCheckedOutException>(act); 

            Assert.AreEqual(expectedMessage, exception.Message);
        }



        // CustomerItems method Tests
        [TestMethod]
        public void CustomerItemsMethod_ListCanBeEmpty_Expected_EmptyList_Test()
        {
            // Arrange
            var checkoutBook = new Library(TestLibrary());
            var customer = "Tom";

            // Act
            var actual = checkoutBook.CustomerItems(customer);

            // Assert
            Assert.AreEqual(0, actual.Length());
        }

        [TestMethod]
        public void CustomerItemsMethod_ListPopulatesWithItems_Expected_ListIsntEmpty_Test()
        {
            // Arrange
            var checkoutBook = new Library(TestLibrary());
            var customer = "Tom";
            var title = "48039481";
            var title1 = "50000004";
            var title2 = "50000006";

            // Act
            checkoutBook.CheckOutAnItem(title, customer);
            checkoutBook.CheckOutAnItem(title1, customer);
            checkoutBook.CheckOutAnItem(title2, customer);



            var actual = checkoutBook.CustomerItems(customer);

            var expected = 3;

            // Assert
            Assert.AreEqual(expected, actual.Count);
        }

        [TestMethod]
        public void CustomerItemsMethod_ListPupulatesWithItems_Expected_ListIsntEmpty_Test()
        {
            // Arrange
            var checkoutBook = new Library(TestLibrary());
            var customer1 = "Tom";
            var customer2 = "Sam";

            var title = "48039481";
            var title1 = "50000004";
            var title2 = "50000006";

            // Act
            checkoutBook.CheckOutAnItem(title2, customer1);
            checkoutBook.CheckOutAnItem(title, customer1);

            checkoutBook.CheckOutAnItem(title1, customer2);


            var actualCustomer1 = checkoutBook.CustomerItems(customer1);
            var actualCustomer2 = checkoutBook.CustomerItems(customer2);

            // Assert
            Assert.AreNotEqual(actualCustomer2.Count, actualCustomer1.Count);
        }

        [TestMethod]
        public void CustomerItemsMethod_ListPopulatesAndMessageReceived_Expected_CorrectMessageReturned_Test()
        {
            // Arrange
            var checkoutBook = TestLibrary();
            var library = new Library(checkoutBook);
            
            var customer = "Tom";
            var title = "48039481";


            // Act
            library.CheckOutAnItem(title, customer);
            var actual = library.CustomerItems(customer).FirstOrDefault();

            var expected = $"Item: '{checkoutBook[title].Title}'\n" + $"Due in days: 3\n";

            // Assert
            Assert.AreEqual(expected, actual);
        }


        // DaysTillDue Tests:
        [TestMethod]
        public void DaysTillDueMethod_ExpectedNumberOfDaysReturned_Test()
        {
            // Arrange
            var checkoutBook = TestLibrary();
            var library = new Library(checkoutBook);

            var customer = "Tom";
            var title = "48039481";

            library.CheckOutAnItem(title, customer);
            var item = library.ItemsListByCustomer(customer).FirstOrDefault();

            // Act
            var actual = library.DaysTillDue(item);
            var expected = 3;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
