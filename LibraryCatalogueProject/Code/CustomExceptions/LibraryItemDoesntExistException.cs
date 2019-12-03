using LibraryCatalogueProject;
using System;

namespace LibraryCatalog.Code.CustomExceptions
{
    public class LibraryItemDoesntExistException : Exception
    {
        public LibraryItemDoesntExistException(string isbn) : base($"'{isbn}' item does not exist in our library.")
        {
        }
    }
}
