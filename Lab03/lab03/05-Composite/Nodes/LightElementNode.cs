using System.Text;
using _05_Composite.Enums;

namespace _05_Composite.Nodes
{
    public class LightElementNode : LightNode
    {
        public string TagName { get; }
        public DisplayType Display { get; }
        public ClosingType Closing { get; }
        public List<string> CssClasses { get; }
        public List<LightNode> Children { get; }

        private const int INDENT_SIZE = 2;

        public LightElementNode(string tagName, DisplayType display, ClosingType closing, List<string> cssClasses, List<LightNode> children)
        {
            ArgumentException.ThrowIfNullOrEmpty(tagName, nameof(tagName));

            this.TagName = tagName;
            this.Display = display;
            this.Closing = closing;
            this.CssClasses = cssClasses ?? [];
            this.Children = children ?? []; ;
        }

        public override string OuterHTML
        {
            get
            {
                return ToStringImpl(0);
            }
        }

        public override string InnerHTML
        {
            get
            {
                var sb = new StringBuilder();

                foreach (var child in this.Children)
                {
                    sb.Append(child.OuterHTML);
                }

                return sb.ToString();
            }
        }

        internal void AddChild(LightNode node)
        {
            this.Children.Add(node);
        }

        internal override string ToStringImpl(int indent)
        {
            var sb = new StringBuilder();
            var indentation = new string(' ', INDENT_SIZE * indent);

            sb.Append($"{indentation}<{this.TagName}");

            sb.Append(this.Display == DisplayType.Block
                        ? " class=\"block-element"
                        : " class=\"inline-element");

            if (this.CssClasses.Count != 0)
            {
                sb.Append($" {string.Join(", ", this.CssClasses)}");
            }

            sb.Append("\">");

            if (this.Children.Count != 0)
            {
                sb.Append('\n');

                foreach (var node in this.Children)
                {
                    sb.Append(node.ToStringImpl(indent + 1));
                }

                sb.Append(indentation);
            }

            sb.Append(this.Closing == ClosingType.Double
                ? $"</{this.TagName}>\n"
                : "/>\n");


            return sb.ToString();
        }
    }
}