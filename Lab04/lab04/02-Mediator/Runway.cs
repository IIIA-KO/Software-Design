namespace _02_Mediator
{
    public class Runway
    {
        public readonly Guid Id = Guid.NewGuid();
        public Aircraft? IsBusyWithAircraft;

        public bool IsAvailable()
        {
            return IsBusyWithAircraft == null;
        }
    }
}