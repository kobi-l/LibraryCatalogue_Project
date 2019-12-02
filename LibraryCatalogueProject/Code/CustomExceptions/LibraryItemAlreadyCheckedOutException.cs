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

        public override string Message => $"'{LibraryItem.Title}' " +
            $"had been taken out! It should be back in {((LibraryItem.DayCheckedOut + LibraryItem.LengthOfCheckoutPeriod - DateTime.Today)).Value.Days} days.\n";
    }
}
