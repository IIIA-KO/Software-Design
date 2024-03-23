using _02_Decorator.Heroes;

namespace _02_Decorator.Inventory
{
    public class Armor : InventoryDecorator
    {
        public Armor(Hero hero) : base(hero)
        {
            this.Health += 50;
        }

        public override void DisplayStats()
        {
            base.DisplayStats();
            Console.WriteLine("Equipped with Armor\n");
        }
    }
}