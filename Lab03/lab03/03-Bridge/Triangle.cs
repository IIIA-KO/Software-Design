namespace _03_Bridge
{
    public class Triangle(IDrawer drawer) : Shape(drawer)
    {
        public override string Name => "Triangle";
    }
}