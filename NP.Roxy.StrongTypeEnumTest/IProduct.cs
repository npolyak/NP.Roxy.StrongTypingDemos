using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NP.Roxy.StrongTypeEnumTest
{
    public interface IProduct
    {
        string DisplayName { get; }

        string Description { get; }
    }
}
