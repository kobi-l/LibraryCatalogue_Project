﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCatalog.Code
{
    public interface ICustomer
    {
        string FirstName { get; }
        string LastName { get; }

        //string FullName { get; set; }
    }
}
