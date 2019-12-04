using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCatalogueProject
{
    public class Magazine : LibraryItem_AbstractClass
    {
        const string Type = "Magazine";
        public Magazine(string isbn, string itemTitle)
        {
            ISBN = isbn;
            Title = itemTitle;
            ItemType = Type;
            IsCheckedOut = false;
        }

        // Checkout period override
        public override TimeSpan LengthOfCheckoutPeriod { get; set; } = TimeSpan.FromDays(7);
    }
}
