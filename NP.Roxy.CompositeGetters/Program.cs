// (c) Nick Polyak 2018 - http://awebpros.com/
// License: Apache License 2.0 (http://www.apache.org/licenses/LICENSE-2.0.html)
//
// short overview of copyright rules:
// 1. you can use this framework in any commercial or non-commercial 
//    product as long as you retain this copyright message
// 2. Do not blame the author of this software if something goes wrong. 
// 
// Also, please, mention this software in any documentation for the 
// products that use it.

using Microsoft.CodeAnalysis;
using NP.Roxy;
using NP.Roxy.TypeConfigImpl;
using NP.Utilities.Expressions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NP.Roxy.CompositeGetters
{
    class Program
    {
        static void Main(string[] args)
        {
            // ITypeConfig is an interface 
            // that can be configured to generate the code
            // for a specific type. 
            // The Template Argument IMyData specifies
            // the interface to implement.
            // SecondArgument NoInterface means
            // that there are no wrapper objects.
            ITypeConfig typeConfig =
                Core.FindOrCreateTypeConfig<IMyData, NoInterface>();

            // set up the lambda expression for IMyData.FullName Property
            // implementation
            typeConfig.SetPropGetter<IMyData, string>
            (
                // this expression specified the name
                // of the property to implement
                (data) => data.FullName,

                // this is the property implementation expression:
                // Full
                (data) => data.LastName + ", " + data.FirstName
            );

            // specify that the type configuration is completed
            typeConfig.ConfigurationCompleted();

            // Get an instance of IMyData generated implementation
            // type. 
            IMyData myData = Core.GetInstanceOfGeneratedType<IMyData>();

            // set FirstName
            myData.FirstName = "Joe";

            // set LastName
            myData.LastName = "Doe";

            // Print FullName
            Console.WriteLine(myData.FullName);

            // save the Roxy generated project under GeneratedCode folder (within the 
            // directory that contains the executable)
            Core.Save("GeneratedCode");
        }
    }
}
