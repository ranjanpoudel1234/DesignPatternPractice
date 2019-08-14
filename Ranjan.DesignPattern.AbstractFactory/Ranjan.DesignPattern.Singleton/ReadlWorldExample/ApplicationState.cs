namespace Ranjan.DesignPattern.Singleton.ReadlWorldExample
{
    /// <summary>
    ///  In the following example, a class is defined to hold the application's state.\
    /// Two properties are required, one for the user's login details and one for the maximum size of some element that they can manipulate.
    /// To ensure that the state is only held in a single instance, the class uses the singleton pattern approach.
    /// </summary>
    public class ApplicationState
    {
        private static ApplicationState _instance;

        private static object _lock = new object();

        private ApplicationState() { }

        public static ApplicationState GetApplicationState()
        {
            lock (_lock)
            {
                if (_instance == null) _instance = new ApplicationState();
            }

            return _instance;
        }

        public string LoginId { get; set; }
        public int MaxSize { get; set; }
    }
}
