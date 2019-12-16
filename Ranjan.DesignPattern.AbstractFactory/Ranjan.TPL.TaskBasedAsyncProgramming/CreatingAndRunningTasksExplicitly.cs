using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ranjan.TPL.TaskBasedAsyncProgramming
{
    public class CreatingAndRunningTasksExplicitly
    {
        ///  Use this method when creation and scheduling do not have to be separated
        /// and you require additional task creation options or the use of a specific scheduler,
        /// or when you need to pass additional state into the task that you can retrieve through its Task.AsyncState property
        public static void RunTaskFactoryExample()
        {    
            Task[] taskArray = new Task[10];
            for (int i = 0; i < taskArray.Length; i++)
            {
                taskArray[i] = Task.Factory.StartNew((Object obj) => {
                        CustomData data = obj as CustomData;
                        if (data == null)
                            return;

                        data.ThreadNum = Thread.CurrentThread.ManagedThreadId;
                    },
                    new CustomData() { Name = i, CreationTime = DateTime.Now.Ticks });
            }
            Task.WaitAll(taskArray);
            foreach (var task in taskArray)
            {
                var data = task.AsyncState as CustomData;
                if (data != null)
                    Console.WriteLine("Task #{0} created at {1}, ran on thread #{2}.",
                        data.Name, data.CreationTime, data.ThreadNum);
            }
        }

        //WRONG WAY TO DO IT, since iteration value is not captured in every iteration.
        public static void LambdaExpressionNotCapturingValuesOnEachIterationExample()
        {
            // Create the task object by using an Action(Of Object) to pass in the loop
            // counter. This produces an unexpected result.
            Task[] taskArray = new Task[10];
            for (int i = 0; i < taskArray.Length; i++)
            {
                taskArray[i] = Task.Factory.StartNew((Object obj) => {
                        var data = new CustomData() { Name = i, CreationTime = DateTime.Now.Ticks };
                        data.ThreadNum = Thread.CurrentThread.ManagedThreadId;
                        Console.WriteLine("Task #{0} created at {1} on thread #{2}.",
                            data.Name, data.CreationTime, data.ThreadNum);
                    },
                    i);
            }
            Task.WaitAll(taskArray);
        }

        public static void LambdaExpressionCapturingValuesOnEachIterationExample()
        {
            // Create the task object by using an Action(Of Object) to pass in custom data
            // to the Task constructor. This is useful when you need to capture outer variables
            // from within a loop. 
            Task[] taskArray = new Task[10];
            for (int i = 0; i < taskArray.Length; i++)
            {
                taskArray[i] = Task.Factory.StartNew((Object obj) => {
                        CustomData data = obj as CustomData;
                        if (data == null)
                            return;

                        data.ThreadNum = Thread.CurrentThread.ManagedThreadId;
                        Console.WriteLine("Task #{0} created at {1} on thread #{2}.",
                            data.Name, data.CreationTime, data.ThreadNum);
                    },
                    new CustomData() { Name = i, CreationTime = DateTime.Now.Ticks });
            }
            Task.WaitAll(taskArray);
        }

        public static void AnotherWayOfGrabbingStateUsingAsyncState()
        {
            Task[] taskArray = new Task[10];
            for (int i = 0; i < taskArray.Length; i++)
            {
                taskArray[i] = Task.Factory.StartNew((Object obj) => {
                        CustomData data = obj as CustomData;
                        if (data == null)
                            return;

                        data.ThreadNum = Thread.CurrentThread.ManagedThreadId;
                    },
                    new CustomData() { Name = i, CreationTime = DateTime.Now.Ticks });
            }
            Task.WaitAll(taskArray);
           
            foreach (var task in taskArray)
            {
                var data = task.AsyncState as CustomData;
                var taskId = task.Id;
                if (data != null)
                    Console.WriteLine("Task #{0} created at {1}, ran on thread #{2}. The id of task is {3}",
                        data.Name, data.CreationTime, data.ThreadNum, task.Id);
            }
        }

        class CustomData
        {
            public long CreationTime;
            public int Name;
            public int ThreadNum;
        }
    }
}
