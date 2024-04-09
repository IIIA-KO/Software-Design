namespace _05_Memento
{
    public class ChangesManager
    {
        private readonly List<IDocumentMemento> _changes = new List<IDocumentMemento>();
        private int _current;
        private readonly TextDocument _document;

        public ChangesManager(TextDocument document)
        {
            this._document = document;
            Save(this._document.CreateSnapshot());
        }

        public void Save(IDocumentMemento memento)
        {
            this._changes.Add(memento);
            this._current = this._changes.Count - 1;
        }

        public void Restore(IDocumentMemento memento)
        {
            this._document.Restore(memento);
        }

        public TextDocument Undo()
        {
            if (this._current > 0)
            {
                this._current--;
                Restore(this._changes[this._current]);
            }
            return this._document;
        }

        public TextDocument Redo()
        {
            if (this._current + 1 < this._changes.Count)
            {
                this._current++;
                Restore(this._changes[this._current]);
            }
            return this._document;
        }

        public override string ToString()
        {
            return this._document.ToString();
        }
    }
}