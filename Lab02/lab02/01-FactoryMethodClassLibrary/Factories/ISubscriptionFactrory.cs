using _01_FactoryMethodClassLibrary.Subscriptions;

namespace _01_FactoryMethodClassLibrary.Factories
{
    public interface ISubscriptionFactory
    {
        Subscription CreateSubscription(string subscriberName);
    }
}