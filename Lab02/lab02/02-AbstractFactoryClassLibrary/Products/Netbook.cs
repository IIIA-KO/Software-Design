namespace _02_AbstractFactoryClassLibrary.Products
{
    public class Netbook : Device
    {
        public string Processor { get; }
        public int StorageSizeGB { get; }
        public int RamSizeGB { get; }

        public Netbook(string brand, string cpu, int storage, int ram) : base(brand)
        {
            ArgumentException.ThrowIfNullOrEmpty(nameof(cpu));

            this.Processor = cpu;
            this.RamSizeGB = ram;
            this.StorageSizeGB = storage;
        }

        public override string ToString()
        {
            return base.ToString() + $"CPU: {this.Processor}, Storage: {this.StorageSizeGB}GB, RAM: {this.RamSizeGB}GB";
        }
    }
}