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


        // JUSTIN: Is there a need to record current day? What does it give you.  Every method that 
        // calculates things like is the book late, should accept a date and use that date to do it's
        // calculations. 
        public DateTime CurrentDay { get; set; } = DateTime.Today;
        public double InitialLateFee { get; set; }
        public double FeePerLateDay { get; set; }

        protected static TimeSpan DefaultLengthOfCheckoutPeriod = TimeSpan.FromDays(7);
        public const double DefaultInitialLateFee = 0.50;
        public const double DefaultFeePerLateDay = 1.00;

        public List<ILibraryItem> ItemsListByCustomer(string customerName) => LibraryCatalogue.Values.Where(b => b.WhoWasItCheckeoutTo == customerName).ToList();

        // JUSTIN : If you are going to throw an exception, you should remove the out string message parameter as it is no longer
        // needed or used.  Don't leave unused things around to clutter up your code.  
        public bool CheckItemAvailability(string itemTitle, out string message)
        {
            message = string.Empty;

            if (!LibraryCatalogue.TryGetValue(itemTitle, out ILibraryItem item))

            // JUSTIN : I know why you are commenting out code and leaving it... and for these exercises it is fine.
            // but when you are programming for real, don't leave commented code around.  It clutters up the screen.

            //{
            //    message = $"Sorry, we don't have '{itemTitle}' book.\n";
            //    return false;
            //}


            // JUSTIN : Does this work?  You are trying to pass an item to the custom exception, but the 
            // reason you are throwing the exception is because the item can't be found.  So basically
            // you are passing a null object to the exception but not using it inside the exception. 
            // I would instead just pass the itemTitle and use that in your message.  Then you can 
            // say what item doesn't exist. 
            throw new LibraryItemDoesntExistException(item);

            if (item.IsCheckedOut)
                throw new LibraryItemAlreadyCheckedOutException(item);

            return true;
        }


        public ILibraryItem CheckOutAnItem(string title, string customer)
        {
            // JUSTIN : So, this is the second time that you are trying to get an item from the collection. 
            // in this case, you are just returning a null which I don't think is very meaningful.  It is not
            // intuitive on the client side what they should be doing with it.  Plus, now they have to handle
            // dealing with a potentially null object which can lend itself to null exceptions. 
            // What I would do is create a method that takes a title and returns a library item.  If you can't 
            // find the library item throw the LibraryItemDoesntExistException.  Have this method and the "CheckItemAvailabilty"
            // method call the same code.  Then it will be consistent. 
            if (!LibraryCatalogue.TryGetValue(title, out ILibraryItem item))
                return null;

        
            // JUSTIN : As I mentioned earlier, you are using the "CurrentDay" as a parameter to check out the book. This makes
            // it dependent on the client knowing that they have to be incrementing days.  This is not very intuitive. 
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

        // JUSTIN : Although this works, what would happen if this method is called but the item isn't checked out?  I would guess you 
        // would get some strange results or an exception being thrown.  Perhaps this method needs to be modified to make it a bit more
        // robust.
        // 1. Allow a date to be passed in instead of using CurrentDay
        // 2. Have a check to make sure the item is actually checked out first before you do your calculations. 

        public int DaysTillDue(ILibraryItem item) => (CurrentDay - (item.DayCheckedOut + item.LengthOfCheckoutPeriod)).Value.Days * -1;

        //public void NextDay() => CurrentDay.AddDays(1);



        // JUSTIN : If you are wanting to use the overdue list to check in books, you should be
        // passing back to the client the LibraryItems, not just a string.  You can do this in a couple of 
        // ways.  Pass back a dictionary that you create and populate inside this method, or you can create a 
        // new class that has a LibraryItem and a message, and you can pass back a list of that class. 

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


        // JUSTIN : You actually aren't using the item's title, you are really using the ISBN.  
        // The name of the parameter isn't correct and would be misleading. 
        public List<string> ReturnAnItem(string itemTitle)
        {
            // JUSTIN : Here is a third time that you are trying to get a value out of collection and if it fails
            // then throw the exception.  refactor into a method instead. 
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

            // JUSTIN : I can see why you would want to use the same method call to check an item 
            // back into the library, but if I was calling it, I am not sure what I would have to 
            // set.  Should it be null?  Should it be something else (string.empty). 
            // A cleaner way of programming would have a method on the ILibraryItem for "CheckOutItem" and "CheckInItem"
            // Then you can better control what you need.  For CheckOutItem you need a date it is checked out and who checked it out
            // For CheckIn, you don't need any parameters.  
            item.SetIsCheckedOut(false, null, null);

            return message;
        }


        

        public double CalculateLateFee(ILibraryItem item) => InitialLateFee + GetDaysLate(item) * FeePerLateDay;


        // JUSTIN : Again, lets remove this idea of CurrentDay and have the method accept a date instead. 
        private double GetDaysLate(ILibraryItem item) => (CurrentDay - (item.DayCheckedOut + item.LengthOfCheckoutPeriod)).Value.TotalDays;

        // JUSTIN : If we remove CurrentDay then we don't need this method. 
        public void SetDay(DateTime day) => CurrentDay = day;
    }
}
