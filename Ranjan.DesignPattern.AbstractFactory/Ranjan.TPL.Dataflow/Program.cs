using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks.Dataflow;

namespace Ranjan.TPL.Dataflow
{
    // Demonstrates how to create a basic dataflow pipeline.
    // This program downloads the book "The Iliad of Homer" by Homer from the Web 
    // and finds all reversed words that appear in that book.
    static class Program
    {
        static void Main(string[] args)
        {
           // MainDataFlowConsoleExample.RunConsoleExample();
            //DataFlowExceptionHandling.ShowFirstStyleofHandlingException();
           // DataFlowExceptionHandling.RunCompletionTaskForHandlingException();
           // WriteToAndReadMessageFromADataflowBlock.RunBufferBlockExample();
           // WriteToAndReadMessageFromADataflowBlock.RunBroadCastBlockExample();
          //  WriteToAndReadMessageFromADataflowBlock.RunWriteOnceBlockExample();
            //  DegreeOfParallelism.DegreeOfParallelismExample();
            JoinBlockToReadDataFromMultipleSources.RunExample();


            Console.ReadKey();
        }
    }
}
