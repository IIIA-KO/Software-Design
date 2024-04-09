namespace _01_ChainOfResponsibility
{
    public class LevelThreeSupport : SupportHandler
    {
        protected override string Message => "Check your Wi-Fi connection or contact your network ISP.";
        protected override int SupportLevel => 3;
        protected override string HandableIssue => "Problems with the Internet connection";

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