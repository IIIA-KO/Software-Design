using LightHtml.Enums;
using LightHtml.Nodes;

namespace LightHtml.Builder
{
    public class LightHtmlBuilder : ILightHtmlBuilder
    {
        private DisplayType _display;
        private ClosingType _closing;
        private readonly string _tagName;
        private readonly List<string> _cssClasses;
        private readonly List<LightNode> _children;

        private LightHtmlBuilder(string tagName)
        {
            this._tagName = tagName;
            this._cssClasses = [];
            this._children = [];
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
            return new LightElementNode(
                this._tagName,
                this._display,
                this._closing,
                this._cssClasses,
                this._children);
        }
    }
}