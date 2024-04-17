using LightHtml.Nodes;

namespace LightHtml.Command
{
    public class AddNodeCommand(LightNode parent, LightNode child) : ICommand
    {
        private readonly LightNode _parent = parent;
        private readonly LightNode _child = child;
        private bool _succeded;

        public void Execute()
        {
            if (this._parent is LightElementNode p)
            {
                p.AddChild(this._child);
                this._succeded = true;
            }
        }

        public void Undo()
        {
            if (!this._succeded)
            {
                return;
            }

            ((LightElementNode)this._parent).Children.Remove(this._child);
        }
    }
}
