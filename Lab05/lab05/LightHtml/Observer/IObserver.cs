using LightHtml.Nodes;

namespace LightHtml.Observer
{
    public interface IObserver
    {
        Action<LightNode> Action { get; }
        string EventName { get; }

        void Update(LightNode node);
    }
}