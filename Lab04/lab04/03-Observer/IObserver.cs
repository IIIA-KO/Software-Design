using _03_Observer.Nodes;

namespace _03_Observer
{
    public interface IObserver
    {
        Action<LightNode> Action { get; }
        string EventName { get; }

        void Update(LightNode node);
    }
}