namespace _02_Mediator
{
    public class Aircraft(string name)
    {
        public string Name = name;
        public Runway? CurrentRunway { get; set; }
        public bool IsTakingOff { get; private set; }

        public void Land()
        {
            this.IsTakingOff = false;
            Console.WriteLine($"Aircraft {Name} has landed.");
        }

        public void TakeOff()
        {
            this.IsTakingOff = true;
            Console.WriteLine($"Aircraft {Name} has taken off.");
        }
    }
}
