using System;
using System.Linq.Expressions;
using AgileObjects.ReadableExpressions;

namespace Ranjan.CSharp.Expressions
{
    public class ExpressionMain
    {
        public static void Main(string[] args)
        {
            // 1.expressions
            var name = "Ranjan";
            Console.WriteLine(RegularGreetingFunction(name));

            var getGreetingFunction = ConstructGreetingExpression();
            Console.WriteLine(getGreetingFunction(name));


            // 2.statements like Console.WriteLine
            // dynamically compile code that contains multiple statements
            var statementBlock = Statements.CreateStatementBlock();
            var lambda = Expression.Lambda<Action>(statementBlock).Compile();
            lambda();

            var statementBlockWithVariables = Statements.CreateStatementBlockWithVariables();
            var lambdaWithVariables = Expression.Lambda<Action>(statementBlockWithVariables).Compile();
            lambdaWithVariables();


            // 3.expressions as readable code using ReadableExpression nuget package.
            var thisIsNotReadableDuringDebug = statementBlock.ToString();
            var thisIsReadableDuringDebug = statementBlock.ToReadableString();

            var moreNonReadableStatementBlock = statementBlockWithVariables.ToString();
            var moreReadbleStatementBlock = statementBlockWithVariables.ToReadableString();

            ComplexExpressionReadability();


            // 4. Optimizing reflection Calls.
            Benchmarks.RunBenchMark();

            Console.ReadKey();
        }

        public static string RegularGreetingFunction(string personName)
        {
            return !string.IsNullOrWhiteSpace(personName) ? "Greetings, " + personName : null;
        }

        /// <summary>
        /// !string.IsNullOrWhiteSpace(personName)
        /// ? "Greetings, " + personName
        /// : null;
        /// </summary>
        /// <returns></returns>
        public static Func<string, string> ConstructGreetingExpression()
        {
            var personNameParameter = Expression.Parameter(typeof(string), "personName");

            // Condition
            var isNullOrWhiteSpaceMethod = typeof(string)
                .GetMethod(nameof(string.IsNullOrWhiteSpace));

            var condition = Expression.Not(
                Expression.Call(isNullOrWhiteSpaceMethod, personNameParameter));

            // True clause
            var concatMethod = typeof(string)
                .GetMethod(nameof(string.Concat), new[] { typeof(string), typeof(string) });

            var trueClause = Expression.Call(concatMethod,
                Expression.Constant("Greetings, "),
                personNameParameter);

            //Cant use this. Because what happens is that the C# compiler automatically converts expressions like "foo" + "bar"
            //into string.Concat("foo", "bar")
            //var trueClause = Expression.Add(
            //    Expression.Constant("Greetings, "),
            //    personNameParameter);

            // False clause
            var falseClause = Expression.Constant(null, typeof(string));

            // Ternary conditional
            var conditional = Expression.Condition(condition, trueClause, falseClause);

            var notTooReadable = conditional.ToString();
            var easilyReadable = conditional.ToReadableString();

            //To evaluate expression, we have to create an entry point by wrapping everything in a lambda expression.
            //To turn it into an actual lambda, we can call Compile which will produce a delegate that we can invoke.
            var lambda = Expression.Lambda<Func<string, string>>(conditional, personNameParameter);

            return lambda.Compile();
        }

        public static void ComplexExpressionReadability()
        {
            var nArgument = Expression.Parameter(typeof(int), "n");
            var result = Expression.Variable(typeof(int), "result");

            // Creating a label that represents the return value
            LabelTarget label = Expression.Label(typeof(int));

            var initializeResult = Expression.Assign(result, Expression.Constant(1));

            // This is the inner block that performs the multiplication,
            // and decrements the value of 'n'
            var block = Expression.Block(
                Expression.Assign(result,
                    Expression.Multiply(result, nArgument)),
                Expression.PostDecrementAssign(nArgument)
            );

            // Creating a method body.
            BlockExpression body = Expression.Block(
                new[] { result },
                initializeResult,
                Expression.Loop(
                    Expression.IfThenElse(
                        Expression.GreaterThan(nArgument, Expression.Constant(1)),
                        block,
                        Expression.Break(label, result)
                    ),
                    label
                )
            );

            var notReadble = body.ToString();
            var easilyReadable = body.ToReadableString();
        }
    }
}
