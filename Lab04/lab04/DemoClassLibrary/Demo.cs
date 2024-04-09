namespace DemoClassLibrary
{
    public abstract class Demo
    {
        protected abstract string Name { get; }
        protected abstract void Implementation();

        public void Run()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"{this.Name} Demo:");
                Console.ResetColor();

                this.Implementation();

                Console.WriteLine(new string('-', 50));
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{ex.GetType().Name}: {ex.Message}");
                Console.ResetColor();
            }
        }
    }
}