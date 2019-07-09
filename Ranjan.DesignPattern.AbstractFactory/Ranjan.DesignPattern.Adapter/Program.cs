using System;
using Ranjan.DesignPattern.Adapter.ConceptExample;
using Ranjan.DesignPattern.Adapter.RealWorldExample;

namespace Ranjan.DesignPattern.Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
           RunRealWorldExample();
        }

        static void RunRealWorldExample()
        {
            var personnel = new PersonnelSystem();
            var adapter = new PhoneListAdapter(personnel);
            var intranet = new Intranet(adapter);

            intranet.ShowPhoneList();
            // Wait for user

            Console.ReadKey();
        }
    }
}
