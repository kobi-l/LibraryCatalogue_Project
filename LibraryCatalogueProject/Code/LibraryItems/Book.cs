using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCatalogueProject
{
    public class Book : LibraryItem_AbstractClass
    {
        public Book(string bookTitle)
        {
            Title = bookTitle;
            IsCheckedOut = false;
        }

        // would have the default LengthOfCheckoutPeriod of 14 days!!!
    }
}
