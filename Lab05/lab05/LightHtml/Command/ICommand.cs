namespace LightHtml.Command
{
    public interface ICommand
    {
        void Execute();
        void Undo();
    }
}
