using LibraryCatalogueProject;
using System;
using System.Collections.Generic;

namespace LibraryCatalogueProject
{
    public interface ILibrary
    {
        Dictionary<string, ILibraryItem> LibraryCatalogue { get; set; }
        DateTime CurrentDay { get; set; }
        //TimeSpan LengthOfCheckoutPeriod { get; set; }
        double InitialLateFee { get; set; }
        double FeePerLateDay { get; set; }


        // Method to check book availability
        bool CheckBookAvailability(string bookTitle);


        // Method to check out a book
        ILibraryItem CheckOutBook(string title, string customer);

        // Method to return a book
        void ReturnBook(string title);

        // Method book alrady checked out
        void BookAlreadyCheckedOut(ILibraryItem book);

        // Method to get a list of books customer has: 
        List<ILibraryItem> BooksListByCustomer(string customerName);


        // Method to get Days till books are due:
        int DaysTillDue(ILibraryItem book);


        // Checked out books by Customer Name, and when books are due:
        void CustomerBooks(string customerName);


        //New method to get due and/or overdue books by Customer Name:
        void OverdueBooksByCustomerName(string customerName);

        // Set checkout period based on Item Type:
        //TimeSpan SetCheckoutPeriodByItemType(ILibraryItem book);

        void NextDay();

        void SetDay(DateTime day);
    }
}
