using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NP.Roxy.StrongTypeMethodTest
{
    public abstract class MyDataImpl
    {
        public abstract string FirstName { get; }

        public abstract string LastName { get; }

        // used to implement GetGreetings method of
        // IMyData interface. the greetingMessage is 
        // followed by first and last names. 
        public string GetGreetingImpl(string greetingMessage)
        {
            return $"{greetingMessage} {FirstName} {LastName}!";
        }
    }
}
