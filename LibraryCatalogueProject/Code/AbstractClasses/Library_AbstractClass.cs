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

        public List<ILibraryItem> ItemsListByCustomer(string customerName) => LibraryCatalogue.Values.Where(b => b.WhoWasItCheckeoutTo == customerName).ToList();

        public bool CheckItemAvailability(string itemTitle, out string message)
        {
            message = string.Empty;

            if (!LibraryCatalogue.TryGetValue(itemTitle, out ILibraryItem item))
            {
                message = $"Sorry, we don't have '{itemTitle}' book.\n";
                return false;
            }

            if (item.IsCheckedOut)
                throw new LibraryItemAlreadyCheckedOutException(item);

            return true;
        }

        public ILibraryItem CheckOutAnItem(string title, string customer)
        {
            if (!LibraryCatalogue.TryGetValue(title, out ILibraryItem item))
                return null;

            item.SetIsCheckedOut(true, CurrentDay, customer);

            return item;
        }

        public List<string> CustomerItems(string customerName)
        {
            var customerItems = ItemsListByCustomer(customerName);
            var items = new List<string>();

            foreach (var item in customerItems)
            {
                items.Add($"Item: '{item.Title}'\n" + $"Due in days: {DaysTillDue(item)}\n");

            }

            return items;
        }

        public int DaysTillDue(ILibraryItem item) => (CurrentDay - (item.DayCheckedOut + item.LengthOfCheckoutPeriod)).Value.Days * -1;

        public void NextDay() => CurrentDay.AddDays(1);

        public string OverdueItemsByCustomerName(string customerName)
        {
            var customerItems = ItemsListByCustomer(customerName);

            var overdueItems = customerItems.Where(b => DaysTillDue(b) <= 0);

            var items = string.Empty;

            foreach (var item in overdueItems)
            {
                items += $"'{item.Title}'\nDays late: {(DaysTillDue(item)) * -1}\n";
            }

            return items;
        }

        public string ReturnAnItem(string itemTitle)
        {
            if (!LibraryCatalogue.TryGetValue(itemTitle, out ILibraryItem item)) // <--- was throwing exception
                return "This item doesn't belong to out library.\n";


            var daysLate = CurrentDay - (item.DayCheckedOut + item.LengthOfCheckoutPeriod);
            var message = string.Empty;
            if (daysLate > TimeSpan.Zero) // <-- '0' int is TimeSpan.Zero when working with dates
            {
                message = $"You owe the library ${InitialLateFee + daysLate.Value.TotalDays * FeePerLateDay} because " +
                    $"'{item.Title}' is {daysLate.Value.TotalDays} days overdue. ";
            }

            item.SetIsCheckedOut(false, null, null);
            return message + "Item returned. Thank you!\n";
        }

        public void SetDay(DateTime day) => CurrentDay = day;
    }
}
