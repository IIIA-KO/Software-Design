using LightHtml.Nodes;

namespace LightHtml.Iterator
{
    public class HtmlDocument(IEnumerator<LightNode> enumerator)
    {
        public IEnumerator<LightNode> Enumerator { get; set; } = enumerator;
        public IEnumerator<LightNode> GetEnumerator() => this.Enumerator;
    }
}