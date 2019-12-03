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
                var isbnKey = item.ChildNodes[0].InnerText.ToUpper();
                var itemTitle = item.ChildNodes[2].InnerText;
                var typeName = item.ChildNodes[1].InnerText;

                //string.Equals(a, b, StringComparison.CurrentCultureIgnoreCase);
                // JUSTIN : You need to be storing the ISBN on the LibraryItem so you can 
                // get the key you need to check in and check out books. 
                try
                {
                    if (string.Equals(typeName, "Book", StringComparison.CurrentCultureIgnoreCase))
                    {
                        var book = CreateBook(itemTitle);
                        newDictionary.Add(isbnKey, book);
                    }
                    if (string.Equals(typeName, "Magazine", StringComparison.CurrentCultureIgnoreCase))
                    {
                        var magazine = CreateMagazine(itemTitle);
                        newDictionary.Add(isbnKey, magazine);
                    }
                    if (string.Equals(typeName, "NewReleaseBook", StringComparison.CurrentCultureIgnoreCase))
                    {
                        var newRelease = CreateNewRelease(itemTitle);
                        newDictionary.Add(isbnKey, newRelease);
                    }
                    if (string.Equals(typeName, "DVD", StringComparison.CurrentCultureIgnoreCase))
                    {
                        var newDvd = CreateDVD(itemTitle);
                        newDictionary.Add(isbnKey, newDvd);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                    //ex.Message.ToString();
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
