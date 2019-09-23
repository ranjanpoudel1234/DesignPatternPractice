using System;
using System.Linq;
using System.Threading.Tasks.Dataflow;

namespace Ranjan.TPL.Dataflow
{
    /// <summary>
    /// This batching mechanism is useful when you collect data from one or more sources and then process multiple data elements as a batch.
    /// For example, consider an application that uses dataflow to insert records into a database.
    /// This operation can be more efficient if multiple items are inserted at the same time instead of one at a time sequentially.
    /// This document describes how to use the BatchBlock<T> class to improve the efficiency of such database insert operations.
    /// It also describes how to use the BatchedJoinBlock<T1,T2> class to capture both the results and any exceptions that occur when the program reads from a database.
    /// </summary>
    public class BatchAndJoinBlocks
    {
        public static void BatchBlockExample()
        {
            // Create a BatchBlock<int> object that holds ten
            // elements per batch.
            var batchBlock = new BatchBlock<int>(10);

            // Post several values to the block.
            for (int i = 0; i < 13; i++)
            {
                batchBlock.Post(i);
            }
            // Set the block to the completed state. This causes
            // the block to propagate out any any remaining
            // values as a final batch.
            batchBlock.Complete();

            // Print the sum of both batches.

            Console.WriteLine("The sum of the elements in batch 1 is {0}.",
                batchBlock.Receive().Sum());

            Console.WriteLine("The sum of the elements in batch 2 is {0}.",
                batchBlock.Receive().Sum());

            /* Output:
               The sum of the elements in batch 1 is 45.
               The sum of the elements in batch 2 is 33.
             */
        }
    }
}
