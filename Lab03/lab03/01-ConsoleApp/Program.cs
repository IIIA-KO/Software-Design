using _01_Adapter;

namespace _01_ConsoleApp
{
    internal class Program
    {
        static readonly string LogMessage = "This is a log message!";
        static readonly string ErrorMessage = "This is an error message!";
        static readonly string WarnMessage = "This is a warn message!";

        static readonly string FilePath = "log.txt";

        static void Main(string[] args)
        {
            Console.WriteLine("Console logger:");
            ILogger logger = new Logger();
            logger.Log(ErrorMessage);
            logger.Error(WarnMessage);
            logger.Warn(LogMessage);

            Console.WriteLine("FileWriter:");
            var fileWriter = new FileWriter(FilePath);
            fileWriter.WriteLine(LogMessage);
            fileWriter.Write(ErrorMessage);
            fileWriter.Write(WarnMessage);

            var fileText = File.ReadAllText(FilePath);
            Console.WriteLine(fileText);

            File.Delete(FilePath);
            logger.Warn("File was deleted.");

            ILogger fileLogger = new FileLoggerAdapter(FilePath);
            fileLogger.Log(ErrorMessage);
            fileLogger.Error(WarnMessage);
            fileLogger.Warn(LogMessage);

            fileText = File.ReadAllText(FilePath);
            Console.WriteLine(fileText);

            File.Delete(FilePath);
        }
    }
}