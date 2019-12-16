using System;

namespace Ranjan.TPL.TaskBasedAsyncProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
             //TaskBasedAsyncProgramming.RunTaskFactoryExample();
            //TaskBasedAsyncProgramming.LambdaExpressionNotCapturingValuesOnEachIterationExample();
           //TaskBasedAsyncProgramming.LambdaExpressionCapturingValuesOnEachIterationExample();
            //CreatingAndRunningTasksExplicitly.AnotherWayOfGrabbingStateUsingAsyncState();
            CreatingTaskContinuations.RunTaskContinuationExample();

            Console.ReadKey();
        }
    }
}
