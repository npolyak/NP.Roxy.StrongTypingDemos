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
            ITypeConfig<SingleWrapperInterface<ProductKind>> adapterTypeConfig =
                Core.FindOrCreateSingleWrapperTypeConfig<IProduct, ProductKind>();

            adapterTypeConfig.SetWrappedPropGetter<IProduct, ProductKind, string>
            (
                prod => prod.DisplayName,
                prodKind => prodKind.GetDisplayName()
            );

            adapterTypeConfig.SetWrappedPropGetter<IProduct, ProductKind, string>
            (
                prod => prod.Description,
                prodKind => prodKind.GetDescription()
            );

            adapterTypeConfig.ConfigurationCompleted();

            IProduct product = Core.GetInstanceOfGeneratedType<IProduct>(null, ProductKind.Information);

            Console.WriteLine($"{product.DisplayName}: {product.Description}");

            Core.Save("GeneratedCode");
        }
    }
}
