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
        public void CheckItemAvailability_InvalidItem_Expected_LibraryItemDoesntExistExceptionThrown_Test()
        {
            // Arrange
            var checkoutBook = new Library(TestLibrary());
            var title = "48039480454";

            // Act
            Action act = () => checkoutBook.CheckItemAvailability(title, out string message);

            // Assert
            Assert.ThrowsException<LibraryItemDoesntExistException>(act);
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
            //var expectedMessage = $"Sorry, 'Christmas Movie' had been taken out! It should be back in 3 days.\n";

            // Act
            Action act = () => checkoutBook.CheckItemAvailability(title, out string message);

            // Assert
            //var exception = Assert.ThrowsException<LibraryItemAlreadyCheckedOutException>(act);
            Assert.ThrowsException<LibraryItemAlreadyCheckedOutException>(act);
            //Assert.AreEqual(expectedMessage, exception.Message);
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
        public void CustomerItemsMethod_SingleCustomer_ListPopulatesWithItems_Expected_ListIsntEmpty_Test()
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
        public void CustomerItemsMethod_TwoCustomers_ListPopulatesWithItems_Expected_ListIsntEmpty_Test()
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

        [TestMethod]
        public void CustomerItemsMethod_ItemsRemovedFromTheList_WhenReturningItems_Test()
        {
            // Arrange
            var checkoutBook = TestLibrary();
            var library = new Library(checkoutBook);

            var customer = "Tom";
            var title = "48039481";


            // Act
            // Checkout an item
            library.CheckOutAnItem(title, customer);
            var actualBeforeReturningItem = library.CustomerItems(customer);
            var expectedBeforeReturningItem = 1;


            // Return an item
            library.ReturnAnItem(title);
            var actualAfterReturnigItem = library.CustomerItems(customer);
            var expectedAfterReturningItem = 0;

            // Assert
            Assert.AreEqual(expectedBeforeReturningItem, actualBeforeReturningItem.Count);
            Assert.AreEqual(expectedAfterReturningItem, actualAfterReturnigItem.Count);
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

        // OverdueItemsByCustomerName Method Tests:
        [TestMethod]
        public void OverdueItemsByCustomerNameMethod_ListCanBeEmpty__Test()
        {
            // Arrange
            var checkoutBook = TestLibrary();
            var library = new Library(checkoutBook);
            var customer = "Tom";

            // Act
            var actual = library.OverdueItemsByCustomerName(customer);

            // Assert
            Assert.AreEqual(0, actual.Length());
        }

        [TestMethod]
        public void OverdueItemsByCustomerNameMethod_ListPopulatesWhenItemsOverdue__Test()
        {
            // Arrange
            var checkoutBook = TestLibrary();
            var library = new Library(checkoutBook);
            var customer = "Tom";
            var title = "48039481";

            library.CheckOutAnItem(title, customer);
            library.SetDay(DateTime.Today.AddDays(6));
            var expected = 1;

            // Act
            var actual = library.OverdueItemsByCustomerName(customer);

            // Assert
            Assert.AreEqual(expected, actual.Count);
        }

        [TestMethod]
        public void OverdueItemsByCustomerNameMethod_ExpectedMessageReturned_Test()
        {
            // Arrange
            var checkoutBook = TestLibrary();
            var library = new Library(checkoutBook);
            var customer = "Tom";
            var title = "48039481";

            library.CheckOutAnItem(title, customer);
            library.SetDay(DateTime.Today.AddDays(6));

            var expected = $"'{checkoutBook[title].Title}'\nDays late: 3\n";

            // Act
            var actual = library.OverdueItemsByCustomerName(customer).FirstOrDefault();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        // ReturnAnItem Method Tests:
        [TestMethod]
        public void ReturnAnItemMethod_ReturningAnItemThatDoesntBelongToLibrary_ExpectedMessageReturned_Test()
        {
            // Arrange
            var checkoutBook = TestLibrary();
            var library = new Library(checkoutBook);

            // Act
            Action act = () => library.ReturnAnItem("INVALID").FirstOrDefault();

            // Assert
            Assert.ThrowsException<LibraryItemDoesntExistException>(act);
        }

        [TestMethod]
        public void ReturnAnItemMethod_ReturningAnItemOnTime_ExpectedMessageReturned_Test()
        {
            // Arrange
            var checkoutBook = TestLibrary();
            var library = new Library(checkoutBook);
            var customer = "Tom";
            var title = "48039481";

            library.CheckOutAnItem(title, customer);

            var expectedMessage = "Item returned.Thank you!\n";

            // Act
            var actual = library.ReturnAnItem(title);

            // Assert
            Assert.AreEqual(expectedMessage, actual.FirstOrDefault());
        }

        [TestMethod]
        public void ReturnAnItemMethod_ReturningAnItemThatOverdue_ExpectedMessageReturned_Test()
        {
            // Arrange
            var checkoutBook = TestLibrary();
            var library = new Library(checkoutBook);
            var customer = "Tom";
            var title = "48039481"; // <-- DVD, 3 days

            library.CheckOutAnItem(title, customer);

            library.SetDay(DateTime.Today.AddDays(6));


            var expectedMessage = $"You owe the library $3.5 because " +
                    $"'{checkoutBook[title].Title}' is 3 days overdue. " + "Item returned. Thank you!\n";

            // Act
            var actual = library.ReturnAnItem(title).FirstOrDefault();

            // Assert
            Assert.AreEqual(expectedMessage, actual);
        }

        private void ArrangeTests()
        {
            var checkoutBook = TestLibrary();
            var library = new Library(checkoutBook);
            var customer = "Tom";
            var title = "48039481"; // <-- DVD, 3 days

            library.CheckOutAnItem(title, customer);
        }
    }
}
