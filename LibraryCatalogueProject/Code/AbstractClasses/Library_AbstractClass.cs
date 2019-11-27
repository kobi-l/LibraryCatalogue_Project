using System;
using System.Collections.Generic;
using System.Linq;
using LibraryCatalog.Code.CustomExceptions;
using LibraryCatalogueProject;

namespace LibraryCatalogueProject
{
    public class Library_AbstractClass : ILibrary
    {
        public Dictionary<string, ILibraryItem> LibraryCatalogue { get; set; }
        public DateTime CurrentDay { get; set; } = DateTime.Today;
        public double InitialLateFee { get; set; }
        public double FeePerLateDay { get; set; }

        protected static TimeSpan DefaultLengthOfCheckoutPeriod = TimeSpan.FromDays(7);
        public const double DefaultInitialLateFee = 0.50;
        public const double DefaultFeePerLateDay = 1.00;

        public void ItemAlreadyCheckedOut(ILibraryItem book)
        {
            // number of days if would be back:
            Console.WriteLine($"Sorry, '{book.Title}' book had been taken! " +
                $"It should be back in {((book.DayCheckedOut + book.LengthOfCheckoutPeriod - DateTime.Today)).Value.Days} days.\n");

            // date it would be back on:
            //Console.WriteLine($"Sorry, '{book.Title}' book had been taken! " +
            //    $"It should be back on {(book.DayCheckedOut + SetCheckoutPeriodByItemType(book)).Value.ToString("dd/MM/yyyy")} days.\n");
        }

        public List<ILibraryItem> ItemsListByCustomer(string customerName) => LibraryCatalogue.Values.Where(b => b.WhoWasItCheckeoutTo == customerName).ToList();

        public bool CheckItemAvailability(string bookTitle)
        {
            if (LibraryCatalogue.TryGetValue(bookTitle, out ILibraryItem book))
            {
                if (book.IsCheckedOut)
                {
                    //BookAlreadyCheckedOut(book);
                    throw new LibraryItemAlreadyCheckedOutException(book);
                                       
                    //return false;
                }
                Console.WriteLine($"We have '{book.Title}'!");
                return true;
            }
            else
                Console.WriteLine($"Sorry, we don't have '{bookTitle}' book.\n");

            return false;
        }

        public ILibraryItem CheckOutAnItem(string title, string customer)
        {
            if (LibraryCatalogue.TryGetValue(title, out ILibraryItem book))
            {
                book.SetIsCheckedOut(true, CurrentDay, customer);
                Console.WriteLine($"You just checked out '{book.Title}'. " +
                    $"\nNote: Please return it in {book.LengthOfCheckoutPeriod.TotalDays} days.\n");
                return book;

            }
            else
                return null;
        }

        public void CustomerItems(string customerName)
        {
            var customerBooks = ItemsListByCustomer(customerName);

            foreach (var book in customerBooks)
            {
                Console.WriteLine(String.Join("", $"Book: {book.Title}\n", $"Due in days: {DaysTillDue(book)}\n"));
            }
        }

        public int DaysTillDue(ILibraryItem book) => (CurrentDay - (book.DayCheckedOut + book.LengthOfCheckoutPeriod)).Value.Days * -1;

        public void NextDay() => CurrentDay.AddDays(1);

        public void OverdueItemsByCustomerName(string customerName)
        {
            var customerBooks = ItemsListByCustomer(customerName);

            var overdueBooks = customerBooks.Where(b => DaysTillDue(b) <= 0);

            foreach (var book in overdueBooks)
            {
                Console.WriteLine($"'{book.Title}'\nDays late: {(DaysTillDue(book)) * -1}\n");
            }
        }

        public void ReturnAnItem(string title)
        {
            if (!LibraryCatalogue.TryGetValue(title, out ILibraryItem book)) // <--- was throwing exception
            {
                Console.WriteLine("This book doesn't belong to out library.\n");
                return;
            }

            var daysLate = CurrentDay - (book.DayCheckedOut + book.LengthOfCheckoutPeriod);
            if (daysLate > TimeSpan.Zero) // <-- '0' int is TimeSpan.Zero when working with dates
            {
                Console.WriteLine($"You owe the library ${InitialLateFee + daysLate.Value.TotalDays * FeePerLateDay} because " +
                    $"'{book.Title}' is {daysLate.Value.TotalDays} days overdue.");
            }

            Console.WriteLine("Item returned. Thank you!\n");

            book.SetIsCheckedOut(false, null, null);
        }

        public void SetDay(DateTime day) => CurrentDay = day;
    }
}
