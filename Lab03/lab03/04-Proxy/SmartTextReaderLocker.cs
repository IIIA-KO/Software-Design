using _01_Adapter;
using System.Text.RegularExpressions;

namespace _04_Proxy
{
    public class SmartTextReaderLocker : ISmartTextReader
    {
        private readonly Regex _restrictedFilesRegex;
        private readonly SmartTextReader _reader;
        private readonly Logger _logger = new Logger();

        public SmartTextReaderLocker(string restrictedFilesPattern)
        {
            this._restrictedFilesRegex = new Regex(restrictedFilesPattern);
            this._reader = new SmartTextReader();
        }

        public char[][] ReadText(string filePath)
        {
            if(!IsFileAllowed(filePath))
            {
                this._logger.Warn("Access denied!");
                return Array.Empty<char[]>();
            }

            return this._reader.ReadText(filePath);
        }

        private bool IsFileAllowed(string filePath)
        {
            return !this._restrictedFilesRegex.IsMatch(filePath);
        }
    }
}