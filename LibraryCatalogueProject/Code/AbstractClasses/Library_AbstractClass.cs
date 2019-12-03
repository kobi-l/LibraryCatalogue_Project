using System;
using System.Collections.Generic;
using System.Linq;
using LibraryCatalog.Code.Adapter;
using LibraryCatalog.Code.CustomExceptions;
using LibraryCatalog.Code.Interfaces;
using LibraryCatalogueProject;

namespace LibraryCatalogueProject
{
    public class Library_AbstractClass : ILibrary
    {
        public Dictionary<string, ILibraryItem> LibraryCatalogue { get; set; }

        public double InitialLateFee { get; set; }
        public double FeePerLateDay { get; set; }

        protected static TimeSpan DefaultLengthOfCheckoutPeriod = TimeSpan.FromDays(7);
        public const double DefaultInitialLateFee = 0.50;
        public const double DefaultFeePerLateDay = 1.00;

        public List<ILibraryItem> ItemsListByCustomer(string customerName) => LibraryCatalogue.Values.Where(b => b.WhoWasItCheckeoutTo == customerName).ToList();
        
        public bool CheckItemAvailability(string isbn)
        {
            var item = IsItemExistsAtTheLibrary(isbn);

            if (item.IsCheckedOut)
                throw new LibraryItemAlreadyCheckedOutException(item);

            return true;
        }


        public ILibraryItem CheckOutAnItem(string isbn, string customer, DateTime date)
        {
            var item = IsItemExistsAtTheLibrary(isbn);

            item.CheckOutItem(date, customer);

            return item;
        }

        public List<ICustomerItem> CustomerItems(string customerName)
        {
            var customerItems = ItemsListByCustomer(customerName);
            var date = DateTime.Today;

            var itemList = new List<ICustomerItem>();

            foreach (var item in customerItems)
            {
                itemList.Add(new CustomerItemsAdapter(item, $"Item: '{item.Title}'\n" + $"Due in days: {DaysTillDue(item, date)}"));
            }

            return itemList;
        }

        public int DaysTillDue(ILibraryItem item, DateTime date)
        {
            if (item.IsCheckedOut == false)
                return 0;

            return (date - (item.DayCheckedOut + item.LengthOfCheckoutPeriod)).Value.Days * -1;
        }

        public List<ICustomerItem> OverdueItemsByCustomerName(string customerName, DateTime currentDate)
        {
            var customerItems = ItemsListByCustomer(customerName);
            var overdueItems = customerItems.Where(b => DaysTillDue(b, currentDate) <= 0);

            var itemsList = new List<ICustomerItem>();

            foreach (var item in overdueItems)
                itemsList.Add(new CustomerItemsAdapter(item, $"'{item.Title}'\nDays late: {(DaysTillDue(item, currentDate)) * -1}\n"));

            return itemsList;
        }

        public string ReturnAnItem(string isbn, DateTime date)
        {
            var item = IsItemExistsAtTheLibrary(isbn);

            var feeIfAny = CalculateLateFee(item, date);
            var message = String.Empty;

            if (feeIfAny > 0) // <-- '0' int is TimeSpan.Zero when working with dates
            {
                message = ($"You owe the library ${feeIfAny} because " +
                    $"'{item.Title}' is {GetDaysLate(item, date)} days overdue. " + "Item returned. Thank you!");
            }
            else
                message = ("Item returned.Thank you!");

            item.CheckInItem();

            return message;
        }

        private ILibraryItem IsItemExistsAtTheLibrary(string itemTitle)
        {
            if (!LibraryCatalogue.TryGetValue(itemTitle, out ILibraryItem item))
                throw new LibraryItemDoesntExistException(itemTitle);

            return item;
        }

        public double CalculateLateFee(ILibraryItem item, DateTime date) => InitialLateFee + GetDaysLate(item, date) * FeePerLateDay;
        private double GetDaysLate(ILibraryItem item, DateTime currectDate) => (currectDate - (item.DayCheckedOut + item.LengthOfCheckoutPeriod)).Value.TotalDays;
    }
}
