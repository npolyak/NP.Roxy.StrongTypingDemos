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
            Core.SetSaveOnErrorPath("GeneratedCode");

            ITypeConfig<IWrapper> typeConfig = Core.FindOrCreateTypeConfig<IMyData, IWrapper>();

            typeConfig.ConfigurationCompleted();

            IMyData myData = Core.GetInstanceOfGeneratedType<IMyData>();

            myData.FirstName = "Joe";
            myData.LastName = "Doe";

            string greetingStr1 = myData.GetGreeting();
            Console.WriteLine(greetingStr1);

            string greetingStr2 = myData.GetGreeting("Hello");

            Console.WriteLine(greetingStr2);

            Core.Save("GeneratedCode");
        }
    }
}
