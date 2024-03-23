using _02_Decorator.Heroes;

namespace _02_Decorator.Inventory
{
    public class InventoryDecorator(Hero hero) : Hero(hero.Name, hero.Health, hero.Attack)
    {
    }
}