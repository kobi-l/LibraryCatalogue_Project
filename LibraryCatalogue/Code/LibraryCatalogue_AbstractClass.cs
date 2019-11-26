using System;
using System.Collections.Generic;
using System.Linq;
using LibraryCatalogueProject;

namespace LibraryCatalog.Code
{
    public class LibraryCatalogue_AbstractClass : ILibraryCatalogue
    {
        public Dictionary<string, LibraryItem> BookCollection { get; set; }
        public DateTime CurrentDay { get; set; } = DateTime.Today;
        public TimeSpan LengthOfCheckoutPeriod { get; set; }
        public double InitialLateFee { get; set; }
        public double FeePerLateDay { get; set; }

        protected static TimeSpan DefaultLengthOfCheckoutPeriod = TimeSpan.FromDays(7);
        public const double DefaultInitialLateFee = 0.50;
        public const double DefaultFeePerLateDay = 1.00;

        public void BookAlreadyCheckedOut(LibraryItem book)
        {
            // number of days if would be back:
            Console.WriteLine($"Sorry, '{book.Title}' book had been taken! " +
                $"It should be back in {((book.DayCheckedOut + SetCheckoutPeriodByItemType(book) - DateTime.Today)).Value.Days} days.\n");

            // date it would be back on:
            //Console.WriteLine($"Sorry, '{book.Title}' book had been taken! " +
            //    $"It should be back on {(book.DayCheckedOut + SetCheckoutPeriodByItemType(book)).Value.ToString("dd/MM/yyyy")} days.\n");
        }

        public List<LibraryItem> BooksListByCustomer(string customerName) => BookCollection.Values.Where(b => b.WhoWasItCheckeoutTo == customerName).ToList();

        public bool CheckBookAvailability(string bookTitle)
        {
            if (BookCollection.TryGetValue(bookTitle, out LibraryItem book))
            {
                if (book.IsCheckedOut)
                {
                    BookAlreadyCheckedOut(book);
                    return false;
                }
                Console.WriteLine($"We have '{book.Title}'!");
                return true;
            }
            else
                Console.WriteLine($"Sorry, we don't have '{bookTitle}' book.\n");

            return false;
        }

        public LibraryItem CheckOutBook(string title, string customer)
        {
            if (BookCollection.TryGetValue(title, out LibraryItem book))
            {
                book.SetIsCheckedOut(true, CurrentDay, customer);
                Console.WriteLine($"You just checked out '{book.Title}' {book.ItemType.ToLower()}. " +
                    $"\nNote: Please return it in {SetCheckoutPeriodByItemType(book).TotalDays} days.\n");
                return book;

            }
            else
                return null;
        }

        public void CustomerBooks(string customerName)
        {
            var customerBooks = BooksListByCustomer(customerName);

            foreach (var book in customerBooks)
            {
                Console.WriteLine(String.Join("", $"Book: {book.Title}\n", $"Due in days: {DaysTillDue(book)}\n"));
            }
        }

        public int DaysTillDue(LibraryItem book) => (CurrentDay - (book.DayCheckedOut + SetCheckoutPeriodByItemType(book))).Value.Days * -1;

        public void NextDay() => CurrentDay.AddDays(1);

        public void OverdueBooksByCustomerName(string customerName)
        {
            var customerBooks = BooksListByCustomer(customerName);

            var overdueBooks = customerBooks.Where(b => DaysTillDue(b) <= 0);

            foreach (var book in overdueBooks)
            {
                Console.WriteLine($"Overdue item(s):\n{book.ItemType}: '{book.Title}'\nDays late: {(DaysTillDue(book)) * -1}\n");
            }
        }

        public void ReturnBook(string title)
        {
            if (!BookCollection.TryGetValue(title, out LibraryItem book)) // <--- was throwing exception
            {
                Console.WriteLine("This book doesn't belong to out library.\n");
                return;
            }

            var daysLate = CurrentDay - (book.DayCheckedOut + SetCheckoutPeriodByItemType(book));
            if (daysLate > TimeSpan.Zero) // <-- '0' int is TimeSpan.Zero when working with dates
            {
                Console.WriteLine($"You owe the library ${InitialLateFee + daysLate.Value.TotalDays * FeePerLateDay} because " +
                    $"'{book.Title}' is {daysLate.Value.TotalDays} days overdue.");
            }

            Console.WriteLine("Item returned. Thank you!\n");

            book.SetIsCheckedOut(false, null, null);
        }

        public TimeSpan SetCheckoutPeriodByItemType(LibraryItem book)
        {
            if (book.ItemType == "Magazine")
                LengthOfCheckoutPeriod = TimeSpan.FromDays(7);
            else if (book.ItemType == "NewReleaseBook")
                LengthOfCheckoutPeriod = TimeSpan.FromDays(5);
            else if (book.ItemType == "Book")
                LengthOfCheckoutPeriod = TimeSpan.FromDays(14);
            else
                Console.WriteLine("Unrecognized Type");

            return LengthOfCheckoutPeriod;
        }

        public void SetDay(DateTime day) => CurrentDay = day;
    }
}
