using LibraryCatalog.Code;
using System;
using System.Collections.Generic;

namespace LibraryCatalogueProject
{
    public class LibraryCatalogue : LibraryCatalogue_AbstractClass
    {
        // Constructor:
        public LibraryCatalogue(Dictionary<string, LibraryItem> collection) : this(collection, DefaultLengthOfCheckoutPeriod,
            DefaultInitialLateFee, DefaultFeePerLateDay)
        {
        }

        // Constructor: 
        public LibraryCatalogue(Dictionary<string, LibraryItem> collection, TimeSpan lengthOfCheckoutPeriod, 
            double initialLateFee, double feePerLateDay)
        {
            BookCollection = collection; //<-- this gets passed in to the other constructor.
            LengthOfCheckoutPeriod = lengthOfCheckoutPeriod;
            InitialLateFee = initialLateFee;
            FeePerLateDay = feePerLateDay;
        }
    }
}
