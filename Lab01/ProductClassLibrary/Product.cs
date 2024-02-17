using MoneyClassLibrary;

namespace ProductClassLibrary
{
    public abstract class Product
    {
        public string Name { get; set; } = default!;
        public Money Price { get; set; }

        protected Product(string name, Money price)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name), "Name cant be null or empty.");
            }

            if (price < price.Currency.Zero)
            {
                throw new ArgumentOutOfRangeException(nameof(price), "Price must be a non-negative number.");
            }

            this.Name = name;
            this.Price = price;
        }

        public abstract void DecreasePrice(Money amount);

        public void IncreasePrice(Money amount)
        {
            if (amount < amount.Currency.Zero)
            {
                throw new ArgumentException("Amount must be a non-negative number.", nameof(amount));
            }

            this.Price += amount;
        }

        public void ChangePrice(Money newPrice)
        {
            if (newPrice < newPrice.Currency.Zero)
            {
                throw new ArgumentException("Price must be a non-negative number.", nameof(newPrice));
            }

            this.Price = newPrice;
        }

        public override string ToString() =>
            $"Name: {this.Name}, Price: {this.Price}";
    }
}