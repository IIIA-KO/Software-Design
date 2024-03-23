namespace _03_Bridge
{
    public abstract class Shape(IDrawer drawer)
    {
        private readonly IDrawer _drawer = drawer;

        public abstract string Name { get; }

        public override string ToString()
        {
            return $"Drawing {this.Name} as {this._drawer.DrawAs}";
        }
    }
}