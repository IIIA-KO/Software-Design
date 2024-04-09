using DemoClassLibrary;
using _01_ChainOfResponsibility;

namespace DemoConsoleApp.Demos
{
    public class CoRDemo : Demo
    {
        protected override string Name => "Chain of Responsibility";

        protected override void Implementation()
        {
            var level1 = new LevelOneSupport();

            level1.SetNextHandler(new LevelTwoSupport())
                .SetNextHandler(new LevelThreeSupport())
                .SetNextHandler(new LevelFourSupport());

            List<string> issues = [
                "Device is not working",
                "Can't make a call",
                "Problems with the Internet connection",
                "Unknown problem",
                "can't make a call",
                "Hello?",
                "Internal Server Error"
            ];

            issues.ForEach(issue =>
            {
                level1.HandleRequest(new UserRequest { Issue = issue });
            });
        }
    }
}