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
        public int DayCheckedOut { get; set; } = -1;
        public string WhoWasItCheckeoutTo { get; set; }

        // Constructor:
        public Book(string bookTitle, string itemType)
        {
            Title = bookTitle;
            IsCheckedOut = false;
            ItemType = itemType;
            //PageCount = bookPageCount;
            //ISBN = bookISBN;
        }

        // Methods 
        public void SetIsCheckedOut(Boolean newIsCheckedOut, int currentDayCheckedOut, string customer)
        {
            IsCheckedOut = newIsCheckedOut;
            SetDayCheckedOut(currentDayCheckedOut);
            WhoWasItCheckeoutTo = customer;
        }

        private void SetDayCheckedOut(int day) => this.DayCheckedOut = day;
    }
}
