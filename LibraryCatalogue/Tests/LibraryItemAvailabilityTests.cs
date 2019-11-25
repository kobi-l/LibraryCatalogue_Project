using LanguageExt.ClassInstances.Pred;
using LibraryCatalogueProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace LibraryCatalog.Tests
{   
    [TestClass]
    public class LibraryItemAvailabilityTests
    {
        #region FAKE LIBRARY
        public Dictionary<string, Book> FakeLibrary()
        {
            return new Dictionary<string, Book>()
            {
                { "48039480", new Book("Harry Potter and the Sorcerer's Stone", "Book", 3) },
                { "48039481", new Book("Harry Potter and the Chamber of Secrets", "Book", 2)},
                { "50000004", new Book("Encyclopedia of Life", "Magazine", 4)},
                { "50000006", new Book("Animal Tales", "Magazine", 5)},
                { "70000015", new Book("The Dutch House", "NewReleaseBook", 1)},
                { "70000013", new Book("Someone We Know", "NewReleaseBook", 3)},
                { "70000014", new Book("The Water Dancer", "NewReleaseBook", 2)}
            };
        }
        #endregion

        [TestMethod]
        public void BookAvailability_RequestedItemExists_WeHaveItmessageExpected()
        {
            // Arrange
            var libraryCatalogue = new LibraryCatalogue(FakeLibrary());
            libraryCatalogue.CheckBookAvailability("50000006");

            //// Act
            var expected = "We have 'Animal Tales'!";

            // Assert
            //Assert.AreEqual<string>(expected, );
            StringAssert.Contains(expected, "We have 'Animal Tales'");
        }

        [TestMethod]
        public void BookAvailability_RequestedItemDoesntExists_WeDontHaveItmessageExpected()
        {
            // Arrange
            var libraryCatalogue = new LibraryCatalogue(FakeLibrary());
            libraryCatalogue.CheckBookAvailability("500000066");

            //// Act
            var expected = "Sorry, we don't have '500000066' book.";
            var actual = Console.OpenStandardOutput();

            // Assert
            Assert.AreEqual(expected, actual);
            //Matches(expected, redex);
            //StringAssert.Contains(expected, "We have 'Animal Tales'");
            //Assert.AreEqual<string>(expected, actual);

        }
    }
}
