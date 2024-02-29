using _01_FactoryMethodClassLibrary.Subscriptions;

namespace _01_FactoryMethodClassLibrary.Factories
{
    public class WebsiteSubscriptionFactrory : ISubscriptionFactory
    {
        public Subscription CreateSubscription(string subscriberName)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Creating subscription via Website...");
            Console.ResetColor();

            var allChannels = new List<string>()
            {
                "Educational Channel 1", "Educational Channel 2", "Educational Channel 3", "Educational Channel 4"
            };

            return new EducationalSubscription(subscriberName, allChannels);
        }
    }
}