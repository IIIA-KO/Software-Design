namespace _05_BuilderClassLibrary
{
    public interface IExpectsOutfit
    {
        IExpectsBodyParameters InOutfit(string outfit);
    }

    public interface IExpectsBodyParameters
    {
        IExpectsBodyParameters WithHeight(double height);
        IExpectsBodyParameters WithBuild(string build);
        IExpectsBodyParameters WithHairColor(string hairColor);
        IExpectsBodyParameters WithEyeColor(string eyeColor);
        Hero Create();
    }


    public interface IHeroBuilder 
        : IExpectsOutfit, IExpectsBodyParameters
    {
    }
}