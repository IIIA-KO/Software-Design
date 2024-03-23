namespace _06_Flyweight
{
    internal class FlyweightHtmlElement(string tagName)
    {
        public string TagName { get; } = tagName;

        public string Render(string content)
        {
            return $"<{TagName}>{content}</{TagName}>";
        }
    }
}