using LightHtml.Nodes;
using System.Collections;

namespace LightHtml.Iterator
{
    public class HtmlDepthFirstIterator : IEnumerator<LightNode>
    {
        private readonly Stack<LightNode> _stack = new();

        public HtmlDepthFirstIterator(LightNode rootNode)
        {
            this._stack.Push(rootNode);
        }

        public LightNode Current => this._stack.Peek();

        object IEnumerator.Current => this.Current;

        // no need to implement:
        public void Dispose() { }

        public bool MoveNext()
        {
            if (this._stack.Count == 0)
                return false;

            var currentNode = _stack.Pop();

            var childNodes = GetChildNodes(currentNode);
            foreach (var child in childNodes.Reverse())
            {
                this._stack.Push(child);
            }

            return this._stack.Count > 0;
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