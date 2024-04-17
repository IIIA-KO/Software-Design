using LightHtml.Visitor;

namespace LightHtml.Nodes
{
    public class LightTextNode : LightNode
    {
        public string Text { get; set; }

        public LightTextNode(string text)
        {
            ArgumentNullException.ThrowIfNull(text);
            this.Text = text;

            this.OnCreated();
        }

        public override string OuterHTML => this.InnerHTML;

        public override string InnerHTML
        {
            get
            {
                this.OnTextRendered();
                return this.Text;
            }
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        internal override string ToStringImpl(int indent) =>
            new string(' ', indent + 2) + this.Text + '\n';

        public override void OnCreated() =>
            PrintWithColor($"Text Node {this.GetHashCode()} was creted!", ConsoleColor.DarkGreen);

        public override void OnTextRendered() =>
            PrintWithColor($"Text \"{this.Text}\" was rendered!", ConsoleColor.DarkGreen);

        public override void OnInserted(LightNode node) =>
            PrintWithColor($"Text Node {this.GetHashCode()} was inserted to another {node.GetHashCode()} node!", ConsoleColor.DarkGreen);
    }
}