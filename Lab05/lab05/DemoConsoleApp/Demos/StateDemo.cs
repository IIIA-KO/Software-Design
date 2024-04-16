using LightHtml.Nodes;
using LightHtml.State;
using DemoClassLibrary;

namespace DemoConsoleApp.Demos
{
    public class StateDemo : Demo
    {
        protected override string Name => "State";

        protected override void Implementation()
        {
            IStateMachine stateMachine = new StateMachine();
            var link = new LightAnchor(stateMachine, AnchorState.Default, "https://refactoring.guru/design-patterns/state/csharp/example");
            
            link.Print();

            link.TransitionTo(AnchorState.Visited);
            link.Print();

            link.TransitionTo(AnchorState.Hover);
            link.Print();

            link.TransitionTo(AnchorState.Focus);
            link.Print();

            link.TransitionTo(AnchorState.Active);
            link.Print();
        }
    }
}