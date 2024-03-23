namespace _01_Adapter
{
    public class FileWriter(string filePath)
    {
        private readonly string _filePath = filePath;

        public void Write(string message)
        {
            File.AppendAllText(this._filePath, message);
        }

        public void WriteLine(string message)
        {
            using StreamWriter writer = new(this._filePath, true);
            writer.WriteLine(message);
        }
    }
}