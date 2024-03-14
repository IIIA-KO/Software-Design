namespace _01_Adapter
{
    public class Logger
    {
        public void Log(string message)
        {
            PrintMessageWithColor(message, ConsoleColor.Green);
        }

        public void Error(string message)
        {
            PrintMessageWithColor(message, ConsoleColor.Red);
        }

        public void Warn(string message)
        {
            PrintMessageWithColor(message, ConsoleColor.DarkYellow);
        }

        private static void PrintMessageWithColor(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
