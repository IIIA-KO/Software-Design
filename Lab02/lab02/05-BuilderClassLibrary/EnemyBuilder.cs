using _05_BuilderClassLibrary.Interfaces;

namespace _05_BuilderClassLibrary
{
    // Step-wise builder with all parameters required:
    internal class EnemyBuilder : IEnemyBuilder
    {
        public string Name { get; set; }
        public string Outfit { get; set; }
        public string EyeColor { get; set; }
        public int AttackDamage { get; set; }
        public string Weapon { get; set; }
        public bool IsBoss { get; set; }

        public EnemyBuilder()
        {
            this.Name = string.Empty;
            this.Outfit = string.Empty;
            this.EyeColor = string.Empty;
            this.AttackDamage = 0;
            this.Weapon = string.Empty;
            this.IsBoss = false;
        }

        private static string GetErrorMessage(string paramName)
        {
            return $"Cannot build an enemy. Invalid {paramName} provided.";
        }

        public static IExpectsEyeColor WithName(string name)
        {
            return new EnemyBuilder { Name = ValidName(name) };
        }

        private static string ValidName(string name)
        {
            return !string.IsNullOrEmpty(name)
                ? name
                : throw new ArgumentException(GetErrorMessage(nameof(name)), nameof(name));
        }


        public IExpectsAttackDamage WithEyeColor(string eyeColor)
        {
            this.EyeColor = ValidEyeColor(eyeColor);
            return this;
        }

        private static string ValidEyeColor(string eyeColor)
        {
            return !string.IsNullOrEmpty(eyeColor)
                ? eyeColor
                : throw new ArgumentException(GetErrorMessage("eye color"), nameof(eyeColor));
        }

        public IExpectsWeapon WithAttackDamage(int damage)
        {
            this.AttackDamage = ValidAttackDamage(damage);
            return this;
        }

        private static int ValidAttackDamage(int damage)
        {
            return damage > 0
                ? damage
                : throw new ArgumentOutOfRangeException(nameof(damage), GetErrorMessage(nameof(damage)));
        }

        public IExpectsToBeBoss WithWeapon(string weapon)
        {
            this.Weapon = ValidWeapon(weapon);
            return this;
        }

        private static string ValidWeapon(string weapon)
        {
            return !string.IsNullOrEmpty(weapon)
                 ? weapon
                 : throw new ArgumentException(GetErrorMessage(nameof(weapon)), nameof(weapon));
        }

        public IEnemyBuilder BeingBoss(bool isBoss)
        {
            this.IsBoss = isBoss;
            return this;
        }


        public Enemy Create()
        {
            return new Enemy
            {
                Name = this.Name,
                EyeColor = this.EyeColor,
                AttackDamage = this.AttackDamage,
                Weapon = this.Weapon,
                IsBoss = this.IsBoss
            };
        }
    }
}
