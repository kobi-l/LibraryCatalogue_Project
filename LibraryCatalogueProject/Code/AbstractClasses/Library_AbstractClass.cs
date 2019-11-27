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

        public void ItemAlreadyCheckedOut(ILibraryItem item)
        {
            // number of days if would be back:
            Console.WriteLine($"Sorry, '{item.Title}' had been taken! " +
                $"It should be back in {((item.DayCheckedOut + item.LengthOfCheckoutPeriod - DateTime.Today)).Value.Days} days.\n");

            // date it would be back on:
            //Console.WriteLine($"Sorry, '{book.Title}' book had been taken! " +
            //    $"It should be back on {(book.DayCheckedOut + SetCheckoutPeriodByItemType(book)).Value.ToString("dd/MM/yyyy")} days.\n");
        }

        public List<ILibraryItem> ItemsListByCustomer(string customerName) => LibraryCatalogue.Values.Where(b => b.WhoWasItCheckeoutTo == customerName).ToList();

        public bool CheckItemAvailability(string itemTitle)
        {
            if (LibraryCatalogue.TryGetValue(itemTitle, out ILibraryItem item))
            {
                if (item.IsCheckedOut)
                {
                    //BookAlreadyCheckedOut(book);
                    throw new LibraryItemAlreadyCheckedOutException(item);
                                       
                    //return false;
                }
                Console.WriteLine($"We have '{item.Title}'!");
                return true;
            }
            else
                Console.WriteLine($"Sorry, we don't have '{itemTitle}' book.\n");

            return false;
        }

        public ILibraryItem CheckOutAnItem(string title, string customer)
        {
            if (LibraryCatalogue.TryGetValue(title, out ILibraryItem item))
            {
                item.SetIsCheckedOut(true, CurrentDay, customer);
                Console.WriteLine($"You just checked out '{item.Title}'. " +
                    $"\nNote: Please return it in {item.LengthOfCheckoutPeriod.TotalDays} days.\n");
                return item;

            }
            else
                return null;
        }

        public void CustomerItems(string customerName)
        {
            var customerItems = ItemsListByCustomer(customerName);

            foreach (var item in customerItems)
            {
                Console.WriteLine(String.Join("", $"Item: '{item.Title}'\n", $"Due in days: {DaysTillDue(item)}\n"));
            }
        }

        public int DaysTillDue(ILibraryItem item) => (CurrentDay - (item.DayCheckedOut + item.LengthOfCheckoutPeriod)).Value.Days * -1;

        public void NextDay() => CurrentDay.AddDays(1);

        public void OverdueItemsByCustomerName(string customerName)
        {
            var customerItems = ItemsListByCustomer(customerName);

            var overdueItems = customerItems.Where(b => DaysTillDue(b) <= 0);

            foreach (var item in overdueItems)
            {
                Console.WriteLine($"'{item.Title}'\nDays late: {(DaysTillDue(item)) * -1}\n");
            }
        }

        public void ReturnAnItem(string itemTitle)
        {
            if (!LibraryCatalogue.TryGetValue(itemTitle, out ILibraryItem item)) // <--- was throwing exception
            {
                Console.WriteLine("This item doesn't belong to out library.\n");
                return;
            }

            var daysLate = CurrentDay - (item.DayCheckedOut + item.LengthOfCheckoutPeriod);
            if (daysLate > TimeSpan.Zero) // <-- '0' int is TimeSpan.Zero when working with dates
            {
                Console.WriteLine($"You owe the library ${InitialLateFee + daysLate.Value.TotalDays * FeePerLateDay} because " +
                    $"'{item.Title}' is {daysLate.Value.TotalDays} days overdue.");
            }

            Console.WriteLine("Item returned. Thank you!\n");

            item.SetIsCheckedOut(false, null, null);
        }

        public void SetDay(DateTime day) => CurrentDay = day;
    }
}
