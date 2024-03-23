using _03_Bridge;

namespace _03_ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var raster = new RasterDrawer();
            var vector = new VerctorDrawer();

            var rasterCircle = new Circle(raster);
            var randomSquare = new Square(Random.Shared.NextDouble() > 0.5 ? raster : vector);
            var vectorTriangle = new Triangle(vector);

            Console.WriteLine($"Raster Circle: {rasterCircle}");
            Console.WriteLine($"Random Square: {randomSquare}");
            Console.WriteLine($"Vector Triangle: {vectorTriangle}");
        }
    }
}