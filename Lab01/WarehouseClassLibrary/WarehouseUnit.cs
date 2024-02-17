using MoneyClassLibrary;
using ProductClassLibrary;

namespace WarehouseClassLibrary
{
    public class WarehouseUnit
    {
        private readonly Product _product;
        public string MeasurementUnit { get; }
        public string ProductName => this._product.Name;
        public Money PricePerUnit => this._product.Price;
        public int Quantity { get; private set; }
        public DateTime LastArrivalDate { get; private set; }

        public WarehouseUnit(Product product, string unit, int quantity, DateTime lastArrivalDate)
        {
            if (string.IsNullOrWhiteSpace(unit))
            {
                throw new ArgumentException("Unit cannot be null or whitespace.", nameof(unit));
            }

            if (quantity < 0)
            {
                throw new ArgumentException("Quantity must be a non-negative integer.", nameof(quantity));
            }

            if (lastArrivalDate > DateTime.Today)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(lastArrivalDate),
                    $"The last arrival date ({lastArrivalDate.ToShortDateString()}) cannot be future date."
                );
            }

            this._product = product ?? throw new ArgumentNullException(nameof(product), "Product cannot be null.");
            this.MeasurementUnit = unit;
            this.Quantity = quantity;
            this.LastArrivalDate = lastArrivalDate;
        }

        public void IncreaseQuantity(int amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Amount must be a positive integer.", nameof(amount));

            this.Quantity += amount;
        }

        public void DecreaseQuantity(int amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Amount must be a positive integer.", nameof(amount));

            if (amount > Quantity)
                throw new InvalidOperationException("Not enough items in stock.");

            this.Quantity -= amount;
        }

        public void UpdateQuantity(int newQuantity)
        {
            if (newQuantity < 0)
                throw new ArgumentException("Quantity must be a non-negative integer.", nameof(newQuantity));

            this.Quantity = newQuantity;
        }

        public void UpdateLastArrivalDate(DateTime newDate)
        {
            this.LastArrivalDate = newDate;
        }

        public void UpdateProductPrice(Money newPrice)
        {
            this._product.ChangePrice(newPrice);
        }

        public void IncreaseProductPrice(Money amount)
        {
            this._product.IncreasePrice(amount);
        }

        public void DecreaseProductPrice(Money amount)
        {
            this._product.DecreasePrice(amount);
        }

        public override string ToString() =>
            $"Product: ({this._product}), Quantity in stock: {this.Quantity} {this.MeasurementUnit}, Last arrival date: {LastArrivalDate.ToShortDateString()}";
    }
}