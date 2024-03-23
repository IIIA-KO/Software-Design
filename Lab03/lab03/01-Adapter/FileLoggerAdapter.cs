namespace _01_Adapter
{
    public class FileLoggerAdapter(string filePath) : FileWriter(filePath), ILogger
    {
        public void Log(string message)
        {
            WriteLine("File Log: " + message);
        }

        public void Error(string message)
        {
            WriteLine("File Error: " + message);
        }

        public void Warn(string message)
        {
            WriteLine("File Warning: " + message);
        }
    }
}