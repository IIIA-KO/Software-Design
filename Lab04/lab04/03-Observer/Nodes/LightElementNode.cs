﻿using System.Text;
using _03_Observer.Enums;

namespace _03_Observer.Nodes
{
    public class LightElementNode : LightNode, ISubject
    {
        protected static int IndentSize = 2;
        private readonly List<IObserver> _observers = [];

        public string TagName { get; }
        public DisplayType Display { get; }
        public ClosingType Closing { get; }
        public List<string> CssClasses { get; }
        public List<LightNode> Children { get; }

        public LightElementNode(string tagName, DisplayType display, ClosingType closing, List<string> cssClasses, List<LightNode> children)
        {
            ArgumentException.ThrowIfNullOrEmpty(tagName, nameof(tagName));

            this.TagName = tagName;
            this.Display = display;
            this.Closing = closing;
            this.CssClasses = cssClasses ?? [];
            this.Children = children ?? []; ;
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

                return sb.ToString();
            }
        }

        internal void AddChild(LightNode node)
        {
            this.Children.Add(node);
        }

        protected virtual string OpeningTag(int indent) =>
            $"{new string(' ', IndentSize * indent)}<{this.TagName} class\"{this.DisplayClass}";

        protected virtual string Classes =>
            this.CssClasses.Count != 0 ? string.Join(", ", this.CssClasses) : string.Empty;

        protected virtual string DisplayClass =>
            this.Display == DisplayType.Block ? "block-element" : "inline-element";

        protected virtual string ClosingTag =>
            this.Closing == ClosingType.Double ? $"</{this.TagName}>\n" : "/>\n";

        internal override string ToStringImpl(int indent)
        {
            var sb = new StringBuilder();

            sb.Append(this.OpeningTag(indent));

            sb.Append(this.Classes);

            if (this.Children.Count != 0)
            {
                sb.Append('\n');

                foreach (LightNode node in this.Children)
                {
                    sb.Append(node.ToStringImpl(indent + 1));
                }

                sb.Append(new string(' ', IndentSize * indent));
            }

            sb.Append(this.ClosingTag);

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
            foreach (var observer in this._observers.Where(o => o.EventName.Equals(eventName)).ToList())
            {
                observer.Update(this);
            }
        }
    }
}