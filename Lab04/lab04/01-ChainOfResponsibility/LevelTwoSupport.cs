namespace _01_ChainOfResponsibility
{
    public class LevelTwoSupport : SupportHandler
    {
        protected override string Message => "Check the signal and the availability of funds on your balance.";
        protected override int SupportLevel => 2;
        protected override string HandableIssue => "Can't make a call";

        public override void HandleRequest(UserRequest request)
        {
            if (request.Issue.Equals(this.HandableIssue, StringComparison.CurrentCultureIgnoreCase))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Level {this.SupportLevel} support: {this.Message}");
                Console.ResetColor();
                return;
            }

            base.HandleRequest(request);
        }
    }
}