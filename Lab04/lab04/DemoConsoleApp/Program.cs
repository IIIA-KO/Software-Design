using DemoConsoleApp.Demos;

namespace DemoClassLibrary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Demo> demos =
            [
                new CoRDemo(),
                new MediatorDemo(),
                new ObserverDemo(),
                new StrategyDemo(),
                new MementoDemo()
            ];

            demos.ForEach(demo => { demo.Run(); });
        }
    }
}