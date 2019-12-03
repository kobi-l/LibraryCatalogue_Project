using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCatalogueProject
{
    public class LibraryItem_AbstractClass : ILibraryItem
    {
        // Properties: 
        public string Title { get; set; }
        public string ItemType { get; set; }

        // JUSTIN : So, the LibraryItem abstract class is meant for only those things that are common amongst all 
        // of the different potential library items.  PageCount is not required for a DVD.  In this case, it shouldn't
        // be in the abstract class.  It can be in the DVD class that inherits from the Abstract class.  
        public int PageCount { get; set; }
        public int ISBN { get; set; }
        public bool IsCheckedOut { get; set; }
        public DateTime? DayCheckedOut { get; set; } = null;
        public string WhoWasItCheckeoutTo { get; set; }
        public virtual TimeSpan LengthOfCheckoutPeriod { get; set; } = TimeSpan.FromDays(14);


        // JUSTIN : Be careful not to use specific fields in a generic class.  If I am looking at a DVD, 
        // then I don't want to try and get it's quantity by looking at BookQuantity.  That would not be 
        // very intuitive.  Keep the language the same throughout.  This is a library item.  Maybe call it
        // ItemQuantity
        public int BookQuantity { get; set; }

        // JUSTIN : I mentioned this in another class but this method actually has 2 purposes.  To Check an item
        // out and to check an item in.  If I was calling to check an item in, I may not know exactly what I need
        // to pass for currentDayCheckedOut or customer.  It would be better to make the method more specific. 
        // Make a CheckOutItem and a CheckInItem method so there is no confusion. 
        // Methods 
        public void SetIsCheckedOut(Boolean newIsCheckedOut, DateTime? currentDayCheckedOut, string customer)
        {
            IsCheckedOut = newIsCheckedOut;
            SetDayCheckedOut(currentDayCheckedOut);
            WhoWasItCheckeoutTo = customer;
            // JUSTIN :  Here is prime example why splitting this into a CheckOut and a CheckIn method should be done. 
            // Here, whether you are checking in a book or checking out a book, you are decreasing the books quantities. 
            // Really, you should decrease it for a checkout and increase it for a check in.  
            BookQuantity--;
        }

        // JUSTIN : This is a public method that just sets the DayCheckedOut = day.  This is probably 
        // unneccessary.  You can set the DayCheckoutOut from right inside the CheckOutItem method that you 
        // create.  If you want to still move the logic into a method call, then just make this one private
        // as it doesn't need to be accessed from outside the class. 
        public void SetDayCheckedOut(DateTime? day) => this.DayCheckedOut = day;
    }
}
