using LibraryCatalog.Code.Adapter;
using LibraryCatalogueProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCatalog.Code.Interfaces
{
    public interface ILibraryItemStatus
    {
        ILibraryItem Item { get; }
        int DaysTillDue {get;}
        LibraryItemStatus ItemStatus { get; set; }
    }
}
