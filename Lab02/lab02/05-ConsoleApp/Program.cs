using _05_BuilderClassLibrary;

namespace _05_ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                var hero = HeroDirector.BuildHero();
                var villain = HeroDirector.BuildVillain();

                Console.WriteLine($"HERO:\n{hero}\n");
                Console.WriteLine($"VILLAIN:\n{villain}");
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
