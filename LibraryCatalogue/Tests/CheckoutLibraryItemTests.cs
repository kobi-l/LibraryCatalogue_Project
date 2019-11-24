using LibraryCatalogueProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCatalog.Tests
{
    [TestClass]
    public class CheckoutLibraryItemTests
    {
        #region FAKE LIBRARY
        public Dictionary<string, Book> FakeLibrary()
        {
            return new Dictionary<string, Book>()
            {
                { "48039480", new Book("Harry Potter and the Sorcerer's Stone", "Book") },
                { "48039481", new Book("Harry Potter and the Chamber of Secrets", "Book")},
                { "50000004", new Book("Encyclopedia of Life", "Magazine")},
                { "50000006", new Book("Animal Tales", "Magazine")},
                { "70000015", new Book("The Dutch House", "NewReleaseBook")},
                { "70000013", new Book("Someone We Know", "NewReleaseBook")},
                { "70000014", new Book("The Water Dancer", "NewReleaseBook")}
            };
        }
        #endregion

        [TestMethod]
        public void CheckingOutBook_ExpectedMessage_YouJustCheckedOutBook()
        {
            // Arrange
            var checkoutBook = new LibraryCatalogue(FakeLibrary());
            var title = "48039480";
            var customer = "Tom";

            checkoutBook.CheckOutBook(title, customer);

            //// Act
            var expected = $"You just checked out '{title}'";
            var actual = Console.OpenStandardOutput();

            // Assert
            Assert.AreEqual(expected, actual);
            //Matches(expected, redex);
            //StringAssert.Contains(expected, "We have 'Animal Tales'");
            //Assert.AreEqual<string>(expected, actual);

        }
    }
}
