using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCatalogueProject
{
    public class NewRelease : LibraryItem_AbstractClass
    {
        public NewRelease(string bookTitle)
        {
            Title = bookTitle;
            IsCheckedOut = false;
        }

        // Checkout period override
        public override TimeSpan LengthOfCheckoutPeriod { get; set; } = TimeSpan.FromDays(5);
    }
}
