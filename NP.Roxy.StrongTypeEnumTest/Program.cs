using NP.Roxy.TypeConfigImpl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NP.Roxy.StrongTypeEnumTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // create the ITypeConfig for implementing the 
            // IProduct interface based on ProductKind enumeration
            ITypeConfig<SingleWrapperInterface<ProductKind>> adapterTypeConfig =
                Core.FindOrCreateSingleWrapperTypeConfig<IProduct, ProductKind>();

            // set IProduct.DisplayName property to be implemented 
            // as ProductKindExtensions.GetDisplayName() extension method
            // on the product kind value
            adapterTypeConfig.SetWrappedPropGetter<IProduct, ProductKind, string>
            (
                prod => prod.DisplayName,
                prodKind => prodKind.GetDisplayName()
            );

            // set IProduct.Description property to be implemented
            // by calling ProductKindExtensions.GetDescription() extension method
            // on the product kind value
            adapterTypeConfig.SetWrappedPropGetter<IProduct, ProductKind, string>
            (
                prod => prod.Description,
                prodKind => prodKind.GetDescription()
            );

            // complete configuration and generate the code
            adapterTypeConfig.ConfigurationCompleted();

            // get IProduct for ProductKind.Information enum value
            IProduct product = Core.GetInstanceOfGeneratedType<IProduct>(null, ProductKind.Information);

            // write <DisplayName>: <Description>
            Console.WriteLine($"{product.DisplayName}: {product.Description}");

            // save the Roxy generated project under GeneratedCode folder (within the 
            // directory that contains the executable)
            Core.Save("GeneratedCode");
        }
    }
}
