namespace _02_AbstractFactoryClassLibrary.Products
{
    public class Ebook : Device
    {
        public int ScreenSizeInches { get; }
        public bool HasEInkDisplay { get; }
        public bool SupportsAudioBooks { get; }
        
        public Ebook(string brand, int screenSize, bool hasInkDisplay, bool supportsAudio) : base(brand)
        {
            if(screenSize < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(screenSize), "Screen size must be positive value.");
            }

            this.ScreenSizeInches = screenSize;
            this.HasEInkDisplay = hasInkDisplay;
            this.SupportsAudioBooks = supportsAudio;
        }

        public override string ToString()
        {
            return base.ToString() + $"Screen size (in): {this.ScreenSizeInches}, Has Eink display: {this.HasEInkDisplay}, Supports audio books: {this.SupportsAudioBooks}";
        }
    }
}