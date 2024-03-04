using _02_AbstractFactoryClassLibrary.Products;

namespace _02_AbstractFactoryClassLibrary.Factories
{
    public class IProneFactory : IDeviceFactory
    {
        public string Brand => "iProne";

        public Ebook CreateEbook()
        {
            return new Ebook(this.Brand, 6, true, true);
        }

        public Laptop CreateLaptop()
        {
            return new Laptop(this.Brand, "M3", "Retina Display", false);
        }

        public Netbook CreateNetbook()
        {
            return new Netbook(this.Brand, "Intel Core i7", 512, 4);
        }

        public Smartphone CreateSmartphone()
        {
            return new Smartphone(this.Brand, "IOS", "+3801234567", true);
        }
    }
}