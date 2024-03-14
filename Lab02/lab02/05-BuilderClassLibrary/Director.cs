namespace _05_BuilderClassLibrary
{
    public static class Director
    {
        public static Hero BuildHero() =>
            HeroBuilder
                .WithName("Hero")
                .InOutfit("Armor")
                .WithHeight(180)
                .WithBuild("Athletic")
                .WithHairColor("Blonde")
                .WithEyeColor("Blue")
                .Create();

        public static Enemy BuildEnemy() =>
            EnemyBuilder.WithName("Villain")
            .WithEyeColor("Red")
            .WithAttackDamage(666)
            .WithWeapon("Lightning")
            .Create();
    }
}