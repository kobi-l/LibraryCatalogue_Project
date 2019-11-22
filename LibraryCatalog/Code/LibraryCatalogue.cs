using LibraryCatalogueProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCatalogueProject
{
    public class LibraryCatalogue
    {
        #region PROPERTIES
        public Dictionary<string, Book> BookCollection { get; set; }
        public int CurrentDay { get; set; }
        public int LengthOfCheckoutPeriod { get; set; }
        public double InitialLateFee { get; set; }
        public double FeePerLateDay { get; set; }

        const int DefaultLengthOfCheckoutPeriod = 7;
        const double DefaultInitialLateFee = 0.50;
        const double DefaultFeePerLateDay = 1.00;
        #endregion

        #region CONSTRACTORS

        // Constructor:
        public LibraryCatalogue(Dictionary<string, Book> collection) : this(collection, DefaultLengthOfCheckoutPeriod, 
            DefaultInitialLateFee, DefaultFeePerLateDay)
        {
        }

        // Constructor: 
        public LibraryCatalogue(Dictionary<string, Book> collection, int lengthOfCheckoutPeriod, 
            double initialLateFee, double feePerLateDay)
        {
            BookCollection = collection; //<-- this gets passed in to the other constructor.
            LengthOfCheckoutPeriod = lengthOfCheckoutPeriod;
            InitialLateFee = initialLateFee;
            FeePerLateDay = feePerLateDay;
        }

        #endregion

        #region METHODS

        // Method to check book availability
        public bool CheckBookAvailability(string bookTitle) 
        { 
            if (BookCollection.TryGetValue(bookTitle, out Book book)) 
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
        
        // Method to check out a book
        public Book CheckOutBook(string title, string customer) 
        { 
            if (BookCollection.TryGetValue(title, out Book book)) 
            { 
                book.SetIsCheckedOut(true, CurrentDay, customer);
                Console.WriteLine($"You just checked out '{book.Title}' {book.ItemType.ToLower()}. \nNote: Please return it in {SetCheckoutPeriodByItemType(book)} days.\n");
                return book;

            } 
            else 
                return null; 
        }

        // Method to return a book
        public void ReturnBook(string title)
        {
            if (!BookCollection.TryGetValue(title, out Book book)) // <--- was throwing exception
            {
                Console.WriteLine("This book doesn't belong to out library.\n");
                return;
            }

            var daysLate = CurrentDay - (book.DayCheckedOut + SetCheckoutPeriodByItemType(book));
            if (daysLate > 0)
            {
                Console.WriteLine($"You owe the library ${InitialLateFee + daysLate * FeePerLateDay} because " +
                    $"'{book.Title}' is {daysLate} days overdue.");
            }
      
            Console.WriteLine("Item returned. Thank you!\n");

            book.SetIsCheckedOut(false, -1, null);
        }

        // Method book alrady checked out
        public void BookAlreadyCheckedOut(Book book)
        {
            Console.WriteLine($"Sorry, '{book.Title}' book has been already checked out! " +
                $"It should be back in {book.DayCheckedOut + DefaultLengthOfCheckoutPeriod} days.\n");
        }


        // Method to get a list of books customer has: 
        private List<Book> BooksListByCustomer(string customerName) => BookCollection.Values.Where(b => b.WhoWasItCheckeoutTo == customerName).ToList();


        // Method to get Days till books are due:
        private int DaysTillDue(Book book) => (CurrentDay - (book.DayCheckedOut + SetCheckoutPeriodByItemType(book))) * -1;


        // Checked out books by Customer Name, and when books are due:
        public void CustomerBooks(string customerName)
        {
            var customerBooks = BooksListByCustomer(customerName);

            foreach (var book in customerBooks)
            {
                Console.WriteLine(String.Join("", $"Book: {book.Title}\n", $"Due in days: {DaysTillDue(book)}\n"));
            }
        }


        //New method to get due and/or overdue books by Customer Name:
        public void OverdueBooksByCustomerName(string customerName)
        {
            var customerBooks = BooksListByCustomer(customerName);

            var overdueBooks = customerBooks.Where(b => DaysTillDue(b) <= 0);

            foreach (var book in overdueBooks)
            {
                Console.WriteLine($"Overdue item(s):\n{book.Title}\nDays late: {(DaysTillDue(book)) * -1}\n");
            }
        }

        // Set checkout period based on Item Type:
        public int SetCheckoutPeriodByItemType(Book book)
        {
            if (book.ItemType == "Magazine")
                LengthOfCheckoutPeriod = 7;
            else if (book.ItemType == "NewReleaseBook")
                LengthOfCheckoutPeriod = 5;
            else if (book.ItemType == "Book")
                LengthOfCheckoutPeriod = 14;
            else
                Console.WriteLine("Unrecognized Type");

            return LengthOfCheckoutPeriod;
        }

        public void NextDay() => CurrentDay++;

        public void SetDay(int day) => CurrentDay = day;
        #endregion
    }
}
