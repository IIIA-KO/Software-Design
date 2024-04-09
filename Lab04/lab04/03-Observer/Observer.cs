using _03_Observer.Nodes;

namespace _03_Observer
{
    public class Observer(string eventName, Action<LightNode> htmlEventDelegate) : IObserver
    {
        public Action<LightNode> Action { get; } = htmlEventDelegate;
        public string EventName { get; } = eventName;

        public void Update(LightNode node)
        {
            this.Action.Invoke(node);
        }
    }
}