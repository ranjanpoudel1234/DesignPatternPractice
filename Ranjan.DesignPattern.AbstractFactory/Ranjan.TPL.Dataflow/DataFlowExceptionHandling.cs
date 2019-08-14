using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks.Dataflow;

namespace Ranjan.TPL.Dataflow
{
    public class DataFlowExceptionHandling
    {
        // We recommend that you handle exceptions in the bodies of such blocks.However,
        // if you are unable to do so, the block behaves as though it was canceled and does not process incoming messages.
        public static void ShowFirstStyleofHandlingException()
        {
            // Create an ActionBlock<int> object that prints its input
            // and throws ArgumentOutOfRangeException if the input
            // is less than zero.
            var throwIfNegative = new ActionBlock<int>(n =>
            {
                Console.WriteLine("n = {0}", n);
                if (n < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
            });

            // Post values to the block.
            throwIfNegative.Post(0);
            throwIfNegative.Post(-1);
            throwIfNegative.Post(1);
            throwIfNegative.Post(-2);
            throwIfNegative.Complete();

            // Wait for completion in a try/catch block.
            try
            {
                throwIfNegative.Completion.Wait();
            }
            catch (AggregateException ae)
            {
                // If an unhandled exception occurs during dataflow processing, all
                // exceptions are propagated through an AggregateException object.
                ae.Handle(e =>
                {
                    Console.WriteLine("Encountered {0}: {1}",
                        e.GetType().Name, e.Message);
                    return true;
                });
            }

            /* Output:
            n = 0
            n = -1
            Encountered ArgumentOutOfRangeException: Specified argument was out of the range
             of valid values.
            */
        }

        public static void RunCompletionTaskForHandlingException()
        {
            // Create an ActionBlock<int> object that prints its input
            // and throws ArgumentOutOfRangeException if the input
            // is less than zero.
            var throwIfNegative = new ActionBlock<int>(n =>
            {
                Console.WriteLine("n = {0}", n);
                if (n < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
            });

            throwIfNegative.Completion.ContinueWith(task =>
            {
                Console.WriteLine("The status of the completion task is '{0}'.",
                    task.Status);
            });

            // Post values to the block.
            throwIfNegative.Post(0);
            throwIfNegative.Post(-1);
            throwIfNegative.Post(1);
            throwIfNegative.Post(-2);
            throwIfNegative.Complete();

            // Wait for completion in a try/catch block.
            try
            {
                throwIfNegative.Completion.Wait();
            }
            catch (AggregateException ae)
            {
                // If an unhandled exception occurs during dataflow processing, all
                // exceptions are propagated through an AggregateException object.
                ae.Handle(e =>
                {
                    Console.WriteLine("Encountered {0}: {1}",
                        e.GetType().Name, e.Message);
                    return true;
                });
            }

            /* Output:
            n = 0
            n = -1
            Encountered ArgumentOutOfRangeException: Specified argument was out of the range
             of valid values.
            */
        }
    }
}
