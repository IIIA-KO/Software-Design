namespace LightHtml.Nodes
{
    public class LightTextNode : LightNode
    {
        public string Text { get; }

        public LightTextNode(string text)
        {
            ArgumentNullException.ThrowIfNull(text);
            this.Text = text;
        }

        public override string OuterHTML => this.Text;
        public override string InnerHTML => this.Text;

        internal override string ToStringImpl(int indent) =>
            new string(' ', indent + 2) + this.Text + '\n';
    }
}