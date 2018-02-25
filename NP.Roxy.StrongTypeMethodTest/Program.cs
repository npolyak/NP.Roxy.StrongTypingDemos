using NP.Roxy.TypeConfigImpl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NP.Roxy.StrongTypeMethodTest
{
    // defines a wrapper around MyDataImpl
    // class
    public interface IWrapper
    {
        MyDataImpl TheDataImpl { get; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // saves the generated files in case of a compilation error
            Core.SetSaveOnErrorPath("GeneratedCode");

            // created the ITypeConfig for configuring the IMyData implementation
            // using IWrapper interface
            ITypeConfig<IWrapper> typeConfig = Core.FindOrCreateTypeConfig<IMyData, IWrapper>();

            // sets the GetGreetings method of IMyData
            // interface to MydataImplGet.GreetingImpl implementation
            // the two last type arguments signify the string argument that is
            // passed to the method and the string output argument. 
            typeConfig.SetReturningMethodMap<IMyData, MyDataImpl, string, string>
            (
                // specifies the interface method to implement
                (data, inputStr) => data.GetGreeting(inputStr),

                // specifies the wrapper object that used
                // to implement the interface method
                (wrapper) => wrapper.TheDataImpl,

                // specifies the method implementation
                (dataImpl, inputStr) => dataImpl.GetGreetingImpl(inputStr)
            );

            // code is generated
            typeConfig.ConfigurationCompleted();

            // we get the instance of the generated class
            // that implements IMyData interface
            IMyData myData = Core.GetInstanceOfGeneratedType<IMyData>();

            // set the first and last names
            myData.FirstName = "Joe";
            myData.LastName = "Doe";

            // get the greeting by calling IMyData.GetGreeting method of 
            // the interface, passing "Hello" string to it
            string greetingStr = myData.GetGreeting("Hello");

            // Prints the resulting string 
            // "Hello Joe Doe!"
            Console.WriteLine(greetingStr);

            // saves the generated code in case of successful 
            // completion. 
            Core.Save("GeneratedCode");
        }
    }
}
