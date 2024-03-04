namespace _02_AbstractFactoryClassLibrary.Products
{
    public class Laptop : Device
    {
        public string GraphicsCard { get; }
        public string ScreenResolution { get; }
        public bool HasTouchScreen { get; }

        public Laptop(string brand, string gpu, string resolution, bool hasTouch) : base(brand)
        {
            ArgumentException.ThrowIfNullOrEmpty(nameof(gpu));

            this.GraphicsCard = gpu;
            this.ScreenResolution = resolution;
            this.HasTouchScreen = hasTouch;
        }

        public override string ToString()
        {
            return base.ToString() + $"GPU: {this.GraphicsCard}, Screen resolution {this.ScreenResolution}, Has touch screen: {this.HasTouchScreen}";
        }
    }
}