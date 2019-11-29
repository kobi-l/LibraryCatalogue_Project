using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibraryCatalogueProject;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System;

namespace LibraryCatalog.Tests
{
    [TestClass]
	public class Tests
	{
        #region METHODS
        // #1 creating Parent element: 
        private XmlDocument CreateXML(string isbn, string type, string title)
        {
            var xmlDocument = CreatingXMLDocument();
            var rootElement = CreatingRoot(xmlDocument);

            // ITEM - Parent element:
            XmlElement item = xmlDocument.CreateElement(string.Empty, "Item", string.Empty);
            rootElement.AppendChild(item);

            AddingChildrenToXML(xmlDocument, item, isbn, type, title);

            return xmlDocument;
        }

        private XmlDocument CreateXML(string[,] child)
        {
            var xmlDocument = CreatingXMLDocument();
            var rootElement = CreatingRoot(xmlDocument);

            foreach (string libraryItem in child)
            {
                // ITEM - Parent element:
                XmlElement item = xmlDocument.CreateElement(string.Empty, "Item", string.Empty);
                rootElement.AppendChild(item);

                AddingChildrenToXML(xmlDocument, item, child[0, 0], child[0, 1], child[0, 2]);
            }
            return xmlDocument;
        }

        //private string Strings()
        //{
        //    string[] stringArray = { };

        //    return stringArray;
        //}

        // #1 creating a document:
        private XmlDocument CreatingXMLDocument()
        {
            XmlDocument xmlDocument = new XmlDocument();

            // XML declaration - recommended, but not mandatory
            XmlDeclaration xmlDeclaration = xmlDocument.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement root = xmlDocument.DocumentElement;
            xmlDocument.InsertBefore(xmlDeclaration, root);

            

            return xmlDocument;
        }

        // #2 creating a root element:
        private XmlElement CreatingRoot(XmlDocument xmlDocument)
        {

            // Root element - LibraryItems
            XmlElement rootElement = xmlDocument.CreateElement(string.Empty, "LibraryItems", string.Empty);
            xmlDocument.AppendChild(rootElement);

            return rootElement;
        }


        private void AddingChildrenToXML(XmlDocument xmlDocument, XmlElement parentElement, string isbn, string type, string title)
        {
            
            // ISBN - child element:
            XmlElement isbnChild = xmlDocument.CreateElement(string.Empty, "ISBN", string.Empty);
            XmlText isbnValue = xmlDocument.CreateTextNode(isbn);
            isbnChild.AppendChild(isbnValue);
            parentElement.AppendChild(isbnChild);

            // TYPE - child element:
            XmlElement typeChild = xmlDocument.CreateElement(string.Empty, "Type", string.Empty);
            XmlText typeValue = xmlDocument.CreateTextNode(type);
            typeChild.AppendChild(typeValue);
            parentElement.AppendChild(typeChild);

            // TITLE - child element:
            XmlElement titleChild = xmlDocument.CreateElement(string.Empty, "Title", string.Empty);
            XmlText titleValue = xmlDocument.CreateTextNode(title);
            titleChild.AppendChild(titleValue);
            parentElement.AppendChild(titleChild);
        }

        #endregion

        [TestMethod]
		public void XMLPopulate_AddingOneNode_ReturnsOneDictionaryItem_Test()
		{
            // Arrange
            var isbn = "2423434";
            var type = "DVD";
            var title = "movie";

            // Act
            var readXML = new PopulateCatalogue();
            var catalog = readXML.GetItemsFromXmlDocument(CreateXML(isbn, type, title));

            // Assert
            Assert.AreEqual(1, catalog.Count); // items in catalog
        }

        [TestMethod]
        public void XMLPopulate_PassedInValues_ShouldPersist_Test()
        {
            // Arrange
            var isbn = "2423434";
            var type = "DVD";
            var title = "movie";

            // Act
            var readXML = new PopulateCatalogue();
            var catalog = readXML.GetItemsFromXmlDocument(CreateXML(isbn, type, title));

            // Assert
            Assert.AreEqual(isbn, catalog.First().Key);
            Assert.AreEqual(title, catalog.First().Value.Title);
        }

        [TestMethod]
        public void XMLPopulate_PassingInDuplicateIsbn_ShouldBeRegected_AndMessageIsDisplayed_Test()
        {
            // Arrange
            var isbn = "2423434";
            var type = "DVD";
            var title = "movie";

            string[,] data = new string[2, 3]{
                {isbn,type, title},
                {isbn,type, title}
            };

            var document = CreateXML(data);
            var readXML = new PopulateCatalogue();

            var expectedMessage = "An item with the same key has already been added.";

            // Act
            Action act = () => readXML.GetItemsFromXmlDocument(document); // called 

            // Assert
            var exception = Assert.ThrowsException<ArgumentException>(act);
            Assert.AreEqual(expectedMessage, exception.Message);
        }

        [TestMethod]
        public void XMLPopulate_TypeDVD_ExpectedToBeAccepted_Test()
        {
            // Arrange
            var isbn = "2423434";
            var type = "DVD";
            var title = "movie";

            // Act
            var readXML = new PopulateCatalogue();
            var catalog = readXML.GetItemsFromXmlDocument(CreateXML(isbn, type, title));

            // Assert
            Assert.AreEqual(1, catalog.Count);
        }

