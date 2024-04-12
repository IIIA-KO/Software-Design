using LightHtml.Enums;
using LightHtml.Nodes;
using LightHtml.Strategy;

namespace _04_Strategy
{
    public class LightImage : LightElementNode, IDisposable
    {
        private readonly IImageLoadStrategy _loadStrategy;

        public LightImage(IImageLoadStrategy loadStrategy, string href) : base("img", DisplayType.Inline, ClosingType.Single, [], [])
        {
            this._loadStrategy = loadStrategy;
            this.Href = href;
        }

        public string Href { get; set; }

        protected override string OpeningTag(int indent) =>
           $"{new string(' ', IndentSize * indent)}<{this.TagName} href=\"{this.Href}\" class\"{this.DisplayClass}";

        public async Task<byte[]> LoadImageAsync()
        {
            return await this._loadStrategy.LoadImageAsync(this.Href);
        }

        public override void OnCreated() =>
            PrintWithColor($"Image Node {this.GetHashCode()} was creted!", ConsoleColor.Cyan);

        public override void OnRemoved() =>
            PrintWithColor($"Image Node {this.GetHashCode()} was removed!", ConsoleColor.Cyan);

        public void Dispose()
        {
            this.OnRemoved();
        }
    }
}