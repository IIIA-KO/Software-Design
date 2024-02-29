namespace _01_FactoryMethodClassLibrary.Subscriptions
{
    public class EducationalSubscription : Subscription
    {
        internal EducationalSubscription(string subscriberName, IReadOnlyCollection<string> channels)
            : base("Educational", subscriberName, 4.50m, 3, channels)
        {
        }
    }
}