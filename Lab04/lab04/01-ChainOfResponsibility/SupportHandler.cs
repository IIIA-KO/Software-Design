namespace _01_ChainOfResponsibility
{
    public abstract class SupportHandler : ISupportHandler
    {
        protected abstract string Message { get; }
        protected abstract int SupportLevel { get; }
        protected abstract string HandableIssue { get; }

        private SupportHandler? _nextHandler;

        public SupportHandler SetNextHandler(SupportHandler nextHandler)
        {
            this._nextHandler = nextHandler;
            return this._nextHandler;
        }

        public virtual void HandleRequest(UserRequest request)
        {
            if (this._nextHandler == null)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("There is no support for this issue.");
                Console.ResetColor();
                return;
            }
            else
            {
                this._nextHandler.HandleRequest(request);
            }
        }
    }
}