namespace _01_FactoryMethodClassLibrary.Subscriptions
{
    public class DomesticSubscription : Subscription
    {
        internal DomesticSubscription(string subscriberName, IReadOnlyCollection<string> channels)
            : base("Domestic", subscriberName, 10.99m, 1, channels)
        {
        }
    }
}
