using _02_Decorator.Heroes;

namespace _02_Decorator.Inventory
{
    public class Sword : InventoryDecorator
    {
        public Sword(Hero hero) : base(hero)
        {
            this.Attack += 15;
        }

        public override void DisplayStats()
        {
            base.DisplayStats();
            Console.WriteLine("Equipped with Sword\n");
        }
    }
}