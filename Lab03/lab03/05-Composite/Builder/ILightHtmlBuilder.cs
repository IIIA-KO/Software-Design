using _05_Composite.Enums;
using _05_Composite.Nodes;

namespace _05_Composite.Builder
{
    public interface IExpectsDisplayType
    {
        IExpectsClosingType WithDisplay(DisplayType display);
    }

    public interface IExpectsClosingType
    {
        IExpectsCssClasses WithClosing(ClosingType closing);
    }

    public interface IExpectsCssClasses
    {
        IExpectsChildren WithCssClasses(List<string> cssClasses);
    }

    public interface IExpectsChildren
    {
        ILightHtmlBuilder WithChild(LightNode child);
    }

    public interface ILightHtmlBuilder
        : IExpectsDisplayType, IExpectsClosingType,
          IExpectsCssClasses, IExpectsChildren
    {
        LightElementNode Build();
    }
}