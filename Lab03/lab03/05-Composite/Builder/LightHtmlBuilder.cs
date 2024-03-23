using _05_Composite.Enums;
using _05_Composite.Nodes;

namespace _05_Composite.Builder
{
    public class LightHtmlBuilder : ILightHtmlBuilder
    {
        private string _tagName;
        private DisplayType _display;
        private ClosingType _closing;
        private List<string> _cssClasses;
        private List<LightNode> _children;

        private LightHtmlBuilder(string tagName)
        {
            this._tagName = tagName;
            this._cssClasses = new List<string>();
            this._children = new List<LightNode>();
        }

        public static IExpectsDisplayType WithTagName(string tagName)
        {
            return new LightHtmlBuilder(tagName);
        }

        public IExpectsClosingType WithDisplay(DisplayType display)
        {
            this._display = display;
            return this;
        }

        public IExpectsCssClasses WithClosing(ClosingType closing)
        {
            this._closing = closing;
            return this;
        }

        public ILightHtmlBuilder WithChild(LightNode child)
        {
            this._children.Add(child);
            return this;
        }

        public IExpectsChildren WithCssClasses(List<string> cssClasses)
        {
            this._cssClasses.AddRange(cssClasses);
            return this;
        }

        public LightElementNode Build()
        {
            return new LightElementNode(_tagName, _display, _closing, _cssClasses, _children);
        }
    }
}
