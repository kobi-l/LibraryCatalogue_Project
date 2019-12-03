using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCatalogueProject
{
    public interface ILibraryItem
    {
        // Properties: 
        string Title { get; set; }
        string ItemType { get; set; }
        string ISBN { get; set; }
        bool IsCheckedOut { get; set; }
        DateTime? DayCheckedOut { get; set; }
        string WhoWasItCheckeoutTo { get; set; }
        TimeSpan LengthOfCheckoutPeriod { get; set; }

        // Methods 
        void CheckOutItem(DateTime? currentDayCheckedOut, string customer);
        void CheckInItem();
    }
}
