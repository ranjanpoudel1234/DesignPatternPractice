using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Ranjan.CSharp.Expressions
{
    // Using expression to compile reflection code on runtime to achieve better performance.
    public static class OptimizingReflectionCalls
    {
        public static int CallExecute(Command command) => (int) typeof(Command)
                                                            .GetMethod("Execute", BindingFlags.NonPublic | BindingFlags.Instance)
                                                            .Invoke(command, null);
        // if we were to put this in loop, it can be expensive call performance wise

        // Optimize without even using Expression. Separate part that Gets the method from part that invokes it
        // so the Get can be reused. SEE REFLECTION CACHED BELOW.

        // NOW, optimize by using COMPILED EXXPRESSION
    }

    public class Command
    {
        private int Execute() => 42;
    }

    public static class ReflectionCached
    {
        private static MethodInfo ExecuteMethod { get; } = typeof(Command).GetMethod("Execute", BindingFlags.NonPublic | BindingFlags.Instance);

        public static int CallExecute(Command command) => (int) ExecuteMethod.Invoke(command, null);
        //This can also be improved further by converting into reusable DELEGATE so we can void the overhead of INVOKE.
        //See ReflectionDelegate below.
    }

    public static class ReflectionDelegate
    {
        private static MethodInfo ExecuteMethod { get; } = typeof(Command).GetMethod("Execute", BindingFlags.NonPublic | BindingFlags.Instance);

        private static Func<Command, int> Impl { get; } = (Func<Command, int>) Delegate.CreateDelegate(typeof(Func<Command, int>), ExecuteMethod);

        public static int CallExecute(Command command) => Impl(command);
    }

    public static class ExpressionTrees
    {
        private static MethodInfo ExecuteMethod { get; } = typeof(Command).GetMethod("Execute", BindingFlags.NonPublic | BindingFlags.Instance);

        private static Func<Command, int> Impl { get; }

        static ExpressionTrees()
        {
            var instance = Expression.Parameter(typeof(Command));
            var call = Expression.Call(instance, ExecuteMethod);
            Impl = Expression.Lambda<Func<Command, int>>(call, instance).Compile();
        }

        public static int CallExecute(Command command) => Impl(command);
    }

    public class Benchmarks
    {
        [Benchmark(Description = "Reflection", Baseline = true)]
        public int Reflection() => (int)typeof(Command)
        .GetMethod("Execute", BindingFlags.NonPublic | BindingFlags.Instance)
        .Invoke(new Command(), null);

        [Benchmark(Description = "Reflection (cached)")]
        public int Cached() => ReflectionCached.CallExecute(new Command());

        [Benchmark(Description = "Reflection (delegate)")]
        public int Delegate() => ReflectionDelegate.CallExecute(new Command());

        [Benchmark(Description = "Expressions")]
        public int Expressions() => ExpressionTrees.CallExecute(new Command());

        public static void RunBenchMark() => BenchmarkRunner.Run<Benchmarks>();
    }
}
