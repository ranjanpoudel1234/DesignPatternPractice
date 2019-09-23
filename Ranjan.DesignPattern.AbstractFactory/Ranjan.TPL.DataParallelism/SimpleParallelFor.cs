using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ranjan.TPL.DataParallelism
{
    public class SimpleParallelFor
    {
        public static void RunSimpleParallelFor()
        {
            long totalSize = 0;
            var path = "C:/windows";

            if (!Directory.Exists(path))
            {
                Console.WriteLine("The directory does not exist.");
                return;
            }

            Console.Error.WriteLine("Executing Parallel loop...");
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            //each file size is then added to the totalSize variable.
            //Note that the addition is performed by calling the Interlocked.
            //Add so that the addition is performed as an atomic operation.
            //Otherwise, multiple tasks could try to update the totalSize variable simultaneously.
            String[] files = Directory.GetFiles(path);
            Parallel.For(0, files.Length,
                index => {
                    FileInfo fi = new FileInfo(files[index]);
                    long size = fi.Length;
                    Interlocked.Add(ref totalSize, size);
                });

            stopwatch.Stop();
            Console.WriteLine("Directory '{0}':", path);
            Console.WriteLine("{0:N0} files, {1:N0} bytes", files.Length, totalSize);
            Console.WriteLine("Total Time '{0}':", stopwatch.ElapsedMilliseconds);


            //SEQUENTIAL

            Console.Error.WriteLine("Executing Sequential loop...");
            Stopwatch stopwatch1 = new Stopwatch();
            stopwatch1.Start();

            for (int i = 0; i < files.Length; i++) 
            {
                FileInfo fi = new FileInfo(files[i]);
                long size = fi.Length;
                Interlocked.Add(ref totalSize, size);
            }

            stopwatch1.Stop();

            Console.WriteLine("Directory '{0}':", path);
            Console.WriteLine("{0:N0} files, {1:N0} bytes", files.Length, totalSize);
            Console.WriteLine("Total Time '{0}':", stopwatch1.ElapsedMilliseconds);
        }
    }
}
