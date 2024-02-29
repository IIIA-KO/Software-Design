using _01_FactoryMethodClassLibrary.Factories;
using _01_FactoryMethodClassLibrary.Subscriptions;

namespace _01_ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ISubscriptionFactory websiteFactory = new WebsiteSubscriptionFactrory();
                ISubscriptionFactory mobileAppFactory = new MobileAppSubscriptionFactrory();
                ISubscriptionFactory managerCallFactory = new ManagerCallSubscriptionFactrory();

                var availableChannels = new List<string> { "Channel 1", "Channel 2", "Channel 3" };

                Console.WriteLine("1. Website");
                Console.WriteLine("2. Mobile App");
                Console.WriteLine("3. Manager Call");

                Console.Write("Choose subscription type: ");
                int choice = int.Parse(Console.ReadLine() ?? string.Empty);
                
                ISubscriptionFactory selectedFactory = choice switch
                {
                    1 => websiteFactory,
                    2 => mobileAppFactory,
                    3 => managerCallFactory,
                    _ => throw new InvalidOperationException("Invalid choice."),
                };

                Console.Write("Enter subscriber name: ");
                string? subscriberName = Console.ReadLine();

                Subscription subscription = selectedFactory.CreateSubscription(subscriberName);
                Console.WriteLine(subscription);
            }
            catch ( Exception ex )
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{ex.GetType().Name}: {ex.Message}");
                Console.ResetColor();
            }
        }
    }
}