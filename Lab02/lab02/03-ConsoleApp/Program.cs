using _03_SingletonClassLibrary;

namespace _03_ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Single thread:");
                Authenticator authenticator1 = Authenticator.Instance;
                Authenticator authenticator2 = Authenticator.Instance;

                Console.WriteLine($"authenticator1 == authenticator2: {ReferenceEquals(authenticator1, authenticator2)}");

                Console.WriteLine(authenticator1.GetHashCode());
                Console.WriteLine(authenticator2.GetHashCode());

                Console.WriteLine("\nMultithread:");

                Thread thread1 = new Thread(() =>
                {
                    Authenticator authenticator3 = Authenticator.Instance;
                    Console.WriteLine($"authenticator3 hash: {authenticator3.GetHashCode()}");
                });

                Thread thread2 = new Thread(() =>
                {
                    Authenticator authenticator4 = Authenticator.Instance;
                    Console.WriteLine($"authenticator4 hash: {authenticator4.GetHashCode()}");
                });

                thread1.Start();
                thread2.Start();

                thread1.Join();
                thread2.Join();

                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{ex.GetType().Name}: {ex.Message}");
                Console.ResetColor();
            }
        }
    }
}