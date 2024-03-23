namespace _03_Bridge
{
    public class Square(IDrawer drawer) : Shape(drawer)
    {
        public override string Name => "Square";
    }
}
