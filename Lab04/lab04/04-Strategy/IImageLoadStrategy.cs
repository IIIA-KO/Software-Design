namespace _04_Strategy
{
    public interface IImageLoadStrategy
    {
        Task<byte[]> LoadImageAsync(string href);
    }
}