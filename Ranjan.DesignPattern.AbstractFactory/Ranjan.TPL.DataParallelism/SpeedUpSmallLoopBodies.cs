using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;

namespace Ranjan.TPL.DataParallelism
{
    public class SpeedUpSmallLoopBodies
    {
        public static void RunExample()
        {
            // Source must be array or IList.
            var source = Enumerable.Range(0, 100000).ToArray();

            // Partition the entire source array.
            var rangePartitioner = Partitioner.Create(0, source.Length);

            double[] results = new double[source.Length];

            // Loop over the partitions in parallel.
            Parallel.ForEach(rangePartitioner, (range, loopState) =>
            {
                // Loop over each range element without a delegate invocation.
                //THIS DELEGATE iS INVOKED ONCE PER PARTITION, the partition can be between 0 and 4666, 4666 to 8000
                for (int i = range.Item1; i < range.Item2; i++)
                {
                    results[i] = source[i] * Math.PI;
                }
            });

            Console.WriteLine("Operation complete. Print results? y/n");
            char input = Console.ReadKey().KeyChar;
            if (input == 'y' || input == 'Y')
            {
                foreach (double d in results)
                {
                    Console.Write("{0} ", d);
                }
            }
        }
    }
}
