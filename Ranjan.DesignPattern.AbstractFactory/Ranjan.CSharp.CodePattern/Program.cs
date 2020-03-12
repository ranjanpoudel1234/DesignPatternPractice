using System;

namespace Ranjan.CSharp.CodePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var myFakeLinq = new MyFakeLinq();
            var result = from m in myFakeLinq
                where m > 2
                select m;

            var result1 = from m in myFakeLinq
                          where m > 2
                          select m.ToString(); // not found without second Select method

            var example = new Moves();
            foreach (var e in example)
            {
                Console.Out.WriteLine("Moves left: " + e);
            }

            Console.ReadKey();
        }
    }

    public class MyFakeLinq
    {
        public MyFakeLinq Where(Func<int, bool> predicate)
        {
            // TODO: Implement something reasonable ;)
            Console.Out.WriteLine("Where called");
            return this;
        }

        public string Select(Func<int, string> selection)
        {
            // TODO
            Console.Out.WriteLine("Basic Select");
            return "";
        }
    }

    /// <summary>
    /// That LINQ is a series of method calls is maybe not a surprise, but LINQ is not alone. The very basic foreach keyword behaves similarly. You might expect that you need to implement the IEnumerable<T> interface to support foreach, but you don’t. The target object needs a .GetEnumerator() method and the returned object then needs a .Current property and a .MoveNext() method. As soon as these methods are available the foreach keyword works.
    /// </summary>
    class Moves // Note no IEnumerable
    {
        public MovesEnumerator GetEnumerator() => new MovesEnumerator(5);

        public struct MovesEnumerator : IDisposable // Note no IEnumerator
        {
            private int movesLeft;

            public MovesEnumerator(int movesLeft)
            {
                this.movesLeft = movesLeft;
            }

            public bool MoveNext()
            {
                var moved = 0 < movesLeft;
                if (moved)
                {
                    movesLeft--;
                }
                return moved;

            }

            public int Current
            {
                get { return movesLeft; }
            }

            /// <summary>
            /// When the Enumerator implements the IDisposable interface, the enumerator is disposed after the foreach block. So foreach also acts like using. This is useful when the application iterates over data from an external source like a file or a database.
            /// </summary>
            public void Dispose()
            {
                Console.Out.WriteLine("Release some important resource when done iterating");
            }
        }
    }
}
