namespace MoneyClassLibrary
{
    public class Currency : IEquatable<Currency>
    {
        private string Symbol { get; }

        public Currency(string symbol)
        {
            this.Symbol = symbol;
        }

        public Money Zero =>
            new Money(0, 0, this);

        public Money MinPositiveValue =>
            new Money(0, 1, this);

        public Money Of(decimal amount)
        {
            int wholePart = (int)Math.Truncate(amount);
            int fractionalPart = (int)((amount - wholePart) * 100);
            return new Money(wholePart, fractionalPart, this);
        }

        public override string ToString() =>
            this.Symbol;

        public bool Equals(Currency other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Symbol, other.Symbol);
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Currency)obj);
        }

        public static bool operator ==(Currency a, Currency b) =>
            a?.Equals(b) ?? b is null;

        public static bool operator !=(Currency a, Currency b) =>
            !(a == b);

        public override int GetHashCode()
        {
            return (Symbol != null ? Symbol.GetHashCode() : 0);
        }
    }
}
