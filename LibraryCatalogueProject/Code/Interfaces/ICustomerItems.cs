using LibraryCatalogueProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCatalog.Code.Interfaces
{
    public interface ICustomerItem
    {
        string ItemMessage { get; }
        ILibraryItem Item { get; }
    }
}
