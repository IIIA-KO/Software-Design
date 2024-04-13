using LightHtml.Nodes;
using System.Collections;

namespace LightHtml.Iterator
{
    public class HtmlBreadthFirstIterator : IEnumerator<LightNode>
    {
        private readonly Queue<LightNode> _queue = new();

        public HtmlBreadthFirstIterator(LightNode rootNode)
        {
            this._queue.Enqueue(rootNode);
        }

        public LightNode Current => this._queue.Peek();

        object IEnumerator.Current => this.Current;

        // no need to implement:
        public void Dispose() { }

        public bool MoveNext()
        {
            if (this._queue.Count == 0)
                return false;

            var currentNode = this._queue.Dequeue();
            
            var childNodes = GetChildNodes(currentNode);
            foreach (var child in childNodes)
            {
                this._queue.Enqueue(child);
            }

            return this._queue.Count > 0;
        }

        public void Reset()
        {
            throw new NotSupportedException();
        }

        private IEnumerable<LightNode> GetChildNodes(LightNode node)
        {
            if (node is LightElementNode elementNode)
            {
                return elementNode.Children;
            }

            return [];
        }
    }
}
