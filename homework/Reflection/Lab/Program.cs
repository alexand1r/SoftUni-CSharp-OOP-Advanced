using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            Spy spy = new Spy();
            //string result = spy.StealFieldInfo(typeof(Hacker).FullName, "username", "password");
            //string result = spy.AnalyzeAcessModifiers(typeof(Hacker).FullName);
            //string result = spy.RevealPrivateMethods(typeof(Hacker).FullName);
            string result = spy.CollectGettersAndSetters(typeof(Hacker).FullName);
            Console.WriteLine(result);
        }
    }
}
