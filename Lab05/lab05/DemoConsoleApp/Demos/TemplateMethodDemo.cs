using _04_Strategy;
using LightHtml.Nodes;
using LightHtml.Enums;
using DemoClassLibrary;
using LightHtml.Builder;
using LightHtml.Strategy;

namespace DemoConsoleApp.Demos
{
    public class TemplateMethodDemo : Demo
    {
        protected override string Name => "Template Method";

        protected override void Implementation()
        {
            var textNode = new LightTextNode("Sample text");
            Console.WriteLine("Text Node InnerHTML:");
            Console.WriteLine(textNode.InnerHTML);
            Console.WriteLine();

            var elementNode = LightHtmlBuilder
                .WithTagName("div")
                .WithDisplay(DisplayType.Block)
                .WithClosing(ClosingType.Double)
                .WithCssClasses(["class1", "class2", "class3"])
                .WithChild(textNode)
                .Build();
            Console.WriteLine("Element Node OuterHTML with Child Text Node:");
            Console.WriteLine(elementNode.OuterHTML);
            Console.WriteLine();

            using var imageNode = new LightImage(new MockImageLoadStrategy(), "image.jpg");
            Console.WriteLine("Image Node OuterHTML:");
            Console.WriteLine(imageNode.OuterHTML);
        }
    }

    internal class MockImageLoadStrategy : IImageLoadStrategy
    {
        public Task<byte[]> LoadImageAsync(string href)
        {
            return Task.FromResult(Array.Empty<byte>());
        }
    }
}