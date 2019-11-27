using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCatalogueProject
{
    public class LibraryItem_AbstractClass : ILibraryItem
    {
        // Properties: 
        public string Title { get; set; }
        public string ItemType { get; set; }
        public int PageCount { get; set; }
        public int ISBN { get; set; }
        public bool IsCheckedOut { get; set; }
        public DateTime? DayCheckedOut { get; set; } = null;
        public string WhoWasItCheckeoutTo { get; set; }
        public virtual TimeSpan LengthOfCheckoutPeriod { get; set; } = TimeSpan.FromDays(14);
        public int BookQuantity { get; set; }

        // Methods 
        public void SetIsCheckedOut(Boolean newIsCheckedOut, DateTime? currentDayCheckedOut, string customer)
        {
            IsCheckedOut = newIsCheckedOut;
            SetDayCheckedOut(currentDayCheckedOut);
            WhoWasItCheckeoutTo = customer;
            BookQuantity--;
        }

        public void SetDayCheckedOut(DateTime? day) => this.DayCheckedOut = day;
    }
}
