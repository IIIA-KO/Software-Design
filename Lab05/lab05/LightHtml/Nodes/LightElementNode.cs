using System.Text;
using LightHtml.Enums;
using LightHtml.Visitor;
using LightHtml.Observer;

namespace LightHtml.Nodes
{
    public class LightElementNode : LightNode, ISubject
    {
        private readonly List<IObserver> _observers = [];

        public string TagName { get; }
        public DisplayType Display { get; }
        public ClosingType Closing { get; }
        public List<string> CssClasses { get; set; }
        public List<LightNode> Children { get; }

        public LightElementNode(
            string tagName,
            DisplayType display,
            ClosingType closing,
            List<string> cssClasses,
            List<LightNode> children)
        {
            ArgumentException.ThrowIfNullOrEmpty(tagName, nameof(tagName));

            this.TagName = tagName;
            this.Display = display;
            this.Closing = closing;
            this.CssClasses = cssClasses ?? [];
            this.Children = children ?? [];

            this.OnCreated();
            this.OnStylesApplied(this.CssClasses);
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
            foreach (var child in Children)
            {
                child.Accept(visitor);
            }
        }

        public override string OuterHTML => ToStringImpl(0);

        public override string InnerHTML
        {
            get
            {
                var sb = new StringBuilder();

                foreach (var child in this.Children)
                {
                    sb.Append(child.OuterHTML);
                }

                this.OnTextRendered();
                return sb.ToString();
            }
        }

        internal void AddChild(LightNode node)
        {
            node.OnInserted(this);
            this.Children.Add(node);
        }

        protected virtual string OpeningSegment(int indent) =>
            $"{new string(' ', IndentSize * indent)}<{this.TagName} class=\"{this.DisplaySegment} ";

        protected virtual string CssClassesSegment =>
            this.CssClasses.Count != 0 ? string.Join(", ", this.CssClasses) : string.Empty;

        protected virtual string DisplaySegment =>
            this.Display == DisplayType.Block ? "block-element" : "inline-element";

        protected virtual string ClosingSegment =>
            this.Closing == ClosingType.Double ? $"</{this.TagName}>\n" : "/>\n";

        internal override string ToStringImpl(int indent)
        {
            var sb = new StringBuilder();

            sb.Append(this.OpeningSegment(indent));

            sb.Append(this.CssClassesSegment).Append("\">");

            if (this.Children.Count != 0)
            {
                sb.Append('\n');

                foreach (LightNode node in this.Children)
                {
                    sb.Append(node.ToStringImpl(indent + 1));
                }

                sb.Append(new string(' ', IndentSize * indent));
            }

            sb.Append(this.ClosingSegment);

            return sb.ToString();
        }

        public void Attach(IObserver observer)
        {
            this._observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            this._observers.Remove(observer);
        }

        public void Notify(string eventName)
        {
            foreach (var observer in this._observers
                .Where(o => o.EventName.Equals(eventName))
                .ToList())
            {
                observer.Update(this);
            }
        }

        public override void OnCreated() =>
            PrintWithColor($"Element Node {this.GetHashCode()} was creted!", ConsoleColor.DarkYellow);

        public override void OnStylesApplied(List<string> styles)
        {
            if (this.CssClasses.Count != 0)
            {
                PrintWithColor($"Element Node {this.GetHashCode()} was applied with styles: " +
                    $"{string.Join(", ", styles)}", ConsoleColor.DarkYellow);
            }
        }

        public override void OnTextRendered() =>
            PrintWithColor($"Text \"{this.InnerHTML}\" was rendered!", ConsoleColor.DarkYellow);
    }
}