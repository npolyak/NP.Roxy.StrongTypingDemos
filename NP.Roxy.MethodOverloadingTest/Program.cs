using NP.Roxy.TypeConfigImpl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NP.Roxy.MethodOverloadingTest
{
    public interface IWrapper
    {
        MyDataImpl TheDataImpl { get; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // saves the generated code on compilation error
            Core.SetSaveOnErrorPath("GeneratedCode");

            // creates the TypeConfig object
            // for IMyData interface to be implemented
            // using IWrapper.TheDataImpl
            ITypeConfig<IWrapper> typeConfig = 
                Core.FindOrCreateTypeConfig<IMyData, IWrapper>();

            // completes the configuration,
            // generates the code.
            typeConfig.ConfigurationCompleted();

            // creates the object of generated class that
            // implements IMyData interface
            IMyData myData = Core.GetInstanceOfGeneratedType<IMyData>();

            // sets first and last name
            myData.FirstName = "Joe";
            myData.LastName = "Doe";

            // calls GetGreeting() method
            string greetingStr1 = myData.GetGreeting();

            // writes "Hello World1"
            Console.WriteLine(greetingStr1);

            // calls GetGreeting("Hello") method
            string greetingStr2 = myData.GetGreeting("Hello");

            // prints "Hello Joe Doe!"
            Console.WriteLine(greetingStr2);

            // saves the generated code in case of 
            // successful completion. 
            Core.Save("GeneratedCode");
        }
    }
}
