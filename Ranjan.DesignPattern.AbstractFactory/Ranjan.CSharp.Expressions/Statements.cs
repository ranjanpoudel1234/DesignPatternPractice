using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Ranjan.CSharp.Expressions
{
    public static class Statements
    {
        public static Expression CreateStatementBlock()
        {
            var consoleWriteMethod = typeof(Console)
                .GetMethod(nameof(Console.Write), new[] { typeof(string) });

            var consoleWriteLineMethod = typeof(Console)
                .GetMethod(nameof(Console.WriteLine), new[] { typeof(string) });

            return Expression.Block(
                Expression.Call(consoleWriteMethod, Expression.Constant("Hello ")),
                Expression.Call(consoleWriteLineMethod, Expression.Constant("world!")));
        }

        public static Expression CreateStatementBlockWithVariables()
        {
            var consoleWriteMethod = typeof(Console)
                .GetMethod(nameof(Console.Write), new[] { typeof(string) });

            var consoleWriteLineMethod = typeof(Console)
                .GetMethod(nameof(Console.WriteLine), new[] { typeof(string) });

            var variableA = Expression.Variable(typeof(string), "A");
            var variableB = Expression.Variable(typeof(string), "B");

            return Expression.Block(
                // Declare variables in scope
                new[] { variableA, variableB },

                // Assign values to variables
                Expression.Assign(variableA, Expression.Constant("Foo ")),
                Expression.Assign(variableB, Expression.Constant("bar")),

                // Call methods
                Expression.Call(consoleWriteMethod, variableA),
                Expression.Call(consoleWriteLineMethod, variableB)
          );

        }
    }
}
