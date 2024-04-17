using _04_Strategy;
using LightHtml.Nodes;

namespace LightHtml.Visitor
{
    public class LightHtmlVisitor : IVisitor
    {
        public void Visit(LightTextNode node)
        {
            LightNode.PrintWithColor($"Visiting LightTextNode with content: {node.Text}", ConsoleColor.Green);
        }

        public void Visit(LightElementNode node)
        {
            LightNode.PrintWithColor($"Visiting LightElementNode with tag name: {node.TagName}", ConsoleColor.Yellow);
        }

        public void Visit(LightImage node)
        {
            LightNode.PrintWithColor($"Visiting LightImage with href: {node.Href}", ConsoleColor.Cyan);
        }

        public void Visit(LightAnchor node)
        {
            LightNode.PrintWithColor($"Visiting LightAnchor with href: {node.Href}", ConsoleColor.Magenta);
        }
    }
}