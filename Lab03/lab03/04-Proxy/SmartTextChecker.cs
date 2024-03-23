using _01_Adapter;

namespace _04_Proxy
{
    public class SmartTextChecker : ISmartTextReader
    {
        private readonly SmartTextReader _reader = new SmartTextReader();
        private readonly Logger _logger = new Logger();

        public char[][] ReadText(string filePath)
        {
            this._logger.Log("File was opened.");

            char[][] textArray = this._reader.ReadText(filePath);
            this._logger.Log($"Total lines: {textArray.Length}");

            int totalCharacters = textArray.Sum(x => x.Length);
            this._logger.Log($"Total characters: {totalCharacters}");

            this._logger.Log("File was closed");

            return textArray;
        }
    }
}