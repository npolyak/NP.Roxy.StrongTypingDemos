using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NP.Roxy.StrongTypeEnumTest
{
    public enum ProductKind
    {
        Grocery,
        FinancialInstrument,
        Information
    }

    public static class ProductKindExtensions
    {
        // returns a displayable short name for the ProductKind
        public static string GetDisplayName(this ProductKind productKind)
        {
            switch (productKind)
            {
                case ProductKind.Grocery:
                    return "Grocery";
                case ProductKind.FinancialInstrument:
                    return "Financial Instrument";
                case ProductKind.Information:
                    return "Information";
            }

            return null;
        }

        // returns the full description of the ProductKind
        // note that the method is private
        public static string GetDescription(this ProductKind productKind)
        {
            switch (productKind)
            {
                case ProductKind.Grocery:
                    return "Products you can buy in a grocery store";
                case ProductKind.FinancialInstrument:
                    return "Products you can buy on a stock exchange";
                case ProductKind.Information:
                    return "Products you can get on the Internet";
            }

            return null;
        }
    }
}
