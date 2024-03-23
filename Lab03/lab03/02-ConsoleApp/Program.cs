using _02_Decorator.Heroes;
using _02_Decorator.Inventory;

namespace _02_ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Initial stats:");
            Hero warrior = new Warrior("Warrior");
            warrior.DisplayStats();

            Hero mage = new Mage("Mage");
            mage.DisplayStats();

            Hero paladin = new Paladin("Paladin");
            paladin.DisplayStats();

            Console.WriteLine(new string('-', 100));

            warrior = new Armor(warrior);
            Console.WriteLine("Warrior with armor:");
            warrior.DisplayStats();

            mage = new Sword(mage);
            Console.WriteLine("Mage with sword:");
            mage.DisplayStats();

            paladin = new Armor(paladin);
            paladin = new Sword(paladin);
            Console.WriteLine("Paladin with armor and sword:");
            paladin.DisplayStats();
        }
    }
}
