namespace _04_Strategy
{
    public class FileImageLoad : IImageLoadStrategy
    {
        public async Task<byte[]> LoadImageAsync(string href) => await File.ReadAllBytesAsync(href);
    }
}
