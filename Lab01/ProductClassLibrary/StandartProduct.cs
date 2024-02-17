using MoneyClassLibrary;

namespace ProductClassLibrary
{
    public class StandartProduct(string name, Money price) : Product(name, price)
    {
        public override void DecreasePrice(Money amount)
        {
            if (amount < amount.Currency.Zero)
            {
                throw new ArgumentException("Amount must be a non-negative number.", nameof(amount));
            }

            this.Price -= amount;
        }
    }
}
