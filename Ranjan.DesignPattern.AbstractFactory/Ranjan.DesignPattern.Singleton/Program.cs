using Ranjan.DesignPattern.Singleton.ReadlWorldExample;
using System;

namespace Ranjan.DesignPattern.Singleton
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        private static void RunRealWorkdExample()
        {
            ApplicationState state = ApplicationState.GetApplicationState();
            state.LoginId = "BlackWasp";
            state.MaxSize = 1024;

            ApplicationState state2 = ApplicationState.GetApplicationState();
            Console.WriteLine(state2.LoginId);      // Outputs "BlackWasp"
            Console.WriteLine(state2.MaxSize);      // Outputs "1024"
            Console.WriteLine(state == state2);     // Outputs "True";
        }
    }
}
