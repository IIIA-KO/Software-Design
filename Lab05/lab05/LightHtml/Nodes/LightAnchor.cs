using LightHtml.Enums;
using LightHtml.State;
using LightHtml.Visitor;

namespace LightHtml.Nodes
{
    public class LightAnchor : LightElementNode
    {
        private readonly IStateMachine _state;

        public string Href { get; init; }
        
        public LightAnchor(IStateMachine state, AnchorState anchorState, string href) : base("a", DisplayType.Inline, ClosingType.Double, [], [])
        {
            this.Href = href ?? throw new ArgumentNullException(nameof(href), "Reference for anchor tag cannot be null.");

            this._state = state;
            this._state.Context = this;
            this._state.CurrentState = anchorState;

            TransitionTo(AnchorState.Default);
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public void TransitionTo(AnchorState anchorState) => 
            this._state.CurrentState = anchorState;

        protected override string OpeningSegment(int indent) =>
            $"{new string(' ', IndentSize * indent)}<{this.TagName} href=\"{this.Href}\"";

        public void Print() => 
            this._state.HandleRequest();
    }
}