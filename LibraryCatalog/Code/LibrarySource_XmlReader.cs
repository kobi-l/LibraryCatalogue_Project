using LibraryCatalogueProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace LibraryCatalogueProject.Code
{
    public class LibrarySource_XmlReader
    {
        public static Dictionary<string, Book> GetBooksUsingXmlDocument()
        {
            var newDictionary = new Dictionary<string, Book>();

            XmlDocument doc = new XmlDocument();
            doc.Load(@"C:\WorkSpace\LibraryCatalogue.xml");

            XmlNode root = doc.SelectSingleNode("LibraryItems");
            XmlNodeList node = root.SelectNodes("Item");

            foreach (XmlNode item in node)
                newDictionary.Add(item.ChildNodes[0].InnerText, new Book((item.ChildNodes[2].InnerText), (item.ChildNodes[1].InnerText)));

            return newDictionary;
        }
    }
}
