using System.Collections;

namespace WarehouseClassLibrary
{
    public class Warehouse : IEnumerable<WarehouseUnit>
    {
        private readonly Dictionary<string, WarehouseUnit> _units = [];

        public void AddUnit(WarehouseUnit unit)
        {
            if (unit == null)
            {
                throw new ArgumentNullException(nameof(unit), "Unit cannot be null.");
            }

            this._units[unit.ProductName] = unit;
        }

        public bool RemoveUnit(WarehouseUnit unit)
        {
            if (unit == null)
            {
                throw new ArgumentNullException(nameof(unit), "Unit cannot be null.");
            }

            return this._units.Remove(unit.ProductName);
        }

        public WarehouseUnit GetUnitByName(string productName)
        {
            if (string.IsNullOrWhiteSpace(productName))
            {
                throw new ArgumentException("Product name cannot be null or whitespace.", nameof(productName));
            }

            this._units.TryGetValue(productName, out var unit);

            return unit ?? throw new InvalidOperationException($"No unit found with product name {productName}.");
        }

        public bool Exists(string productName)
        {
            if (string.IsNullOrWhiteSpace(productName))
            {
                throw new ArgumentException("Product name cannot be null or whitespace.", nameof(productName));
            }

            return this._units.ContainsKey(productName);
        }

        public IEnumerable<WarehouseUnit> GetUnits()
        {
            return this._units.Values;
        }

        public int GetTotalQuantity()
        {
            return this._units.Values.Sum(u => u.Quantity);
        }

        public void Clear()
        {
            this._units.Clear();
        }

        public IEnumerator<WarehouseUnit> GetEnumerator()
        {
            return this._units.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}