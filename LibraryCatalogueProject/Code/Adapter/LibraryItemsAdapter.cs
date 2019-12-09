using LibraryCatalog.Code.Enums;
using LibraryCatalog.Code.Interfaces;
using LibraryCatalogueProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCatalog.Code.Adapter
{
    public class LibraryItemsAdapter : ILibraryItemStatus
    {
        public ILibraryItem Item { get; }
        public int DaysTillDue { get; }
        public LibraryItemStatus ItemStatus { get; set; }
        public LibraryItemsAdapter(ILibraryItem item, int daysTillDue)
        {
            Item = item;
            DaysTillDue = daysTillDue;
            ItemStatus = CalculateItemStatus(item, daysTillDue);
        }

        public LibraryItemStatus CalculateItemStatus(ILibraryItem item, int daysTillDue)
        {
            if (!item.IsCheckedOut)
                return LibraryItemStatus.Available;

            if (daysTillDue == 0)
                return LibraryItemStatus.Due;

            return daysTillDue < 0 ? LibraryItemStatus.Overdue : LibraryItemStatus.CheckedOut;
        }
    }
}
