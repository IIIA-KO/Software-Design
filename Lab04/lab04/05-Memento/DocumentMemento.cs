namespace _05_Memento
{
    public class DocumentMemento(string title, List<string> content) : IDocumentMemento
    {
        public string Title { get; set; } = title;
        public List<string> Content { get; set; } = new List<string>(content);
    }
}