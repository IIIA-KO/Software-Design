using LightHtml.Nodes;

namespace LightHtml.Command
{
    public class ChangeTextCommand(LightTextNode node, string oldText, string newText) : ICommand
    {
        private readonly LightTextNode _node = node;
        private readonly string _oldText = oldText;
        private readonly string _newText = newText;

        public void Execute()
        {
            this._node.Text = this._newText;
        }

        public void Undo()
        {
            this._node.Text = this._oldText;
        }
    }
}
