﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NP.Roxy.CompositeGetters
{
    public interface IMyData
    {
        string LastName { get; set; }

        string FirstName { get; set; }

        int Age { get; set; }

        string FullName { get; }
    }
}
