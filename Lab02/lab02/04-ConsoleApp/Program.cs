using _04_PrototypeClassLibrary;

namespace _04_ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Virus grandparentVirus = new(10, 1, "Grandparent", "Influenza");
            Virus parentVirus = new(8, 2, "Parent", "COVID-19");
            Virus childVirus1 = new(5, 1, "Child1", "Ebola");
            Virus childVirus2 = new(4, 1, "Child2", "Zika");

            grandparentVirus.Children.Add(parentVirus);
            parentVirus.Children.Add(childVirus1);
            parentVirus.Children.Add(childVirus2);


            Console.WriteLine("Grandparent Virus:");
            Console.WriteLine(grandparentVirus);

            Virus clonedGrandparentVirus = grandparentVirus.DeepCopy();

            Console.WriteLine("Cloned Grandparent Virus:");
            Console.WriteLine(clonedGrandparentVirus);

            Console.WriteLine(ReferenceEquals(grandparentVirus, clonedGrandparentVirus));
        }
    }
}
