namespace _05_BuilderClassLibrary
{
    public class Enemy
    {
        public string Name { get; init; } = null!;
        public string EyeColor { get; init; } = null!;
        public int AttackDamage { get; init; }
        public string Weapon { get; init; } = null!;
        public bool IsBoss { get; init; }

        public override string ToString()
        {
            return $"Name: {this.Name}, Eye color: {this.EyeColor}, " +
                   $"Attack damage: {this.AttackDamage}, Weapon: {this.Weapon}, Is boss: {this.IsBoss}";
        }
    }
}
