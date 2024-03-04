using _02_AbstractFactoryClassLibrary.Products;

namespace _02_AbstractFactoryClassLibrary.Factories
{
    public class KiaomiFactory : IDeviceFactory
    {
        public string Brand => "Kiaomi";

        public Ebook CreateEbook()
        {
            return new Ebook(this.Brand, 8, false, false);
        }

        public Laptop CreateLaptop()
        {
            return new Laptop(this.Brand, "GTX 1030", "HD", false);
        }

        public Netbook CreateNetbook()
        {
            return new Netbook(this.Brand, "Ryzen 3 1200", 512, 8);
        }

        public Smartphone CreateSmartphone()
        {
            return new Smartphone(this.Brand, "Android", "+3801234567", false);
        }
    }
}