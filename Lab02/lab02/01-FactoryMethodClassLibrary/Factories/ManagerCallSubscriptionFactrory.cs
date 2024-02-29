using _01_FactoryMethodClassLibrary.Subscriptions;

namespace _01_FactoryMethodClassLibrary.Factories
{
    public class ManagerCallSubscriptionFactrory : ISubscriptionFactory
    {
        public Subscription CreateSubscription(string subscriberName)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Creating subscription via Manager call...");
            Console.ResetColor();

            var allChannels = new List<string>()
            {
                "Premium Channel 1", "Premium Channel 2", "Premium Channel 3", "Premium Channel 4", "Premium Channel 5"
            };

            return new PremiumSubscription(subscriberName, allChannels);
        }
    }
}