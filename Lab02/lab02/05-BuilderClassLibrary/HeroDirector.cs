using System.Xml.Serialization;

namespace _05_BuilderClassLibrary;

public static class HeroDirector
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

    public static Hero BuildVillain() =>
        HeroBuilder
            .WithName("Villain")
            .InOutfit("Dark Robe")
            .WithHeight(170)
            .WithBuild("Thin")
            .WithHairColor("Bald")
            .WithEyeColor("Red")
            .Create();
}