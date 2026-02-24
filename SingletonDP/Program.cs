
// Amir Moeini Rad
// September 2025

// Main Concept: The Singleton Design Pattern

// In this pattern, a class has only one instance and provides a global point of access to it.
// This is useful when exactly one object is needed to coordinate actions across the system or application.
// Examples include database connections pool, logging manager, and configuration settings manager.

// Mechanisms to implement the Singleton Pattern:
// 1) Private static field: Holds the single instance of the class.
// 2) Private constructor: Prevents instantiation from outside the class.
// 3) Public static method/property: A public static method is provided to access the instance.
// 4) Thread safety: In multi-threaded applications, care must be taken to ensure that the singleton instance is created
//    in a thread-safe manner.
// 5) Lazy initialization: The instance is created only when it is first needed, which can save resources if the instance is never used.
// 6) Global access point: The singleton instance can be accessed globally via a public method or property,
//    making it easy to share data or functionality across different parts of the application.
// 7) The singleton class is sealed to prevent modifications in the child classes.


namespace SingletonDP
{
    public sealed class Singleton
    {
        // Field 1
        // Private static instance (created only once)                
        // Can it be non-static? No, because we need to access it without creating an instance of the class from outside.
        // Furthermore, since the accessor method 'GetInstance()' is sttaic, it cannot access an instance field.
        // It is private so that it cannot be accessed directly from outside the class.
        private static Singleton? _instance;


        // Field 2
        // Lock object used for thread safety.
        private static readonly object _lock = new();


        // Private default constructor
        // No one can create the Singleton object from outside the class.
        private Singleton() 
        {
            Console.WriteLine("Creating the Singleton instance...");            
        }


        // Public method to get the single instance.
        // This method provides a global access point to the Singleton instance.
        // The method checks if the instance is null, and if so, it creates a new instance.
        // Otherwise, it returns the existing instance.
        public static Singleton GetInstance()
        {
            if (_instance == null)
            {                
                // Thread Safety or Mutual Exclusion
                // Double-check locking. The 'lock' keyword ensures that only one thread can enter this block at a time.
                lock (_lock) 
                {                    
                    if (_instance == null)
                    {
                        _instance = new Singleton();
                        Console.WriteLine("Singleton object created.");
                    }                    
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
    

    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("The Singleton Design Pattern in C#.NET.");
            Console.WriteLine("---------------------------------------\n");


            // We cannot create an instance of Singleton directly because its constructor is private.            
            Singleton s1 = Singleton.GetInstance();
            s1.ShowMessage();

            Singleton s2 = Singleton.GetInstance();            
            s2.ShowMessage();

            Console.WriteLine("Are s1 and s2 the same? " + (ReferenceEquals(s1, s2) ? "Yes" : "No"));


            Console.WriteLine("\nDone.");
        }
    }
}
