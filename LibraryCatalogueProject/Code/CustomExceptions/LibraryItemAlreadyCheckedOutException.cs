using LibraryCatalogueProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCatalog.Code.CustomExceptions
{
    public class LibraryItemAlreadyCheckedOutException : Exception
    {
        public LibraryItemAlreadyCheckedOutException(ILibraryItem libraryItem)
        {
            LibraryItem = libraryItem;

        }
        public ILibraryItem LibraryItem { get; set; }

        public override string Message => base.Message;
    }
}
