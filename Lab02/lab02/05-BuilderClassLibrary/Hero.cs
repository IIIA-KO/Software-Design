namespace _05_BuilderClassLibrary
{
    public class Hero
    {
        public string Name { get; init; } = null!;
        public string Outfit { get; init; } = null!;
        public double Height { get; init; }
        public string Build { get; init; } = null!;
        public string HairColor { get; init; } = null!;
        public string EyeColor { get; init; } = null!;

        public override string ToString()
        {
            return $"Name {this.Name}, Height: {this.Height}, Build: {this.Build}, Hair color: {this.HairColor}, " +
                   $"Eye color: {this.EyeColor}, Outfit: {this.Outfit}";
        }
    }
}