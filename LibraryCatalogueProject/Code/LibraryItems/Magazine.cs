using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCatalogueProject
{
    public class Magazine : LibraryItem_AbstractClass
    {
        public Magazine(string bookTitle)
        {
            Title = bookTitle;
            IsCheckedOut = false;

            //ISBN = isbn;
            //LengthOfCheckoutPeriod = lengthOfCheckoutPeriod;
            //BookQuantity = bookQuantity;
        }

        // Checkout period override
        public override TimeSpan LengthOfCheckoutPeriod { get; set; } = TimeSpan.FromDays(7);
    }
}
