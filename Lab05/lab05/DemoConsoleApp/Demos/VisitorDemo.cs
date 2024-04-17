using _04_Strategy;
using LightHtml.Enums;
using LightHtml.Nodes;
using LightHtml.State;
using DemoClassLibrary;
using LightHtml.Visitor;
using LightHtml.Builder;

namespace DemoConsoleApp.Demos
{
    public class VisitorDemo : Demo
    {
        protected override string Name => "Visitor";

        protected override void Implementation()
        {
            var parentNode = LightHtmlBuilder
                .WithTagName("div")
                .WithDisplay(DisplayType.Inline)
                .WithClosing(ClosingType.Double)
                .WithCssClasses(["class1, class 2"])
                .WithChild(new LightTextNode("Sample Text"))
                .WithChild(new LightAnchor(new StateMachine(), AnchorState.Default, "https://refactoring.guru/design-patterns/state/csharp/example"))
                .WithChild(new LightImage(new MockImageLoadStrategy(), "https://host.com"))
            .Build();

            var visitor = new LightHtmlVisitor();
            
            parentNode.Accept(visitor);
        }
    }
}
