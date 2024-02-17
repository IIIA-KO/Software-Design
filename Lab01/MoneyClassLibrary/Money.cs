namespace MoneyClassLibrary
{
    public class Money : IEquatable<Money>
    {
        public int WholePart { get; }
        public int FractionalPart { get; }
        public Currency Currency { get; }
        private decimal Amount => WholePart + FractionalPart / 100m;

        public Money(int wholePart, int fractionalPart, Currency currency)
        {
            if (wholePart < 0)
            {
                throw new ArgumentException("Whole part cannot has value less than 0", nameof(wholePart));
            }

            if (fractionalPart < 0 || fractionalPart > 99)
            {
                throw new ArgumentException("Fractional part can only has values from 0 to 99", nameof(fractionalPart));
            }

            this.WholePart = wholePart;
            this.FractionalPart = fractionalPart;
            this.Currency = currency;
        }

        public virtual Money Add(Money other) =>
            this + other;

        public Money SubtractAmount(decimal amount) =>
            this - this.Currency.Of(amount);

        public static Money operator *(Money amount, decimal factor)
        {
            ArgumentNullException.ThrowIfNull(amount);

            bool isNegative = factor < 0;
            decimal absFactor = Math.Abs(factor);

            decimal newAmount = amount.Amount * absFactor;

            int newWholePart = (int)newAmount;
            if (isNegative)
            {
                newWholePart = -newWholePart;
            }

            int newFractionalPart = (int)((newAmount - newWholePart) * 100);

            return new Money(newWholePart, newFractionalPart, amount.Currency);
        }

        public static Money operator *(decimal factor, Money amount) =>
            amount * factor;

        public static Money operator /(Money amount, decimal factor)
        {
            if (factor == 0)
            {
                throw new DivideByZeroException("Division by zero is not allowed.");
            }

            decimal newAmount = amount.Amount / factor;

            int newWholePart = (int)newAmount;
            int newFractionalPart = (int)((newAmount - newWholePart) * 100);

            return new Money(newWholePart, newFractionalPart, amount.Currency);
        }

        public static decimal operator /(Money a, Money b)
        {
            if (a.Currency != b.Currency)
            {
                RaiseCurrencyError<decimal>("divide", a, b);
            }

            if (b.Amount == 0)
            {
                throw new DivideByZeroException("Division by zero is not allowed.");
            }

            return a.Amount / b.Amount;
        }

        public static Money operator +(Money a, Money b)
        {
            if (a.Currency != b.Currency)
            {
                RaiseCurrencyError<decimal>("add", a, b);
            }

            int newWholePart = a.WholePart + b.WholePart;
            int newFractionalPart = a.FractionalPart + b.FractionalPart;

            if (newFractionalPart >= 100)
            {
                newWholePart++;
                newFractionalPart -= 100;
            }

            return new Money(newWholePart, newFractionalPart, a.Currency);
        }

        public static Money operator -(Money a, Money b)
        {
            if (a.Currency != b.Currency)
            {
                RaiseCurrencyError<decimal>("subtract", a, b);
            }

            if (a < b)
            {
                throw new ArgumentException("Not enough funds");
            }

            int newWholePart = a.WholePart - b.WholePart;
            int newFractionalPart = a.FractionalPart - b.FractionalPart;

            if (newFractionalPart < 0)
            {
                newWholePart--;
                newFractionalPart += 100;
            }

            return new Money(newWholePart, newFractionalPart, a.Currency);
        }

        public static bool operator ==(Money a, Money b)
        {
            if (a is null || b is null)
            {
                return false;
            }

            if (ReferenceEquals(a, b))
            {
                return true;
            }

            return a.Equals(b);
        }

        public static bool operator !=(Money a, Money b) =>
            !(a == b);

        public static bool operator >(Money a, Money b) =>
            a.Currency == b.Currency ? a.Amount > b.Amount
            : RaiseCurrencyComparisonError(a, b);

        public static bool operator <(Money a, Money b) =>
            a.Currency == b.Currency ? a.Amount < b.Amount
            : RaiseCurrencyComparisonError(a, b);

        public static bool operator >=(Money a, Money b) =>
            a.Currency == b.Currency ? a.Amount >= b.Amount
            : RaiseCurrencyComparisonError(a, b);

        public static bool operator <=(Money a, Money b) =>
            a.Currency == b.Currency ? a.Amount <= b.Amount
            : RaiseCurrencyComparisonError(a, b);

        private static bool RaiseCurrencyComparisonError(Money a, Money b) =>
            RaiseCurrencyError<bool>("compare", a, b);

        private static T RaiseCurrencyError<T>(string operation, Money a, Money b) =>
            throw new ArgumentException($"Cannot {operation} {a.Currency} and {b.Currency}");

        public override string ToString() =>
            $"{this.Amount:0.00} {this.Currency}";

        public bool Equals(Money other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return Amount == other.Amount && Equals(Currency, other.Currency);
        }

        public override bool Equals(object obj)
        {
            return obj is Money other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + WholePart.GetHashCode();
                hash = hash * 23 + FractionalPart.GetHashCode();
                hash = hash * 23 + (Currency is not null ? Currency.GetHashCode() : 0);
                return hash;
            }
        }
    }
}
