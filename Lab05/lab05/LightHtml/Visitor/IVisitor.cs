using _04_Strategy;
using LightHtml.Nodes;

namespace LightHtml.Visitor
{
    public interface IVisitor
    {
        void Visit(LightTextNode node);
        void Visit(LightElementNode node);
        void Visit(LightImage node);
        void Visit(LightAnchor node);
    }
}