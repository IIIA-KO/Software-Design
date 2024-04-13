using LightHtml.Enums;
using LightHtml.Nodes;
using DemoClassLibrary;
using LightHtml.Builder;
using LightHtml.Iterator;

namespace DemoConsoleApp.Demos
{
    public class IteratorDemo : Demo
    {
        protected override string Name => "Iterator";

        protected override void Implementation()
        {
            var table = LightHtmlBuilder
            .WithTagName("table")
            .WithDisplay(DisplayType.Block)
            .WithClosing(ClosingType.Double)
            .WithCssClasses(["table", "custom"])
            .WithChild(LightHtmlBuilder
                .WithTagName("tr")
                .WithDisplay(DisplayType.Block)
                .WithClosing(ClosingType.Double)
                .WithCssClasses(["class1, class2, class3"])
                .WithChild(LightHtmlBuilder
                    .WithTagName("th")
                    .WithDisplay(DisplayType.Block)
                    .WithClosing(ClosingType.Single)
                    .WithCssClasses([])
                    .WithChild(new LightTextNode("Header 1"))
                    .Build())
                .WithChild(LightHtmlBuilder
                    .WithTagName("th")
                    .WithDisplay(DisplayType.Inline)
                    .WithClosing(ClosingType.Single)
                    .WithCssClasses(["class1, class2"])
                    .WithChild(new LightTextNode("Header 2"))
                    .Build())
                .Build())
            .WithChild(LightHtmlBuilder
                .WithTagName("tr")
                .WithDisplay(DisplayType.Inline)
                .WithClosing(ClosingType.Double)
                .WithCssClasses(["class1, class2"])
                .WithChild(LightHtmlBuilder
                    .WithTagName("td")
                    .WithDisplay(DisplayType.Block)
                    .WithClosing(ClosingType.Single)
                    .WithCssClasses(["class1, class2"])
                    .WithChild(new LightTextNode("Data 1"))
                    .Build())
                .WithChild(LightHtmlBuilder
                    .WithTagName("td")
                    .WithDisplay(DisplayType.Block)
                    .WithClosing(ClosingType.Double)
                    .WithCssClasses([])
                    .WithChild(new LightTextNode("Data 2"))
                    .Build())
                .Build())
            .Build();

            Console.WriteLine("Outer HTML:");
            Console.WriteLine(table.OuterHTML);

            var document = new HtmlDocument(table, new HtmlDepthFirstIterator(table));
            Console.WriteLine("\n\nDepth:");
            foreach (var node in document)
            {
                Console.WriteLine(node.OuterHTML);
            }

            document.Enumerator = new HtmlBreadthFirstIterator(table);
            Console.WriteLine("\n\nBreadth:");
            foreach (var node in document)
            {
                Console.WriteLine(node.OuterHTML);
            }
        }
    }
}
