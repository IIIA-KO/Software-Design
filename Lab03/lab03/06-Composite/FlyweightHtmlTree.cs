namespace _06_Flyweight
{
    public class FlyweightHtmlTree(string[] lines)
    {
        private readonly string[] _lines = lines;

        public void Render()
        {
            var htmlElements = new List<string>();

            bool firstLine = true;

            var cachedTags = new Dictionary<string, FlyweightHtmlElement>();

            static string DetermineHtmlTag(string line)
            {
                if (line.StartsWith(' '))
                {
                    return "blockquote";
                }
                else if (line.Length < 20)
                {
                    return "h2";
                }
                else
                {
                    return "p";
                }
            }

            for (int i = 0; i < _lines.Length; i++)
            {
                string line = _lines[i];
                string htmlTag = DetermineHtmlTag(line);

                if (firstLine)
                {
                    htmlTag = "h1";
                    firstLine = false;
                }

                if (!cachedTags.TryGetValue(htmlTag, out FlyweightHtmlElement? value))
                {
                    value = new FlyweightHtmlElement(htmlTag);
                    cachedTags[htmlTag] = value;
                }

                htmlElements.Add(line.Trim());
            }

            foreach (var line in _lines)
            {
                string htmlTag = DetermineHtmlTag(line);

                if (firstLine)
                {
                    htmlTag = "h1";
                    firstLine = false;
                }

                var element = cachedTags[htmlTag];
                Console.WriteLine(element.Render(line.Trim()));
            }
        }
    }
}