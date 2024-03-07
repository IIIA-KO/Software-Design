using _05_BuilderClassLibrary;

namespace _05_ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Hero Hero = HeroBuilder
                    .WithName("Hero")
                    .InOutfit("Armor")
                    .WithHeight(180)
                    .WithBuild("Athletic")
                    .WithHairColor("Blonde")
                    .WithEyeColor("Blue")
                    .Create();

                Hero Villian = HeroBuilder
                    .WithName("Villian")
                    .InOutfit("Dark Robe")
                    .WithHeight(170)
                    .WithBuild("Thin")
                    .WithHairColor("Bald")
                    .WithEyeColor("Red")
                    .Create();

                Console.WriteLine($"HERO:\n{Hero}\n");
                Console.WriteLine($"VILLIAN:\n{Villian}");
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
