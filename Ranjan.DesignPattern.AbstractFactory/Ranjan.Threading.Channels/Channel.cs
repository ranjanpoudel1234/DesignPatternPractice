using System.Collections.Concurrent;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Ranjan.Threading.Channels
{
    public sealed class Channel<T>
    {
       // We use a ConcurrentQueue<T> to store the data, 
       //freeing us from needing to do our own locking to protect the buffering data structure,
       // as ConcurrentQueue<T> is already thread-safe for any number of producers and any number of 
       // consumers to access concurrently. And we use a SempahoreSlim 
       // to help coordinate between producers and consumers and to notify consumers that might be waiting for
       // additional data to arrive.
        private readonly ConcurrentQueue<T> _queue = new ConcurrentQueue<T>();
        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(0);

        //Our Write method gives us a method we can use to produce data into the channel, 
        //and our ReadAsync method gives us a method to consume from it.Since we decided our channel is unbounded,
        //producing data into it will always complete successfully and synchronously, just as does calling Add on a List<T>,
        //hence we’ve made it non-asynchronous and void-returning.
        public void Write(T value)
        {
            _queue.Enqueue(value); // store the data
            _semaphore.Release(); // notify any consumers that more data is available
        }

        //In contrast, our method for consuming is ReadAsync,
        //which is asynchronous because the data we want to consume may not yet be available yet, 
        //and thus we’ll need to wait for it to arrive if nothing is available to consume at the time we try. 
        //And while in our getting-started design we’re not overly concerned with performance, we also don’t want 
        //to have lots of unnecessary overheads.Since we expect to be reading frequently, 
        //and for us to often be reading when data is already available to be consumed,
        //our ReadAsync method returns a ValueTask<T> rather than a Task<T>, so that 
        //we can make it allocation-free when it completes synchronously.
        public async ValueTask<T> ReadAsync(CancellationToken cancellationToken)
        {
            await _semaphore.WaitAsync(cancellationToken).ConfigureAwait(false); // wait
            bool gotOne = _queue.TryDequeue(out T item); // retrieve the data
            Debug.Assert(gotOne);
            return item;
        }
    }
}
