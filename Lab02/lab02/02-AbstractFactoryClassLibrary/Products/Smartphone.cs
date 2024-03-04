namespace _02_AbstractFactoryClassLibrary.Products
{
    public class Smartphone : Device
    {
        public string OperatingSystem { get; }
        public string PhoneNumber { get; }
        public bool HasNFC { get; }

        public Smartphone(string brand, string os, string number, bool hasNfc) : base(brand)
        {
            ArgumentException.ThrowIfNullOrEmpty(nameof(os));

            this.OperatingSystem = os;
            this.PhoneNumber = number;
            this.HasNFC = hasNfc;
        }

        public override string ToString()
        {
            return base.ToString() + $"OS: {this.OperatingSystem}, Phone number: {this.PhoneNumber}, Has NFC: {this.HasNFC}";
        }
    }
}