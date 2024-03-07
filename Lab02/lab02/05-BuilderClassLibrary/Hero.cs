namespace _05_BuilderClassLibrary
{
    public class Hero
    {
        public string Name { get; set; }
        public string Outfit { get; set; }
        public double Height { get; set; }
        public string Build { get; set; }
        public string HairColor { get; set; }
        public string EyeColor { get; set; }

        public override string ToString()
        {
            return $"Name {this.Name}, Height: {this.Height}, Build: {this.Build}, Hair color: {this.HairColor}, Eye color: {this.EyeColor}, Outfit: {this.Outfit}";
        }
    }
}