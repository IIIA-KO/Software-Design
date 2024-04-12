namespace LightHtml.Strategy
{
    public interface IImageLoadStrategy
    {
        Task<byte[]> LoadImageAsync(string href);
    }
}