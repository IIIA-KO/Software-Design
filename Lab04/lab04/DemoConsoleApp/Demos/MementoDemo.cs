using _05_Memento;
using DemoClassLibrary;

namespace DemoConsoleApp.Demos
{
    public class MementoDemo : Demo
    {
        protected override string Name => "Memento";

        protected override void Implementation()
        {
            var document = new TextDocument("TextDocument.txt", []);
            var changesManager = new ChangesManager(document);

            Console.WriteLine("Adding some text to the document:");
            document.WriteLine("Line 1");
            changesManager.Save(document.CreateSnapshot());

            document.WriteLine("Line 2");
            changesManager.Save(document.CreateSnapshot());

            document.WriteLine("Line 3");
            changesManager.Save(document.CreateSnapshot());

            Console.WriteLine("Document after chages:");
            Console.WriteLine(document);

            Console.WriteLine("\nUndo 1:");
            changesManager.Undo();
            Console.WriteLine(document);

            Console.WriteLine("\nUndo 2:");
            changesManager.Undo();
            Console.WriteLine(document);

            Console.WriteLine("\nRedo:");
            changesManager.Redo();
            Console.WriteLine(document);
        }
    }
}
