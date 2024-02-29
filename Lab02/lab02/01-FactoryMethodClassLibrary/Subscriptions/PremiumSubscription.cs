namespace _01_FactoryMethodClassLibrary.Subscriptions
{
    public class PremiumSubscription : Subscription
    {
        internal PremiumSubscription(string subscriberName, IReadOnlyCollection<string> channels)
            : base("Premium", subscriberName, 29.99m, 12, channels)
        {
        }
    }
}