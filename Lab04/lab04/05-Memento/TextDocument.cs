namespace _05_Memento
{
    public class TextDocument(string title, List<string> content)
    {
        public string Title { get; set; } = title;
        public List<string> Content { get; set; } = new List<string>(content);

        public void WriteLine(string text)
        {
            this.Content.Add(text);
        }

        public IDocumentMemento CreateSnapshot()
        {
            return new DocumentMemento(this.Title, this.Content);
        }

        public override string ToString()
        {
            return this.Title + Environment.NewLine + string.Join(Environment.NewLine, Content);
        }

        public void Restore(IDocumentMemento memento)
        {
            if (memento != null)
            {
                this.Title = memento.Title;
                this.Content = new List<string>(memento.Content);
            }
        }
    }
}