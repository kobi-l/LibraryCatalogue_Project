using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Justin : You know... now that I think about it.... the concept of "NewRelease" item can really be
// an extension to any of the other items.  A book can be NewRelease or a Magazine, or even a DVD.  Perhaps
// instead of this being it's own thing, it can be an extension to Book or Magazine. 

// JUSTIN : I would set, from inside these classes, the LibraryItem's ItemType.  
namespace LibraryCatalogueProject
{
    public class NewRelease : LibraryItem_AbstractClass
    {
        const string Type = "NewReleaseBook";
        public NewRelease(string isbn, string itemTitle)
        {
            ISBN = isbn;
            Title = itemTitle;
            ItemType = Type;
            IsCheckedOut = false;
        }

        // Checkout period override
        public override TimeSpan LengthOfCheckoutPeriod { get; set; } = TimeSpan.FromDays(5);
    }
}
