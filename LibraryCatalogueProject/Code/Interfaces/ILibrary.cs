using LibraryCatalog.Code.Interfaces;
using LibraryCatalogueProject;
using System;
using System.Collections.Generic;

namespace LibraryCatalogueProject
{
    public interface ILibrary
    {
        Dictionary<string, ILibraryItem> LibraryCatalogue { get; set; }
        double InitialLateFee { get; set; }
        double FeePerLateDay { get; set; }

        // Method to check book availability
        bool CheckItemAvailability(string bookTitle);


        // Method to check out a book
        ILibraryItem CheckOutAnItem(string title, string customer, DateTime date);

        // Method to return a book
        string ReturnAnItem(string title, DateTime date);

        // Method to get a list of books customer has: 
        List<ILibraryItem> ItemsListByCustomer(string customerName);

        // Method to get Days till items are due:
        int DaysTillDue(ILibraryItem item, DateTime date);

        // Checked out books by Customer Name, and when books are due:
        List<ICustomerItem> CustomerItems(string customerName);

        //New method to get due and/or overdue books by Customer Name:
        List<ICustomerItem> OverdueItemsByCustomerName(string customerName, DateTime date);
    }
}
