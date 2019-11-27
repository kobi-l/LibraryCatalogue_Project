﻿using LibraryCatalogueProject;
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
        bool CheckItemAvailability(string bookTitle);


        // Method to check out a book
        ILibraryItem CheckOutAnItem(string title, string customer);

        // Method to return a book
        void ReturnAnItem(string title);

        // Method book alrady checked out
        void ItemAlreadyCheckedOut(ILibraryItem book);

        // Method to get a list of books customer has: 
        List<ILibraryItem> ItemsListByCustomer(string customerName);


        // Method to get Days till books are due:
        int DaysTillDue(ILibraryItem book);


        // Checked out books by Customer Name, and when books are due:
        void CustomerItems(string customerName);


        //New method to get due and/or overdue books by Customer Name:
        void OverdueItemsByCustomerName(string customerName);

        void NextDay();

        void SetDay(DateTime day);
    }
}