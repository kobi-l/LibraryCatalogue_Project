using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// JUSTIN : I would set, from inside these classes, the LibraryItem's ItemType.  
// JUSTIN : All library items should also be setting the ISBN so you can easily pull out the key you need. 
namespace LibraryCatalogueProject
{
    public class Book : LibraryItem_AbstractClass
    {
        public Book(string itemTitle)
        {
            Title = itemTitle;
            IsCheckedOut = false;
        }

        // would have the default LengthOfCheckoutPeriod of 14 days!!!
    }
}
