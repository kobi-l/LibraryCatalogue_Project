using LibraryCatalogueProject;
using System;

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
