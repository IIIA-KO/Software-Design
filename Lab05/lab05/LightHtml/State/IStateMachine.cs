using LightHtml.Nodes;

namespace LightHtml.State
{
    public interface IStateMachine
    {
        public LightAnchor Context { get; set; }
        public AnchorState CurrentState { get; set; }

        public void HandleRequest();
    }
}
