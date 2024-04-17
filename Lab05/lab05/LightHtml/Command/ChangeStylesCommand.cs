using LightHtml.Nodes;

namespace LightHtml.Command
{
    public class ChangeStylesCommand(LightElementNode node, List<string> newStyles, List<string> oldStyles) : ICommand
    {
        private readonly LightElementNode _node = node;
        private readonly List<string> _newStyles = newStyles;
        private readonly List<string> _oldStyles = oldStyles;

        public void Execute()
        {
            this._node.CssClasses = this._newStyles;
        }

        public void Undo()
        {
            this._node.CssClasses = this._oldStyles;
        }
    }
}