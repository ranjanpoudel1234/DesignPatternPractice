namespace Ranjan.DesignPattern.Singleton.ConceptExample
{
    public sealed class Singleton
    {
        private static Singleton _instance;

        /// <summary>
        /// One important item to note in the above code is the "_lockThis" object and the use of locking within the "GetSingleton" method.
        /// As C# programs can be multithreaded, it is possible that two threads could request the singleton before the instance variable is initialised.
        /// In rare cases, these two threads may both create their own copies of the class, defeating the principle of the design pattern. By locking the dummy "_lockThis" variable whilst checking, and possibly creating, the instance variable, all other threads will be blocked for very brief period.
        /// This means that no two threads will ever be able to simultaneously create their own copies of the object.
        /// </summary>
        private static object _lockThis = new object();

        private Singleton() { } // the constructor is marked as parivate.

        // instance of the class is created only when first requested.
        public static Singleton GetSingleton()
        {
            lock (_lockThis)
            {
                if (_instance == null) _instance = new Singleton();
            }

            return _instance;
        }
    }
}
