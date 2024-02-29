using _01_FactoryMethodClassLibrary.Subscriptions;

namespace _01_FactoryMethodClassLibrary.Factories
{
    public class MobileAppSubscriptionFactrory : ISubscriptionFactory
    {
        public Subscription CreateSubscription(string subscriberName)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Creating subscription via Mobile App...");
            Console.ResetColor();

            var allChannels = new List<string>()
            {
                "Channel 1", "Channel 2", "Channel 3"
            };

            return new DomesticSubscription(subscriberName, allChannels);
        }
    }
}