
// Amir Moeini Rad
// September 2025

// Main Concept: Singleton Design Pattern
// In this pattern, a class has only one instance and provides a global point of access to it.
// This is useful when exactly one object is needed to coordinate actions across the system.
// Examples include database connections, logging, and configuration settings.

// 1) Private static instance: The class contains a private static variable that holds the single instance of the class.
// 2) Private constructor: The constructor is private to prevent instantiation from outside the class.
// 3) Public static method: A public static method (often named GetInstance) is provided to access the instance.
// 4) Thread safety: In multi-threaded applications, care must be taken to ensure that the singleton instance is created
// in a thread-safe manner.
// 5) Lazy initialization: The instance is created only when it is first needed, which can save resources if the instance is never used.
// 6) Global access point: The singleton instance can be accessed globally, making it easy to share data or functionality
// across different parts of the application.


namespace SingletonDP
{
    internal class Singleton
    {
        // Private static instance (created only once)
        // This field is used as the global access point to the Singleton instance.
        private static Singleton? _instance;


        // Lock object for thread safety
        private static readonly object _lock = new();


        // Private constructor (no one can create the Singleton object from outside.)
        private Singleton() { }


        // Public method to get the single instance
        // The GetInstance method checks if the instance is null, and if so, it creates a new instance.
        // Otherwise, it returns the existing instance.
        public static Singleton GetInstance()
        {
            if (_instance == null)
            {
                Console.WriteLine("Creating the Singleton instance...");

                // Thread-safe
                // Double-check locking. The 'lock' keyword ensures that only one thread can enter this block at a time.
                lock (_lock) 
                {
                    _instance = new Singleton();                 
                }
            }
            else
            {
                Console.WriteLine("The Singleton instance already exists!");
            }
            
            return _instance;
        }


        // Example method to demonstrate functionality.
        public void ShowMessage() => Console.WriteLine("Hello from Singleton!\n");
    }

    
    ///////////////////////////////////////////
    

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("The Singleton Design Pattern in C#.NET.");
            Console.WriteLine("---------------------------------------\n");

          
            Singleton s1 = Singleton.GetInstance();
            s1.ShowMessage();

            Singleton s2 = Singleton.GetInstance();            
            s2.ShowMessage();

            Console.WriteLine("Are s1 and s2 the same? " + ReferenceEquals(s1, s2));


            Console.WriteLine("\nDone.");
        }
    }
}
