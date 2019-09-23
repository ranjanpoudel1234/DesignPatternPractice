using System;

namespace Ranjan.TPL.DataParallelism
{
    class Program
    {
        static void Main(string[] args)
        {
            // SimpleParallelFor.RunSimpleParallelFor();
            //  ParallelForLoopWithThreadLocalVariables.RunParallelLoopWithThreadLocalVariables();
            //  ParallelForLoopWithCancellation.RunExample();
            //ParallelLoopExceptionHandling.RunExample();
            SpeedUpSmallLoopBodies.RunExample();
            Console.ReadKey();
        }
    }
}
