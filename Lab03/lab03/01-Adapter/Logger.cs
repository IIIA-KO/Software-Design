namespace _01_Adapter
{
    public class Logger : ILogger
    {
        public void Log(string message)
        {
            PrintMessageWithColor("Log: " + message, ConsoleColor.Green);
        }

        public void Error(string message)
        {
            PrintMessageWithColor("Error: " + message, ConsoleColor.Red);
        }

        public void Warn(string message)
        {
            PrintMessageWithColor("Warning: " + message, ConsoleColor.DarkYellow);
        }

        private static void PrintMessageWithColor(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}