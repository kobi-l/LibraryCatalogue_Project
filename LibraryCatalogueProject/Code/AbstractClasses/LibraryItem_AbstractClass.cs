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
        public string ISBN { get; set; }
        public bool IsCheckedOut { get; set; }
        public DateTime? DayCheckedOut { get; set; } = null;
        public string WhoWasItCheckeoutTo { get; set; }
        public virtual TimeSpan LengthOfCheckoutPeriod { get; set; } = TimeSpan.FromDays(14);
        public void CheckOutItem(DateTime? currentDay, string customer)
        {
            IsCheckedOut = true;
            DayCheckedOut = currentDay;
            WhoWasItCheckeoutTo = customer;
        }
        public void CheckInItem()
        {
            IsCheckedOut = false;
            DayCheckedOut = null;
            WhoWasItCheckeoutTo = null;
        }
    }
}
