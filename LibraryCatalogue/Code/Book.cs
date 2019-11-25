using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCatalogueProject
{
    public class Book
    {
        // Properties: 
        public string Title { get; set; }
        public string ItemType { get; set; }
        public int PageCount { get; set; }
        public int ISBN { get; set; }
        public bool IsCheckedOut { get; set; }
        public DateTime? DayCheckedOut { get; set; } = null;
        public string WhoWasItCheckeoutTo { get; set; }
        public int BookQuantity { get; set; }


        // Constructor:
        public Book(string bookTitle, string itemType, int bookQuantity)
        {
            Title = bookTitle;
            IsCheckedOut = false;
            ItemType = itemType;
            BookQuantity = bookQuantity;
            //PageCount = bookPageCount;
            //ISBN = bookISBN;
        }

        // Methods 
        public void SetIsCheckedOut(Boolean newIsCheckedOut, DateTime? currentDayCheckedOut, string customer)
        {
            IsCheckedOut = newIsCheckedOut;
            SetDayCheckedOut(currentDayCheckedOut);
            WhoWasItCheckeoutTo = customer;
            BookQuantity--;
        }

        private void SetDayCheckedOut(DateTime? day) => this.DayCheckedOut = day;
    }
}
