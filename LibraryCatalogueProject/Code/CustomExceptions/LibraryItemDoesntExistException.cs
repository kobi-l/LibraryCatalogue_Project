using LibraryCatalogueProject;
using System;

namespace LibraryCatalog.Code.CustomExceptions
{
    // JUSTIN : In this class, you are accepting a LibraryItem but you don't do anything with it.  If you aren't
    // going to use it then don't accept it.  It is unnecessary. 
    public class LibraryItemDoesntExistException : Exception
    {
        public ILibraryItem LibraryItem { get; set; }
        public LibraryItemDoesntExistException(ILibraryItem libraryItem) : base($"This item does not exist.\n") // <-- overrides the default message!!!
        {
            LibraryItem = libraryItem;
        }
    }
}
