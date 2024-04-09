
namespace _04_Strategy
{
    public class NetworkImageLoad : IImageLoadStrategy
    {
        public async Task<byte[]> LoadImageAsync(string href) => await new HttpClient().GetByteArrayAsync(href);
    }
}