using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCatalogueProject
{
    // JUSTIN : You need to be setting ISBN so that you can pull out the key you need to check in and checkout out the items
    public interface ILibraryItem
    {
        // Properties: 
        string Title { get; set; }
        string ItemType { get; set; }
        int PageCount { get; set; }
        int ISBN { get; set; }
        bool IsCheckedOut { get; set; }
        DateTime? DayCheckedOut { get; set; }
        string WhoWasItCheckeoutTo { get; set; }
        TimeSpan LengthOfCheckoutPeriod { get; set; }
        int BookQuantity { get; set; }

        // Methods 
        void SetIsCheckedOut(Boolean newIsCheckedOut, DateTime? currentDayCheckedOut, string customer);
        void SetDayCheckedOut(DateTime? day);
    }
}
