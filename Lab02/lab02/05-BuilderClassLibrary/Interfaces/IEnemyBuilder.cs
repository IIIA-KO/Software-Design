namespace _05_BuilderClassLibrary.Interfaces
{
    public interface IExpectsEyeColor
    {
        IExpectsAttackDamage WithEyeColor(string eyeColor);
    }

    public interface IExpectsAttackDamage
    {
        IExpectsWeapon WithAttackDamage(int damage);
    }

    public interface IExpectsWeapon
    {
        IExpectsToBeBoss WithWeapon(string weapon);
    }

    public interface IExpectsToBeBoss
    {
        IExpectsToBeBoss BeingBoss(bool isBoss);
        Enemy Create();
    }

    internal interface IEnemyBuilder
        : IExpectsEyeColor, IExpectsAttackDamage,
            IExpectsWeapon, IExpectsToBeBoss
    {
    }
}
