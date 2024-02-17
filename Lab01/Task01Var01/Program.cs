using MoneyClassLibrary;
using ProductClassLibrary;
using WarehouseClassLibrary;

namespace Task01Var01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var usd = new Currency("USD");
                var eur = new Currency("EUR");

                var price1 = usd.Of(10.50m);
                var price2 = eur.Of(20.75m);

                var product1 = new StandartProduct("Standart Product", price1);
                var product2 = new DiscountedProduct("Discounted Product", price2, 0.25m);

                var unit1 = new WarehouseUnit(product1, "pcs", 100, DateTime.Now.AddDays(-10));
                var unit2 = new WarehouseUnit(product2, "kg", 50, DateTime.Now.AddDays(-5));

                var warehouse = new Warehouse();
                warehouse.AddUnit(unit1);
                warehouse.AddUnit(unit2);

                var reporting = new Reporting(warehouse);
                reporting.RegisterArrival(unit1);
                reporting.RegisterArrival(unit2);

                reporting.RegisterDeparture(unit1, 20);
                reporting.InventoryReport();

                unit2.UpdateProductPrice(eur.Of(18.50m));
                Console.WriteLine($"Updated price for {unit2}: {unit2.PricePerUnit}");

                unit1.IncreaseQuantity(50);
                unit2.DecreaseQuantity(10);

                warehouse.RemoveUnit(unit1);
                reporting.InventoryReport();

                warehouse.Clear();
                reporting.InventoryReport();
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