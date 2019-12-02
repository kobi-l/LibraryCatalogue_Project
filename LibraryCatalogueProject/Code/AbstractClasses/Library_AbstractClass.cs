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
            //{
            //    message = $"Sorry, we don't have '{itemTitle}' book.\n";
            //    return false;
            //}

            throw new LibraryItemDoesntExistException(item);

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

        //public void NextDay() => CurrentDay.AddDays(1);

        public List<string> OverdueItemsByCustomerName(string customerName)
        {
            var customerItems = ItemsListByCustomer(customerName);
            var overdueItems = customerItems.Where(b => DaysTillDue(b) <= 0);

            var items = new List<string>();

            foreach (var item in overdueItems)
            {
                items.Add($"'{item.Title}'\nDays late: {(DaysTillDue(item)) * -1}\n");
            }

            return items;
        }


        public List<string> ReturnAnItem(string itemTitle)
        {
            if (!LibraryCatalogue.TryGetValue(itemTitle, out ILibraryItem item)) // <--- was throwing exception
                //return new List<string> { ("This item doesn't belong to out library.\n") };
                throw new LibraryItemDoesntExistException(item);

            var feeIfAny = CalculateLateFee(item);
            var message = new List<string>();

            if (feeIfAny > 0) // <-- '0' int is TimeSpan.Zero when working with dates
            {
                message.Add($"You owe the library ${feeIfAny} because " +
                    $"'{item.Title}' is {GetDaysLate(item)} days overdue. " + "Item returned. Thank you!\n");
            }
            else
                message.Add("Item returned.Thank you!\n");

            item.SetIsCheckedOut(false, null, null);

            return message;
        }

        public double CalculateLateFee(ILibraryItem item) => InitialLateFee + GetDaysLate(item) * FeePerLateDay;

        private double GetDaysLate(ILibraryItem item) => (CurrentDay - (item.DayCheckedOut + item.LengthOfCheckoutPeriod)).Value.TotalDays;

        public void SetDay(DateTime day) => CurrentDay = day;
    }
}
