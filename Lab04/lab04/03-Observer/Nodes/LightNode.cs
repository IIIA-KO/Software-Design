namespace _03_Observer.Nodes
{
    public abstract class LightNode
    {
        public abstract string OuterHTML { get; }
        public abstract string InnerHTML { get; }

        internal abstract string ToStringImpl(int indent);
    }
}