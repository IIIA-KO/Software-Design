namespace LightHtml.Command
{
    public class CommandInvoker
    {
        private readonly Stack<ICommand> _undoStack = [];
        private readonly Stack<ICommand> _redoStack = [];

        public void ExecuteCommand(ICommand command)
        {
            command.Execute();
            this._undoStack.Push(command);
            this._redoStack.Clear();
        }

        public void UndoCommand()
        {
            if (this._undoStack.Count > 0)
            {
                var command = this._undoStack.Pop();
                command.Undo();
                this._redoStack.Push(command);
            }
        }
    }
}
