namespace _03_Bridge
{
    public class Circle(IDrawer drawer) : Shape(drawer)
    {
        public override string Name => "Circle";
    }
}
