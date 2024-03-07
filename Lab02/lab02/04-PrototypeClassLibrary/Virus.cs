using System.Text;
using System.Security.AccessControl;

namespace _04_PrototypeClassLibrary
{
    public class Virus : IDeepCopyable<Virus>
    {
        public double Weight { get; set; }
        public int Age { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }

        public ICollection<Virus> Children;

        public Virus()
        {
            this.Children = new List<Virus>();
        }

        public Virus(double weight, int age, string type, string name)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(weight, nameof(weight));
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(age, nameof(age));
            ArgumentException.ThrowIfNullOrEmpty(type, nameof(type));

            this.Weight = weight;
            this.Age = age;
            this.Type = type;
            this.Name = name;
            this.Children = new List<Virus>();
        }

        public void AddChild(Virus child)
        {
            this.Children.Add(child);
        }

        public void CopyTo(Virus obj)
        {
            obj.Name = this.Name;
            obj.Weight = this.Weight;
            obj.Age = this.Age;
            obj.Type = this.Type;
            obj.Children.Clear();

            foreach (Virus child in this.Children)
            {
                obj.Children.Add(child.DeepCopy());
            }
        }

        private void Print(StringBuilder sb,  int indent)
        {
            sb.Append(new string('\t', indent))
                .Append($"Name: {this.Name} ")
                .Append($"Weight: {this.Weight} ")
                .Append($"Age: {this.Age}")
                .AppendLine($"Type: {this.Type}");

            foreach (Virus child in this.Children)
            {
                child.Print(sb, indent + 1);
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            Print(sb, 0);
            return sb.ToString();
        }
    }
}