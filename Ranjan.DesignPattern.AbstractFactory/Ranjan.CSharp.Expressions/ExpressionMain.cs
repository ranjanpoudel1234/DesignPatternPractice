using System;
using System.Linq.Expressions;

namespace Ranjan.CSharp.Expressions
{
    public class ExpressionMain
    {
        public static void Main(string[] args)
        {
            //expressions
            var name = "Ranjan";
            Console.WriteLine(RegularGreetingFunction(name));

            var getGreetingFunction = ConstructGreetingExpression();
            Console.WriteLine(getGreetingFunction(name));


            //statements like Console.WriteLine
            var statementBlock = Statements.CreateStatementBlock();
            var lambda = Expression.Lambda<Action>(statementBlock).Compile();
            lambda();

            var statementBlockWithVariables = Statements.CreateStatementBlockWithVariables();
            var lambdaWithVariables = Expression.Lambda<Action>(statementBlockWithVariables).Compile();
            lambdaWithVariables();


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

            //To evaluate expression, we have to create an entry point by wrapping everything in a lambda expression.
            //To turn it into an actual lambda, we can call Compile which will produce a delegate that we can invoke.
            var lambda = Expression.Lambda<Func<string, string>>(conditional, personNameParameter);

            return lambda.Compile();
        }
    }
}
