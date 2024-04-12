using _04_Strategy;
using DemoClassLibrary;
using LightHtml.Strategy;

namespace DemoConsoleApp.Demos
{
    public class StrategyDemo : Demo
    {
        protected override string Name => "Strategy";

        protected override void Implementation()
        {
            List<IImageLoadStrategy> strategies = [new FileImageLoad(), new NetworkImageLoad()];

            string networkHref = "https://buffer.com/library/content/images/2023/09/instagram-image-size.jpg";
            string fileHref = "image.png";

            var networkImageTag = new LightImage(strategies[1], networkHref);

            Console.WriteLine("Image from network:");
            Console.WriteLine(networkImageTag.OuterHTML);

            Console.WriteLine("Getting image from Internet and saving to file.");
            var image = networkImageTag.LoadImageAsync().Result;
            File.WriteAllBytes(fileHref, image);

            var fileImageTag = new LightImage(strategies[0], fileHref);
            Console.WriteLine("Image from file:");
            Console.WriteLine(fileImageTag.OuterHTML);
        }
    }
}