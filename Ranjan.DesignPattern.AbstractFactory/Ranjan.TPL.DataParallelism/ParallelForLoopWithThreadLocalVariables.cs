﻿using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Ranjan.TPL.DataParallelism
{
    public class ParallelForLoopWithThreadLocalVariables
    {
        public static void RunParallelLoopWithThreadLocalVariables()
        {
            int[] nums = Enumerable.Range(0, 1000000).ToArray();
            long total = 0;

            // Use type parameter to make subtotal a long, not an int
            Parallel.For<long>(0, nums.Length, () => 0, (j, loop, subtotal) =>
                {
                    subtotal += nums[j];
                    return subtotal;
                },
                (x) => Interlocked.Add(ref total, x)
            );

            Console.WriteLine("The total is {0:N0}", total);
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
        
    }
}
