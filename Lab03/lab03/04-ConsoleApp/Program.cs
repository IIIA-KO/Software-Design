using _04_Proxy;
using _01_Adapter;

namespace _04_ConsoleApp
{
    internal class Program
    {
        private static readonly string FilePath = "LoremIpsum.txt";
        private static readonly string RestrictedFilePath = "restricted123.txt";

        static void Main(string[] args)
        {
            ISmartTextReader reader = new SmartTextReader();
            Test(reader, FilePath);

            Console.WriteLine();

            ISmartTextReader checker = new SmartTextChecker();
            Test(checker, FilePath);

            Console.WriteLine();

            string restrictedFilePathPattern = @"restricted\d+\.txt";
            ISmartTextReader locker = new SmartTextReaderLocker(restrictedFilePathPattern);
            Test(locker, RestrictedFilePath);
        }

        private static void Test(ISmartTextReader reader, string filePath)
        {
            Console.WriteLine(new string('-', 100));
            try
            {
                char[][] textArray = reader.ReadText(filePath);

                if (textArray.Length == 0)
                {
                    Console.WriteLine("Array is empty.");
                    return;
                }

                Console.WriteLine("Text file turned to 2d array:");
                for (int i = 0; i < textArray.Length; i++)
                {
                    for (int j = 0; j < textArray[i].Length; j++)
                    {
                        Console.Write(textArray[i][j] + " ");
                    }
                    Console.WriteLine();
                }
            }
            catch (FileNotFoundException ex)
            {
                var logger = new Logger();
                logger.Error("File was not found. " + ex.Message);
            }
            catch (Exception ex)
            {
                var logger = new Logger();
                logger.Error($"{ex.GetType().Name}: {ex.Message}");
            }
            Console.WriteLine(new string('-', 100));
        }
    }
}