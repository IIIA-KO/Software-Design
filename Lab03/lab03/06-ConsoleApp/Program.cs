using _06_Flyweight;

namespace _06_ConsoleApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string bookText = await ReadText();

            // ~2.5MB:
            var lightHtml = HtmlConverter.ConvertTextToLightHtml(bookText);
            Console.WriteLine($"Light Html Tree kept {BytesToMegabytes(lightHtml.Item2)} MB in memory");

            // ~0.5MB:
            var flyweightHtml = HtmlConverter.ConvertTextToFlyweightHtml(bookText);
            Console.WriteLine($"Flyweight Html Tree kept {BytesToMegabytes(flyweightHtml.Item2)} MB in memory\n");

            // Output:
            Console.WriteLine(lightHtml.Item1.OuterHTML);
            flyweightHtml.Item1.Render();
        }

        private static double BytesToMegabytes(long bytes)
        {
            return (bytes / 1024f) / 1024f;
        }

        private async static Task<string> ReadText()
        {
            var client = new HttpClient();

            var responce = await client.GetAsync("https://www.gutenberg.org/cache/epub/1513/pg1513.txt");

            return await responce.Content.ReadAsStringAsync();
        }
    }
}