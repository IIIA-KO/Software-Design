namespace WarehouseClassLibrary
{
    public class Reporting(Warehouse warehouse)
    {
        private readonly Warehouse _warehouse = warehouse ?? throw new ArgumentNullException(nameof(warehouse));

        public void RegisterArrival(WarehouseUnit unit)
        {
            this._warehouse.AddUnit(unit);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine($"Incoming Invoice: Product \"{unit.ProductName}\" has arrived at the warehouse. Quantity: {unit.Quantity}.");
            Console.WriteLine("--------------------------------------------------");
            Console.ResetColor();
        }

        public void RegisterDeparture(WarehouseUnit unit, int quantity)
        {
            if (unit.Quantity < quantity)
            {
                throw new InvalidOperationException("Not enough product in stock for shipment.");
            }

            unit.DecreaseQuantity(quantity);

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(new string('-', 70));
            Console.WriteLine($"Outgoing Invoice: Product \"{unit.ProductName}\" has been shipped from the warehouse. Quantity: {quantity}.");
            Console.WriteLine(new string('-', 70));
            Console.ResetColor();
        }

        public void InventoryReport()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Inventory Report:");
            if (this._warehouse.Count() > 0)
            {
                foreach (var unit in this._warehouse)
                {
                    Console.WriteLine($"-  {unit}");
                }
            }
            else
            {
                Console.WriteLine("-  No warehouse units in the warehouse");
            }
            Console.WriteLine("--------------------------------------------------");
            Console.ResetColor();
        }
    }
}