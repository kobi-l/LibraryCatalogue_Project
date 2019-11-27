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
            doc.Load(xmlFilePath); //@"C:\WorkSpace\LibraryCatalogue.xml"

            XmlNode root = doc.SelectSingleNode("LibraryItems");
            XmlNodeList node = root.SelectNodes("Item");

            foreach (XmlNode item in node)
            {
                var isbnKey = item.ChildNodes[0].InnerText;

                if (item.ChildNodes[1].InnerText == "Book")
                {
                    var book = CreateBook(item.ChildNodes[2].InnerText);
                    newDictionary.Add(isbnKey, book);
                }
                if (item.ChildNodes[1].InnerText == "Magazine")
                {
                    var magazine = CreateMagazine(item.ChildNodes[2].InnerText);
                    newDictionary.Add(isbnKey, magazine);
                }
                if (item.ChildNodes[1].InnerText == "NewRelease")
                {
                    var newRelease = CreateNewRelease(item.ChildNodes[2].InnerText);
                    newDictionary.Add(isbnKey, newRelease);
                }
            }
            return newDictionary;
        }

        public void ReadFromXML()
        {
            //var readXML = XmlReader.Create(@"C:\WorkSpace\LibraryCatalogue.xml");
            //var newDictionary = new Dictionary<string, ILibraryItem>();

            //while (readXML.Read())
            //{
            //    switch (readXML.Name.ToString())
            //    {
            //        case "Book":
            //            var book = CreateBook(item.ChildNodes[2].InnerText, TimeSpan.Parse(item.ChildNodes[3].InnerText));
            //            newDictionary.Add(isbnKey, book);
            //            break;
            //        case "Magazine":
            //            CreateMagazine(int isbn, string bookTitle, TimeSpan lengthOfCheckoutPeriod);
            //            break;
            //        case "NewRelease":
            //            CreateNewRelease(int isbn, string bookTitle, TimeSpan lengthOfCheckoutPeriod);
            //            break;
            //    }
            //}
        }


        private ILibraryItem CreateBook(string bookTitle)
        {
            var book = new Book(bookTitle);
            return book;
        }

        private ILibraryItem CreateMagazine(string bookTitle)
        {
            var magazine = new Magazine(bookTitle);
            return magazine;
        }

        private ILibraryItem CreateNewRelease(string bookTitle)
        {
            var newRelease = new NewRelease(bookTitle);
            return newRelease;
        }
    }
}
