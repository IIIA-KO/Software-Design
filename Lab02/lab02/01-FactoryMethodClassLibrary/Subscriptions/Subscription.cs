namespace _01_FactoryMethodClassLibrary.Subscriptions
{
    public abstract class Subscription
    {
        public string Type { get; }
        public decimal MonthlyFee { get; }
        public string SubscriberName { get; init; }
        public int MinimumSubscriptionPeriod { get; }
        public IReadOnlyCollection<string> IncludedChannels { get; }

        internal Subscription(string type, string subscriberName, decimal monthlyFee, int minimumPeriod, IReadOnlyCollection<string> channels)
        {
            ArgumentException.ThrowIfNullOrEmpty(type, nameof(type));
            ArgumentException.ThrowIfNullOrEmpty(subscriberName, nameof(subscriberName));

            if (monthlyFee < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(monthlyFee), "Monthly fee must be non-negative value.");
            }

            if (minimumPeriod < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(minimumPeriod), "Minimum subscription period must be positive value.");
            }

            if (channels is null || channels.Count == 0)
            {
                throw new ArgumentException("Channel collection cannot be null or empty", nameof(channels));
            }

            this.Type = type;
            this.SubscriberName = subscriberName;
            this.MonthlyFee = monthlyFee;
            this.MinimumSubscriptionPeriod = minimumPeriod;
            this.IncludedChannels = channels;
        }

        public override string ToString()
        {
            return $"Type: {this.Type}, Monthly fee: {this.MonthlyFee:0.00}, Subscriber name: {this.SubscriberName}, Minimum subscription period: {this.MinimumSubscriptionPeriod}\n\tIncluded channels: [{string.Join(", ", this.IncludedChannels)}]";
        }
    }
}