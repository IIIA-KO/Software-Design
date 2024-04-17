using LightHtml.Enums;
using LightHtml.Nodes;
using DemoClassLibrary;
using LightHtml.Builder;
using LightHtml.Command;

namespace DemoConsoleApp.Demos
{
    public class CommandDemo : Demo
    {
        protected override string Name => "Command";

        protected override void Implementation()
        {   
            var parentNode = LightHtmlBuilder
                .WithTagName("div")
                .WithDisplay(DisplayType.Inline)
                .WithClosing(ClosingType.Double)
                .WithCssClasses(["class1, class 2"])
                .Build();

            var childNode = new LightTextNode("Sample text.");
         
            var commandInvoker = new CommandInvoker();

            var addNodeCommand = new AddNodeCommand(parentNode, childNode);
            var changeTextCommand = new ChangeTextCommand(childNode, childNode.Text, "New sample text.");
            var changeStylesCommand = new ChangeStylesCommand(parentNode, ["bold, italic"], parentNode.CssClasses);

            // Unsuccessful command invocation:
            AddChildNodeCommandDemo(childNode, addNodeCommand, commandInvoker);
            Console.WriteLine("\n\n");

            // Successful command invocation:
            Console.WriteLine("\n\n");

            AddChildNodeCommandDemo(parentNode, addNodeCommand, commandInvoker);
            Console.WriteLine("\n\n");
            
            ChangeTextCommandDemo(childNode, changeTextCommand, commandInvoker);
            Console.WriteLine("\n\n");

            ChangeStylesCommandDemo(parentNode,  changeStylesCommand, commandInvoker);
        }

        public static void AddChildNodeCommandDemo(LightNode node, AddNodeCommand command, CommandInvoker invoker)
        {
            Console.WriteLine("Node before adding child node:");
            Console.WriteLine(node.OuterHTML);

            invoker.ExecuteCommand(command);

            Console.WriteLine("Node after adding child node:");
            Console.WriteLine(node.OuterHTML);

            Console.WriteLine("Undoing adding child node...");
            
            invoker.UndoCommand();

            Console.WriteLine("Node after undoing command:");
            Console.WriteLine(node.OuterHTML);
        }

        public static void ChangeTextCommandDemo(LightTextNode node, ChangeTextCommand command, CommandInvoker invoker)
        {
            Console.WriteLine("Node before changing text:");
            Console.WriteLine(node.OuterHTML);

            invoker.ExecuteCommand(command);

            Console.WriteLine("Node adter changing text:");
            Console.WriteLine(node.OuterHTML);

            Console.WriteLine("Undoing changing text command...");
            invoker.UndoCommand();

            Console.WriteLine("Node after undoing command:");
            Console.WriteLine(node.OuterHTML);
        }

        public static void ChangeStylesCommandDemo(LightElementNode node, ChangeStylesCommand command, CommandInvoker invoker)
        {
            Console.WriteLine("Node before changing styles node:");
            Console.WriteLine(node.OuterHTML);

            invoker.ExecuteCommand(command);

            Console.WriteLine("Node after changing styles node:");
            Console.WriteLine(node.OuterHTML);

            Console.WriteLine("Undoing changing styles node...");

            invoker.UndoCommand();

            Console.WriteLine("Node after undoing command:");
            Console.WriteLine(node.OuterHTML);
        }
    }
}