using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NP.Roxy.CompositeGetters
{
    public abstract class MyDataImplementorClass
    {
        public abstract string FirstName { get; }

        public abstract string LastName { get; }

        public string FullName1
        {
            get => $"{LastName}, {FirstName}";
        }
    }
}
