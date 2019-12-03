using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCatalogueProject
{
    public class Book : LibraryItem_AbstractClass
    {
        const string Type = "Book";
        public int PageCount { get; set; }

        public Book(string isbn, string itemTitle)
        {
            ISBN = isbn;
            Title = itemTitle;
            ItemType = Type;
            IsCheckedOut = false;
        }
    }
}
