using _03_Observer.Enums;
using _03_Observer.Nodes;

namespace _04_Strategy
{
    public class LightImage(IImageLoadStrategy loadStrategy, string href)
        : LightElementNode("img", DisplayType.Inline, ClosingType.Single, [], [])
    {
        private readonly IImageLoadStrategy _loadStrategy = loadStrategy;

        public string Href { get; set; } = href;

        protected override string OpeningTag(int indent) =>
           $"{new string(' ', IndentSize * indent)}<{this.TagName} href=\"{this.Href}\" class\"{this.DisplayClass}";

        public async Task<byte[]> LoadImageAsync()
        {
            return await this._loadStrategy.LoadImageAsync(this.Href);
        }
    }
}