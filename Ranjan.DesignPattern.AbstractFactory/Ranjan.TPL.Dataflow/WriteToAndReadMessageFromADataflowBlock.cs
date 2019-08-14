using System;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace Ranjan.TPL.Dataflow
{
    public class WriteToAndReadMessageFromADataflowBlock
    {
        // Demonstrates asynchronous dataflow operations.
        static async Task AsyncSendReceive(BufferBlock<int> bufferBlock)
        {
            // Post more messages to the block asynchronously.
            for (int i = 0; i < 3; i++)
            {
                await bufferBlock.SendAsync(i);
            }

            // Asynchronously receive the messages back from the block.
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(await bufferBlock.ReceiveAsync());
            }

            /* Output:
               0
               1
               2
             */
        }

        /// <summary>
        /// The BufferBlock<T> class represents a general-purpose asynchronous messaging structure.
        /// This class stores a first in, first out (FIFO) queue of messages that can be written to by multiple sources or read from by multiple targets.
        /// When a target receives a message from a BufferBlock<T> object, that message is removed from the message queue.
        /// Therefore, although a BufferBlock<T> object can have multiple targets, only one target will receive each message.
        /// The BufferBlock<T> class is useful when you want to pass multiple messages to another component, and that component must receive each message
        /// </summary>
        public static void RunBufferBlockExample()
        {
            // Create a BufferBlock<int> object.
            var bufferBlock = new BufferBlock<int>();

            // Post several messages to the block.
            for (int i = 0; i < 3; i++)
            {
                bufferBlock.Post(i);
            }

            // Receive the messages back from the block.
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(bufferBlock.Receive());
            }

            /* Output:
               0
               1
               2
             */

            // Post more messages to the block.
            for (int i = 0; i < 3; i++)
            {
                bufferBlock.Post(i);
            }

            // Receive the messages back from the block.
            int value;
            while (bufferBlock.TryReceive(out value))
            {
                Console.WriteLine(value);
            }

            /* Output:
               0
               1
               2
             */

            // Write to and read from the message block concurrently.
            Console.WriteLine("Concurrent write start");
            var post01 = Task.Run(() =>
            {
                bufferBlock.Post(0);
                bufferBlock.Post(1);
            });
            var receive = Task.Run(() =>
            {
                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine(bufferBlock.Receive());
                }
            });
            var post2 = Task.Run(() =>
            {
                bufferBlock.Post(2);
            });
            Task.WaitAll(post2, post01, receive);
            Console.WriteLine("Concurrent write end");
            /* Sample output:
               2
               0
               1
             */

            // Demonstrate asynchronous dataflow operations.
            AsyncSendReceive(bufferBlock).Wait();
        }

        public static void RunBroadCastBlockExample()
        {
            // Create a BroadcastBlock<double> object.
            var broadcastBlock = new BroadcastBlock<double>(null);

            // Post a message to the block.
            broadcastBlock.Post(Math.PI);

            // Receive the messages back from the block several times.
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(broadcastBlock.Receive());
            }
        }

        public static void RunWriteOnceBlockExample()
        {
            // Create a WriteOnceBlock<string> object.
            var writeOnceBlock = new WriteOnceBlock<string>(null);

            // Post several messages to the block in parallel. The first 
            // message to be received is written to the block. 
            // Subsequent messages are discarded.
            Parallel.Invoke(
                () => writeOnceBlock.Post("Message 1"),
                () => writeOnceBlock.Post("Message 2"),
                () => writeOnceBlock.Post("Message 3"));

            // Receive the message from the block.
            Console.WriteLine(writeOnceBlock.Receive());
        }
    }
}
