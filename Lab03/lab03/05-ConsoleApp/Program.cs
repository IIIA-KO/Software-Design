using _05_Composite.Enums;
using _05_Composite.Nodes;
using _05_Composite.Builder;

namespace _05_ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
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

            Console.WriteLine("Inner HTML:\n" + table.InnerHTML);
            Console.WriteLine("Outer HTML:\n" + table.OuterHTML);
        }
    }
}