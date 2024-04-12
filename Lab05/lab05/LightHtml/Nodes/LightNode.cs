namespace LightHtml.Nodes
{
    public abstract class LightNode
    {
        public abstract string OuterHTML { get; }
        public abstract string InnerHTML { get; }

        internal abstract string ToStringImpl(int indent);

        public virtual void OnCreated() { }
        public virtual void OnInserted(LightNode parent) { }
        public virtual void OnRemoved() { }
        public virtual void OnStylesApplied(List<string> styles) { }
        public virtual void OnTextRendered() { }

        protected static void PrintWithColor(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message, color);
            Console.ResetColor();
        }
    }
}