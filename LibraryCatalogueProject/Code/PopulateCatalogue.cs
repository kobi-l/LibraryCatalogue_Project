using LibraryCatalog.Code.LibraryItems;
using System;
using System.Collections.Generic;
using System.Xml;

namespace LibraryCatalogueProject
{
    public class PopulateCatalogue
    {
        // using XmlDocument 
        public Dictionary<string, ILibraryItem> GetItemsFromXmlDocument(string xmlFilePath)
        {
            var newDictionary = new Dictionary<string, ILibraryItem>();

            XmlDocument doc = new XmlDocument();
            doc.Load(xmlFilePath); 

            XmlNode root = doc.SelectSingleNode("LibraryItems");
            XmlNodeList node = root.SelectNodes("Item");

            foreach (XmlNode item in node)
            {
                var isbnKey = item.ChildNodes[0].InnerText;
                var itemTitle = item.ChildNodes[2].InnerText;

                if (item.ChildNodes[1].InnerText == "Book")
                {
                    var book = CreateBook(itemTitle);
                    newDictionary.Add(isbnKey, book);
                }
                if (item.ChildNodes[1].InnerText == "Magazine")
                {
                    var magazine = CreateMagazine(itemTitle);
                    newDictionary.Add(isbnKey, magazine);
                }
                if (item.ChildNodes[1].InnerText == "NewReleaseBook")
                {
                    var newRelease = CreateNewRelease(itemTitle);
                    newDictionary.Add(isbnKey, newRelease);
                }
                if (item.ChildNodes[1].InnerText == "DVD")
                {
                    var newDvd = CreateDVD(itemTitle);
                    newDictionary.Add(isbnKey, newDvd);
                }
            }
            return newDictionary;
        }
        private ILibraryItem CreateDVD(string itemTitle)
        {
            var dvdMovie = new MovieDVD(itemTitle);
            return dvdMovie;
        }

        private ILibraryItem CreateBook(string itemTitle)
        {
            var book = new Book(itemTitle);
            return book;
        }

        private ILibraryItem CreateMagazine(string itemTitle)
        {
            var magazine = new Magazine(itemTitle);
            return magazine;
        }

        private ILibraryItem CreateNewRelease(string itemTitle)
        {
            var newRelease = new NewRelease(itemTitle);
            return newRelease;
        }
    }
}
