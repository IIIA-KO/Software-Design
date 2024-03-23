using _05_Composite.Nodes;
using _05_Composite.Enums;
using _05_Composite.Builder;

namespace _06_Flyweight
{
    public static class HtmlConverter
    {
        public static (FlyweightHtmlTree, long) ConvertTextToFlyweightHtml(string text)
        {
            long memoryBefore = GC.GetTotalMemory(false);

            var lines = text.Split('\n');
            var flyweightHtmlTree = new FlyweightHtmlTree(lines);

            return (flyweightHtmlTree, GC.GetTotalMemory(false) - memoryBefore);
        }

        public static (LightElementNode, long) ConvertTextToLightHtml(string text)
        {
            long memoryBefore = GC.GetTotalMemory(false);

            var builder = LightHtmlBuilder
                .WithTagName("h1")
                .WithDisplay(DisplayType.Block)
                .WithClosing(ClosingType.Double)
                .WithCssClasses([]);

            var lines = text.Split('\n');

            foreach (var line in lines)
            {
                string tagName;
                if (line.StartsWith(' '))
                {
                    tagName = "blockquote";
                }
                else if (line.Length < 20)
                {
                    tagName = "h2";
                }
                else
                {
                    tagName = "p";
                }

                builder
                    .WithChild(LightHtmlBuilder
                    .WithTagName(tagName)
                    .WithDisplay(DisplayType.Block)
                    .WithClosing(ClosingType.Double)
                    .WithCssClasses([])
                    .WithChild(new LightTextNode(line.Trim()))
                    .Build()
                );
            }

            return (builder.WithChild(new LightTextNode(string.Empty)).Build(), GC.GetTotalMemory(false) - memoryBefore);
        }
    }
}