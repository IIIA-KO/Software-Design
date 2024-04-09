namespace _05_Memento
{
    public interface IDocumentMemento
    {
        string Title { get; set; }
        List<string> Content { get; set; }
    }
}