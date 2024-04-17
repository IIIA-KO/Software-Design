using LightHtml.Enums;
using LightHtml.Nodes;
using LightHtml.Visitor;
using LightHtml.Strategy;

namespace _04_Strategy
{
    public class LightImage(IImageLoadStrategy loadStrategy, string href) 
        : LightElementNode("img", DisplayType.Inline, ClosingType.Single, [], []), IDisposable
    {
        private readonly IImageLoadStrategy _loadStrategy = loadStrategy;

        public string Href { get; set; } = href;

        protected override string OpeningSegment(int indent) =>
           $"{new string(' ', IndentSize * indent)}<{this.TagName} href=\"{this.Href}\" class\"{this.DisplaySegment}";

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public async Task<byte[]> LoadImageAsync() =>
            await this._loadStrategy.LoadImageAsync(this.Href);

        public override void OnCreated() =>
            PrintWithColor($"Image Node {this.GetHashCode()} was creted!", ConsoleColor.Cyan);

        public override void OnRemoved() =>
            PrintWithColor($"Image Node {this.GetHashCode()} was removed!", ConsoleColor.Cyan);

        public void Dispose() =>
            this.OnRemoved();
    }
}