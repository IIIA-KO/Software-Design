namespace _01_ChainOfResponsibility
{
    public class LevelOneSupport : SupportHandler
    {
        protected override string Message => "Please check that the device is connected to a power source.";
        protected override int SupportLevel => 1;
        protected override string HandableIssue => "Device is not working";

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