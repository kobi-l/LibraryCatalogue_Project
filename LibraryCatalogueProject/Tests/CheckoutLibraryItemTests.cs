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
        public Dictionary<string, ILibraryItem> FakeLibrary()
        {
            return new Dictionary<string, ILibraryItem>();
            //{
            //    { "48039480", new ILibraryItem("Harry Potter and the Sorcerer's Stone", "Book", 3) },
            //    { "48039481", new LibraryItem("Harry Potter and the Chamber of Secrets", "Book", 2)},
            //    { "50000004", new LibraryItem("Encyclopedia of Life", "Magazine", 4)},
            //    { "50000006", new LibraryItem("Animal Tales", "Magazine", 5)},
            //    { "70000015", new LibraryItem("The Dutch House", "NewReleaseBook", 1)},
            //    { "70000013", new LibraryItem("Someone We Know", "NewReleaseBook", 3)},
            //    { "70000014", new LibraryItem("The Water Dancer", "NewReleaseBook", 2)}
            //};
        }
        #endregion

        [TestMethod]
        public void CheckingOutBook_ExpectedMessage_YouJustCheckedOutBook()
        {
            // Arrange
            var checkoutBook = new Library(FakeLibrary());
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
