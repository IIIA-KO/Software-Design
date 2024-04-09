using _03_Observer.Enums;
using _03_Observer.Nodes;

namespace _03_Observer.Builder
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