using LibraryCatalog.Code.CustomExceptions;
using LibraryCatalog.Code.LibraryItems;
using LibraryCatalogueProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;

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
                { "48039480", new Book("48039480", "Harry Potter and the Sorcerer's Stone")},
                { "48039481", new MovieDVD("48039481", "Christmas Movie")},
                { "50000004", new Magazine("50000004", "Encyclopedia of Life")},
                { "50000006", new NewRelease("50000006", "Animal Tales")},
            };
        }
        #endregion


        // CheckOutAnItem Method Tests: 
        [TestMethod]
        public void CheckOutAnItem_CheckingOutItemThatDoesntExist_Expected_NULL_Test()
        {
            // Arrange
            var checkoutBook = new Library(TestLibrary());
            var date = DateTime.Today;

            var title = "48039480123";
            var customer = "Tom";


            // Act
            //void act() => checkoutBook.CheckOutAnItem(title, customer, date);

            // Assert
            // Assert.ThrowsException<LibraryItemDoesntExistException>(act);

            // Or using Fluent Assertion
            Action act = () => checkoutBook.CheckOutAnItem(title, customer, date);
            act.Should().Throw<LibraryItemDoesntExistException>();

        }

        [TestMethod]
        public void CheckOutAnItem_Expected_SuccessfulCheckout_Test()
        {
            // Arrange
            var checkoutBook = new Library(TestLibrary());
            var date = DateTime.Today;

            var title = "48039480";
            var customer = "Tom";

            // Act
            var actual = checkoutBook.CheckOutAnItem(title, customer, date);

            // Assert
            //Assert.AreNotEqual(null, actual);

            actual.Should().NotBeNull();
        }


        // CheckItemAvailability Method Tests:

        [TestMethod]
        public void CheckItemAvailability_InvalidItem_Expected_LibraryItemDoesntExistExceptionThrown_Test()
        {
            // Arrange
            var checkoutBook = new Library(TestLibrary());
            var title = "48039480454";

            // Act
            //void act() => checkoutBook.CheckItemAvailability(title);
            // Assert
            //Assert.ThrowsException<LibraryItemDoesntExistException>(act);

            // Fluen assertion:
            Action act = () => checkoutBook.CheckItemAvailability(title);
            act.Should().Throw<LibraryItemDoesntExistException>();
        }

        [TestMethod]
        public void CheckItemAvailabilityMethod_ValidItem_Expected_ReturnsTrue_Test()
        {
            // Arrange
            var checkoutBook = new Library(TestLibrary());
            var title = "48039481"; 

            // Act
            //var expected = true;
            var actual = checkoutBook.CheckItemAvailability(title);

            // Assert
            //Assert.AreEqual(expected, actual);

            // Fluet Assertion:
            actual.Should().BeTrue();
        }

        [TestMethod]
        public void CheckItemAvailabilityMethod_ValidCheckedOutItem_Expected_CustomExceptionMessage_Test()
        {
            // Arrange
            var checkoutBook = new Library(TestLibrary());
            var date = DateTime.Today;

            var isbn = "48039481"; //<-- DVD, checkout period 3 days
            var customer = "Tom";

            checkoutBook.CheckOutAnItem(isbn, customer, date);

            // Act
            //void act() => checkoutBook.CheckItemAvailability(isbn);
            // Assert
            //Assert.ThrowsException<LibraryItemAlreadyCheckedOutException>(act);

            // Fluent Assertion:
            Action act = () => checkoutBook.CheckItemAvailability(isbn);
            act.Should().Throw<LibraryItemAlreadyCheckedOutException>();
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
            //Assert.AreEqual(0, actual.Length());

            //Fluent Assertion
            actual.Length().Should().Be(0);
        }

        [TestMethod]
        public void CustomerItemsMethod_SingleCustomer_ListPopulatesWithItems_Expected_ListIsntEmpty_Test()
        {
            // Arrange
            var checkoutBook = new Library(TestLibrary());
            var date = DateTime.Today;

            var customer = "Tom";
            var title = "48039481";
            var title1 = "50000004";
            var title2 = "50000006";

            // Act
            checkoutBook.CheckOutAnItem(title, customer, date);
            checkoutBook.CheckOutAnItem(title1, customer, date);
            checkoutBook.CheckOutAnItem(title2, customer, date);

            var actual = checkoutBook.CustomerItems(customer);
            var expected = 3;

            // Assert
            //Assert.AreEqual(expected, actual.Count);

            actual.Count.Should().Be(expected);
        }

        [TestMethod]
        public void CustomerItemsMethod_TwoCustomers_ListPopulatesWithItems_Expected_ListIsntEmpty_Test()
        {
            // Arrange
            var checkoutBook = new Library(TestLibrary());
            var date = DateTime.Today;
            var customer1 = "Tom";
            var customer2 = "Sam";

            var title = "48039481";
            var title1 = "50000004";
            var title2 = "50000006";

            // Act
            checkoutBook.CheckOutAnItem(title2, customer1, date);
            checkoutBook.CheckOutAnItem(title, customer1, date);

            checkoutBook.CheckOutAnItem(title1, customer2, date);

            var actualCustomer1 = checkoutBook.CustomerItems(customer1);
            var actualCustomer2 = checkoutBook.CustomerItems(customer2);

            // Assert
            //Assert.AreNotEqual(actualCustomer2.Count, actualCustomer1.Count);

            // Fluent Assertion
            actualCustomer1.Count.Should().NotBe(actualCustomer2.Count);
        }

        [TestMethod]
        public void CustomerItemsMethod_ListPopulatesAndMessageReceived_Expected_CorrectMessageReturned_Test()
        {
            // Arrange
            var checkoutBook = TestLibrary();
            var library = new Library(checkoutBook);
            var date = DateTime.Today;

            var customer = "Tom";
            var isbn = "48039481";


            // Act
            library.CheckOutAnItem(isbn, customer, date);
            var actual = library.CustomerItems(customer).FirstOrDefault().Item.ISBN;

            var expected = isbn;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CustomerItemsMethod_ItemsRemovedFromTheList_WhenReturningItems_Test()
        {
            // Arrange
            var checkoutBook = TestLibrary();
            var library = new Library(checkoutBook);
            var date = DateTime.Today;

            var customer = "Tom";
            var title = "48039481";


            // Act
            // Checkout an item
            library.CheckOutAnItem(title, customer, date);
            var actualBeforeReturningItem = library.CustomerItems(customer);
            var expectedBeforeReturningItem = 1;


            // Return an item
            library.ReturnAnItem(title, date.AddDays(1));
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
            var date = DateTime.Today;

            var customer = "Tom";
            var title = "48039481";

            library.CheckOutAnItem(title, customer, date);
            var item = library.ItemsListByCustomer(customer).FirstOrDefault();

            // Act
            var actual = library.DaysTillDue(item, date);
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
            var date = DateTime.Today;
            var customer = "Tom";

            // Act
            var actual = library.OverdueItemsByCustomerName(customer, date);

            // Assert
            Assert.AreEqual(0, actual.Length());
        }

        [TestMethod]
        public void OverdueItemsByCustomerNameMethod_ListPopulatesWhenItemsOverdue__Test()
        {
            // Arrange
            var checkoutBook = TestLibrary();
            var library = new Library(checkoutBook);
            var date = DateTime.Today;
            var customer = "Tom";
            var title = "48039481";

            library.CheckOutAnItem(title, customer, date);
            //library.SetDay(DateTime.Today.AddDays(6));
            var expected = 1;

            // Act
            var actual = library.OverdueItemsByCustomerName(customer, date.AddDays(6));

            // Assert
            // Assert.AreEqual(expected, actual.Count);

            // Fluent Assertion
            actual.Count.Should().Be(expected);
        }

        [TestMethod]
        public void OverdueItemsByCustomerNameMethod_ExpectedMessageReturned_Test()
        {
            // Arrange
            var checkoutBook = TestLibrary();
            var library = new Library(checkoutBook);
            var date = DateTime.Today;
            var customer = "Tom";
            var isbn = "48039481";

            library.CheckOutAnItem(isbn, customer, date);

            var expected = isbn;

            // Act
            var actual = library.OverdueItemsByCustomerName(customer, date.AddDays(6)).FirstOrDefault().Item.ISBN;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        // ReturnAnItem Method Tests:
        [TestMethod]
        public void ReturnAnItemMethod_ReturningAnItemThatDoesntBelongToLibrary_ExpectedMessageReturned_Test()
        {
            // Arrange
            var checkoutBook = TestLibrary();
            var date = DateTime.Today.AddDays(3);
            var library = new Library(checkoutBook);

            // Act
            //Action act = () => library.ReturnAnItem("INVALID").FirstOrDefault();
            //void act() => library.ReturnAnItem("INVALID", date).FirstOrDefault();
            // Assert
            //Assert.ThrowsException<LibraryItemDoesntExistException>(act);

            // Fluent Assertion
            Action act = () => library.ReturnAnItem("INVALID", date).FirstOrDefault();

            act.Should().Throw<LibraryItemDoesntExistException>();
        }

        [TestMethod]
        public void ReturnAnItemMethod_ReturningAnItemOnTime_ExpectedMessageReturned_Test()
        {
            // Arrange
            var checkoutBook = TestLibrary();
            var library = new Library(checkoutBook);
            var date = DateTime.Today;
            var customer = "Tom";
            var isbn = "48039481";

            library.CheckOutAnItem(isbn, customer, date);

            var expectedMessage = "Item returned.Thank you!";

            // Act
            var actual = library.ReturnAnItem(isbn, date);

            // Assert
            //Assert.AreEqual(expectedMessage, actual);

            actual.Should().Be(expectedMessage);
        }

        [TestMethod]
        public void ReturnAnItemMethod_ReturningAnItemThatOverdue_ExpectedMessageReturned_Test()
        {
            // Arrange
            var checkoutBook = TestLibrary();
            var library = new Library(checkoutBook);
            var date = DateTime.Today;
            var customer = "Tom";
            var isbn = "48039481"; // <-- DVD, 3 days

            library.CheckOutAnItem(isbn, customer, date);

            var expectedMessage = $"You owe the library $3.5 because " +
                    $"'{checkoutBook[isbn].Title}' is 3 days overdue. " + "Item returned. Thank you!";

            // Act
            var actual = library.ReturnAnItem(isbn, date.AddDays(6));

            // Assert
            //Assert.AreEqual(expectedMessage, actual);

            actual.Should().Be(expectedMessage);
        }
    }
}