        [TestMethod]
        public void XMLGetsPopulated_TypeBook_ExpectedToBeAccepted_Test()
        {
            // Arrange
            var isbn = "2423434";
            var type = "Book";
            var title = "book";

            // Act
            var readXML = new PopulateCatalogue();
            var catalog = readXML.GetItemsFromXmlDocument(CreateXML(isbn, type, title));

            // Assert
            Assert.AreEqual(1, catalog.Count);
        }

        [TestMethod]
        public void XMLPopulate_TypeMagazine_ExpectedToBeAccepted_Test()
        {
            // Arrange
            var isbn = "2423434";
            var type = "Magazine";
            var title = "magazine";

            // Act
            var readXML = new PopulateCatalogue();
            var catalog = readXML.GetItemsFromXmlDocument(CreateXML(isbn, type, title));

            // Assert
            Assert.AreEqual(1, catalog.Count);
        }

        [TestMethod]
        public void XMLPopulate_TypeNewReleaseBook_ExpectedToBeAccepted_Test()
        {
            // Arrange
            var isbn = "2423434";
            var type = "NewReleaseBook";
            var title = "newRelease";

            // Act
            var readXML = new PopulateCatalogue();
            var catalog = readXML.GetItemsFromXmlDocument(CreateXML(isbn, type, title));

            // Assert
            Assert.AreEqual(1, catalog.Count);
        }

        [TestMethod]
        public void XMLPopulate_PassingInInvalidType_ShouldNotBeAccepted_Test()
        {
            // Arrange
            var isbn = "2423434";
            var type = "invalidType";
            var title = "invalid";

            // Act
            var readXML = new PopulateCatalogue();
            var catalog = readXML.GetItemsFromXmlDocument(CreateXML(isbn, type, title));

            // Assert
            Assert.AreEqual(0, catalog.Count);
        }

        [TestMethod]
        public void XMLPopulate_PassingInValidTypeLowerCase_ShouldBeAccepted_Test()
        {
            // Arrange
            var isbn = "2423434";
            var type = "dvd";
            var title = "movie";

            // Act
            var readXML = new PopulateCatalogue();
            var catalog = readXML.GetItemsFromXmlDocument(CreateXML(isbn, type, title));

            // Assert
            Assert.AreEqual(1, catalog.Count);
        }

        [TestMethod]
        public void XMLPopulate_PassingInValidTypeUpperCase_ShouldBeAccepted_Test()
        {
            // Arrange
            var isbn = "2423434";
            var type = "MAGAZINE";
            var title = "magazine";

            // Act
            var readXML = new PopulateCatalogue();
            var catalog = readXML.GetItemsFromXmlDocument(CreateXML(isbn, type, title));

            // Assert
            Assert.AreEqual(1, catalog.Count);
        }

        [TestMethod]
        public void XMLPopulate_PassingInIsbnMixedCase_ShouldBeAccepted_Test()
        {
            // Arrange
            var isbn = "abc123";
            var type = "dvd";
            var title = "magazine";

            // Act
            var readXML = new PopulateCatalogue();
            var catalog = readXML.GetItemsFromXmlDocument(CreateXML(isbn, type, title));

            // Assert
            Assert.AreEqual(1, catalog.Count);
            Assert.AreEqual(isbn.ToUpper(), catalog.First().Key);
        }

        [TestMethod]
        public void XMLPopulate_GettingIsbnMixedCase_ShouldBeAccepted_Test()
        {
            // Arrange
            var isbn = "abc123";
            var type = "dvd";
            var title = "magazine";

            // Act
            var readXML = new PopulateCatalogue();
            var catalog = readXML.GetItemsFromXmlDocument(CreateXML(isbn, type, title));

            // Assert
            Assert.AreEqual(1, catalog.Count);

            var item = catalog[isbn];

            Assert.IsNotNull(item);
            Assert.AreEqual(title, item.Title);
        }


        //      [TestMethod]
        //public void LibraryItemsCanBeRetrievedByKey()
        //{
        //	// Arrange
        //	var libraryCatalogue = new Library(FakeLibrary());

        //	// Act
        //	var valueByKey = libraryCatalogue.LibraryCatalogue["48039480"].Title;
        //	var expected = "Harry Potter and the Sorcerer's Stone";

        //	// Assert
        //	Assert.AreEqual(valueByKey, expected);
        //}

        //[TestMethod]
        //public void LibraryItemsHave_ItemType_Book()
        //{
        //	//Arrange
        //	var libraryCatalogue = new Library(FakeLibrary());

        //	//Act
        //	var bookType = libraryCatalogue.LibraryCatalogue["48039480"].ItemType;
        //	var expectedBook = "Book";

        //	//Assert
        //	Assert.AreEqual(expectedBook, bookType);
        //}

        //[TestMethod]
        //public void LibraryItemsHave_ItemType_Magazine()
        //{
        //	//Arrange
        //	var libraryCatalogue = new Library(FakeLibrary());

        //	//Act
        //	var bookType = libraryCatalogue.LibraryCatalogue["50000004"].ItemType;
        //	var expectedBook = "Magazine";

        //	//Assert
        //	Assert.AreEqual(expectedBook, bookType);
        //}

        //[TestMethod]
        //public void LibraryItemsHave_ItemType_NewReleaseBook()
        //{
        //	//Arrange
        //	var libraryCatalogue = new Library(FakeLibrary());

        //	//Act
        //	var bookType = libraryCatalogue.LibraryCatalogue["70000015"].ItemType;
        //	var expectedBook = "NewReleaseBook";

        //	//Assert
        //	Assert.AreEqual(expectedBook, bookType);
        //}
    }
}
