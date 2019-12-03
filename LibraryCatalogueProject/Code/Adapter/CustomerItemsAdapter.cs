using LibraryCatalog.Code.Interfaces;
using LibraryCatalogueProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCatalog.Code.Adapter
{
    public class CustomerItemsAdapter : ICustomerItem
    {
        public string ItemMessage { get; }
        public ILibraryItem Item { get; }

        public CustomerItemsAdapter(ILibraryItem item, string message)
        {
            ItemMessage = message;
            Item = item;
        }
    }
}
