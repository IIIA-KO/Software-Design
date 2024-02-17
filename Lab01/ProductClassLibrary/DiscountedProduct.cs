using MoneyClassLibrary;

namespace ProductClassLibrary
{
    public class DiscountedProduct : Product
    {
        public decimal DiscountRate { get; }

        public DiscountedProduct(string name, Money price, decimal discountRate) : base(name, price)
        {
            if (discountRate < 0 || discountRate > 1)
            {
                throw new ArgumentOutOfRangeException(nameof(discountRate), "Discount rate must be between 0 and 1 (inclusive).");
            }

            this.DiscountRate = discountRate;
        }

        public override void DecreasePrice(Money amount)
        {
            if (amount < amount.Currency.Zero)
            {
                throw new ArgumentException("Amount must be a non-negative number.", nameof(amount));
            }

            this.Price -= amount * (1 - DiscountRate);
        }

        public override string ToString() => 
            $"{base.ToString()}, Discount Rate: {this.DiscountRate * 100}%";
    }
}
