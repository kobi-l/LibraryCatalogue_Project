using LibraryCatalog.Code.LibraryItems;
using System;
using System.Collections.Generic;
using System.Xml;

namespace LibraryCatalogueProject
{
    public class PopulateCatalogue
    {
        
        private Dictionary<string, ILibraryItem> ProcessXML(XmlDocument xmlFile)
        {
            var newDictionary = new Dictionary<string, ILibraryItem>(StringComparer.OrdinalIgnoreCase); // StringComparer.OrdinalIgnoreCase

            XmlNode root = xmlFile.SelectSingleNode("LibraryItems");
            XmlNodeList node = root.SelectNodes("Item");

            foreach (XmlNode item in node)
            {
                var isbn = item.ChildNodes[0].InnerText.ToUpper();
                var itemTitle = item.ChildNodes[2].InnerText;
                var itemType = item.ChildNodes[1].InnerText;

                try
                {
                    if (string.Equals(itemType, "Book", StringComparison.CurrentCultureIgnoreCase))
                    {
                        var book = CreateBook(isbn, itemTitle);
                        newDictionary.Add(isbn, book);
                    }
                    if (string.Equals(itemType, "Magazine", StringComparison.CurrentCultureIgnoreCase))
                    {
                        var magazine = CreateMagazine(isbn, itemTitle);
                        newDictionary.Add(isbn, magazine);
                    }
                    if (string.Equals(itemType, "NewReleaseBook", StringComparison.CurrentCultureIgnoreCase))
                    {
                        var newRelease = CreateNewRelease(isbn, itemTitle);
                        newDictionary.Add(isbn, newRelease);
                    }
                    if (string.Equals(itemType, "DVD", StringComparison.CurrentCultureIgnoreCase))
                    {
                        var newDvd = CreateDVD(isbn, itemTitle);
                        newDictionary.Add(isbn, newDvd);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }  
            }
            return newDictionary;
        }

        // using XmlDocument 
        public Dictionary<string, ILibraryItem> GetItemsFromXmlDocument(XmlDocument xmlFile) 
        {
            return ProcessXML(xmlFile);
        }

        public Dictionary<string, ILibraryItem> GetItemsFromXmlDocument(string xmlFilePath)
        {

            XmlDocument doc = new XmlDocument();
            doc.Load(xmlFilePath); 

            return ProcessXML(doc);
        }

        private ILibraryItem CreateDVD(string isbn, string itemTitle)
        {
            var dvdMovie = new MovieDVD(isbn, itemTitle);
            return dvdMovie;
        }

        private ILibraryItem CreateBook(string isbn, string itemTitle)
        {
            var book = new Book(isbn, itemTitle);
            return book;
        }

        private ILibraryItem CreateMagazine(string isbn, string itemTitle)
        {
            var magazine = new Magazine(isbn, itemTitle);
            return magazine;
        }

        private ILibraryItem CreateNewRelease(string isbn, string itemTitle)
        {
            var newRelease = new NewRelease(isbn, itemTitle);
            return newRelease;
        }
    }
}
