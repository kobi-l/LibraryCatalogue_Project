using LibraryCatalogueProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// JUSTIN : I would set, from inside these classes, the LibraryItem's ItemType.  
namespace LibraryCatalog.Code.LibraryItems
{
    public class MovieDVD : LibraryItem_AbstractClass
    {
        public MovieDVD(string itemTitle)
        {
            Title = itemTitle;
            IsCheckedOut = false;
        }

        // Checkout period override
        public override TimeSpan LengthOfCheckoutPeriod { get; set; } = TimeSpan.FromDays(3);
    }
}
