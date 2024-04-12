using LightHtml.Enums;
using LightHtml.Nodes;
using DemoClassLibrary;
using LightHtml.Builder;
using LightHtml.Observer;

namespace DemoConsoleApp.Demos
{
    public class ObserverDemo : Demo
    {
        protected override string Name => "Observer";

        protected override void Implementation()
        {
            var div = LightHtmlBuilder
                .WithTagName("div")
                .WithDisplay(DisplayType.Block)
                .WithClosing(ClosingType.Double)
                .WithCssClasses([])
                .WithChild(new LightTextNode("Div Content"))
                .Build();

            Console.WriteLine(div.OuterHTML);

            Console.WriteLine("No events attached:");
            ObserveEvents(div);

            var clickObserver = new Observer("onClick", div =>
            {
                PrintWithColor("Div element reacts to click event!", ConsoleColor.Magenta);
            });
            div.Attach(clickObserver);

            Console.WriteLine("One event attached:");
            ObserveEvents(div);

            var mouseoverObserver = new Observer("mouseover", div =>
            {
                PrintWithColor("Div element reacts to mouseover event!", ConsoleColor.DarkGreen);
            });
            div.Attach(mouseoverObserver);

            Console.WriteLine("Two events attached:");
            ObserveEvents(div);

            div.Detach(clickObserver);

            Console.WriteLine("One event detached:");
            ObserveEvents(div);
        }

        private static void PrintWithColor(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        private static void ObserveEvents(LightElementNode node)
        {
            node.Notify("onClick");
            node.Notify("mouseover");
        }
    }
}
