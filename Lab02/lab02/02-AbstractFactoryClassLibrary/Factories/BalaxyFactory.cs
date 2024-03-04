using _02_AbstractFactoryClassLibrary.Products;

namespace _02_AbstractFactoryClassLibrary.Factories
{
    public class BalaxyFactory : IDeviceFactory
    {
        public string Brand => "Balaxy";

        public Ebook CreateEbook()
        {
            return new Ebook(this.Brand, 7, true, true);
        }

        public Laptop CreateLaptop()
        {
            return new Laptop(this.Brand, "RTX 2070", "Full HD", false);
        }

        public Netbook CreateNetbook()
        {
            return new Netbook(this.Brand, "Interl Core i7-13500", 1024, 16);
        }

        public Smartphone CreateSmartphone()
        {
            return new Smartphone(this.Brand, "Android", "+3801234567", true);
        }
    }
}
