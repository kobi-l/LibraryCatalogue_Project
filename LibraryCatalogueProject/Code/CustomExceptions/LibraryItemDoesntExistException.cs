using LibraryCatalogueProject;
using System;

namespace LibraryCatalog.Code.CustomExceptions
{
    public class LibraryItemDoesntExistException : Exception
    {
        public ILibraryItem LibraryItem { get; set; }
        public LibraryItemDoesntExistException(ILibraryItem libraryItem) : base($"This item does not exist.\n") // <-- overrides the default message!!!
        {
            LibraryItem = libraryItem;
        }
    }
}
