namespace _05_Composite.Nodes
{
    public class LightTextNode : LightNode
    {
        public string Text { get; }

        public LightTextNode(string text)
        {
            ArgumentNullException.ThrowIfNull(text);
            Text = text;
        }

        public override string OuterHTML => Text;
        public override string InnerHTML => Text;

        internal override string ToStringImpl(int indent) =>
            new string(' ', indent + 2) + Text + '\n';
    }
}