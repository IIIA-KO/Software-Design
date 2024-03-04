using _02_AbstractFactoryClassLibrary.Factories;

namespace _02_ConsoleApp
{
    internal class Program
    {
        private static void TestFactory(IDeviceFactory deviceFactory)
        {
            Console.WriteLine(new string('-', 30));
            Console.WriteLine($"{deviceFactory.Brand} devices:");

            var ebook = deviceFactory.CreateEbook();
            var phone = deviceFactory.CreateSmartphone();
            var laptop = deviceFactory.CreateLaptop();
            var netbook = deviceFactory.CreateNetbook();

            Console.WriteLine(ebook);
            Console.WriteLine(phone);
            Console.WriteLine(laptop);
            Console.WriteLine(netbook);

            Console.WriteLine(new string('-', 30));
        }

        static void Main(string[] args)
        {
            try
            {
                var iproneFactory = new IProneFactory();
                var kiaomiFactroy = new KiaomiFactory();
                var balaxyFactor = new BalaxyFactory();

                TestFactory(iproneFactory);
                Console.WriteLine();
                
                TestFactory(kiaomiFactroy);
                Console.WriteLine();

                TestFactory(balaxyFactor);
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