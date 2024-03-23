namespace _02_Decorator.Heroes
{
    public abstract class Hero
    {
        public string Name { get; }
        public int Health { get; set; }
        public int Attack { get; set; }

        protected Hero(string name, int health, int attack)
        {
            ArgumentException.ThrowIfNullOrEmpty(name);
            ArgumentOutOfRangeException.ThrowIfLessThan(health, 0, nameof(health));
            ArgumentOutOfRangeException.ThrowIfLessThan(attack, 0, nameof(attack));

            Name = name;
            Health = health;
            Attack = attack;
        }

        public virtual void DisplayStats() =>
            Console.WriteLine(this);

        public override string ToString() =>
            $"{Name}'s Stats:\n\tHealth: {Health}, Attack: {Attack}";
    }
}