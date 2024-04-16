using LightHtml.Nodes;

namespace LightHtml.State
{
    public class StateMachine : IStateMachine
    {
        public LightAnchor Context { get; set; }
        public AnchorState CurrentState { get; set; }

        public void HandleRequest()
        {
            switch (this.CurrentState)
            {
                case AnchorState.Visited:
                    LightNode.PrintWithColor(this.Context.OuterHTML, ConsoleColor.Magenta);
                    break;

                case AnchorState.Hover:
                    Console.BackgroundColor = ConsoleColor.White;
                    LightNode.PrintWithColor(this.Context.OuterHTML, ConsoleColor.Blue);

                    break;

                case AnchorState.Focus:
                    // Underlined output:
                    LightNode.PrintWithColor("\x1B[4m" + this.Context.OuterHTML + "\x1B[24m", ConsoleColor.Blue);
                    break;

                case AnchorState.Active:
                    LightNode.PrintWithColor(this.Context.OuterHTML, ConsoleColor.Green);
                    break;

                default:
                    LightNode.PrintWithColor(this.Context.OuterHTML, ConsoleColor.Blue);
                    break;
            }
        }
    }
}