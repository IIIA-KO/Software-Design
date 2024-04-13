using LightHtml.Nodes;

namespace LightHtml.Iterator
{
    public class HtmlDocument(LightNode root, IEnumerator<LightNode> enumerator)
    {
        private readonly LightNode _root = root;

        public IEnumerator<LightNode> Enumerator { get; set; } = enumerator;

        public IEnumerator<LightNode> GetEnumerator() => this.Enumerator;
    }
}