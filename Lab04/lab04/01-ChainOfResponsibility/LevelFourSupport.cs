namespace _01_ChainOfResponsibility
{
    public class LevelFourSupport : SupportHandler
    {
        protected override string Message => "Check the volume on your device for sound effects.";
        protected override int SupportLevel => 4;
        protected override string HandableIssue => "Problems with the sound during a call";

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