namespace _02_AbstractFactoryClassLibrary.Products
{
    public abstract class Device
    {
        public string Brand { get; }

        public Device(string brand)
        {
            ArgumentException.ThrowIfNullOrEmpty(brand, nameof(brand));
            this.Brand = brand;
        }

        public override string ToString()
        {
            return $"Brand: {this.Brand}, ";
        }
    }
}