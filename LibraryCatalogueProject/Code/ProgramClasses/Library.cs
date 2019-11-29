using System;
using System.Collections.Generic;

namespace LibraryCatalogueProject
{
    public class Library : Library_AbstractClass
    {
        // Constructor:
        public Library(Dictionary<string, ILibraryItem> collection) : this(collection, DefaultLengthOfCheckoutPeriod,
            DefaultInitialLateFee, DefaultFeePerLateDay)
        {
        }

        // Constructor: 
        public Library(Dictionary<string, ILibraryItem> collection, TimeSpan lengthOfCheckoutPeriod, 
            double initialLateFee, double feePerLateDay)
        {
            LibraryCatalogue = collection; //<-- this gets passed in to the other constructor.
            //LengthOfCheckoutPeriod = lengthOfCheckoutPeriod;
            InitialLateFee = initialLateFee;
            FeePerLateDay = feePerLateDay;
        }
    }
}
