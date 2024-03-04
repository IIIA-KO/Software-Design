using _02_AbstractFactoryClassLibrary.Products;

namespace _02_AbstractFactoryClassLibrary.Factories
{
    public interface IDeviceFactory
    {
        string Brand { get; }
        Ebook CreateEbook();
        Laptop CreateLaptop();
        Netbook CreateNetbook();
        Smartphone CreateSmartphone();
    }
}