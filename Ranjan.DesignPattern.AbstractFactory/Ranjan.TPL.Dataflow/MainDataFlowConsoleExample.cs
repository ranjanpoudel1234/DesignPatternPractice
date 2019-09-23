using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks.Dataflow;

namespace Ranjan.TPL.Dataflow
{
    //Every ActionBlock<TInput>, TransformBlock<TInput, TOutput>, and TransformManyBlock<TInput, TOutput> object 
    //buffers input messages until the block is ready to process them. 
    //By default, these classes process messages in the order in which they are received, one message at a time.
    //You can also specify the degree of parallelism

    //By default, each predefined dataflow block propagates out messages in the order in which the messages are received.
    //Although multiple messages are processed simultaneously when you specify a maximum degree of parallelism that is greater than 1, 
    //they are still propagated out in the order in which they are received.

    //Because the MaxDegreeOfParallelism property represents the maximum degree of parallelism, 
    //the dataflow block might execute with a lesser degree of parallelism than you specify. 
    //The dataflow block can use a lesser degree of parallelism to meet its functional requirements or to account for a lack of available system resources. 
    //A dataflow block never chooses a greater degree of parallelism than you specify.
    public class MainDataFlowConsoleExample
    {
        public static void RunConsoleExample()
        {
            //
            // Create the members of the pipeline.
            // 

            // Downloads the requested resource as a string.
            var downloadString = new TransformBlock<string, string>(async uri =>
            {
                Console.WriteLine("Downloading '{0}'...", uri);

                Console.WriteLine("Download string {0}", await new HttpClient().GetStringAsync(uri));

                return await new HttpClient().GetStringAsync(uri);
            });

            // Separates the specified text into an array of words.
            var createWordList = new TransformBlock<string, string[]>(text =>
            {
                Console.WriteLine("Creating word list...");

                // Remove common punctuation by replacing all non-letter characters 
                // with a space character.
                char[] tokens = text.Select(c => char.IsLetter(c) ? c : ' ').ToArray();
                text = new string(tokens);

                // Separate the text into an array of words.
                return text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            });

            // Removes short words and duplicates.
            var filterWordList = new TransformBlock<string[], string[]>(words =>
            {
                Console.WriteLine("Filtering word list...");

                return words
                    .Where(word => word.Length > 3)
                    .Distinct()
                    .ToArray();
            });

            // Finds all words in the specified collection whose reverse also 
            // exists in the collection.
            var findReversedWords = new TransformManyBlock<string[], string>(words =>
            {
                Console.WriteLine("Finding reversed words...");

                var wordsSet = new HashSet<string>(words);

                return from word in words.AsParallel()
                       let reverse = new string(word.Reverse().ToArray())
                       where word != reverse && wordsSet.Contains(reverse)
                       select word;
            });

            // Prints the provided reversed words to the console.    
            var printReversedWords = new ActionBlock<string>(reversedWord =>
            {
                Console.WriteLine("Found reversed words {0}/{1}",
                    reversedWord, new string(reversedWord.Reverse().ToArray()));
            });


            //
            // Connect the dataflow blocks to form a pipeline.
            //
            //If you also provide DataflowLinkOptions with PropagateCompletion set to true, 
            //successful or unsuccessful completion of one block in the pipeline will cause completion of the next block in the pipeline.

            var linkOptions = new DataflowLinkOptions { PropagateCompletion = true };

            downloadString.LinkTo(createWordList, linkOptions);
            createWordList.LinkTo(filterWordList, linkOptions);
            filterWordList.LinkTo(findReversedWords, linkOptions);
            findReversedWords.LinkTo(printReversedWords, linkOptions);

            // Process "The Iliad of Homer" by Homer.
            downloadString.SendAsync("http://www.gutenberg.org/files/6130/6130-0.txt");

            // Mark the head of the pipeline as complete. Or tell this block to complete.
            downloadString.Complete();


            // Wait for the last block in the pipeline to process all messages.
            // this is where exception will be thrown if any.
            // We recommend that you handle exceptions in the bodies of such blocks.However,
            // if you are unable to do so, the block behaves as though it was canceled and does not process incoming messages.
            printReversedWords.Completion.Wait();
        }
    }
}
