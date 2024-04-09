namespace _02_Mediator
{
    public interface IMediator
    {
        void AircraftLandingRequest(Aircraft aircraft);
        void AircraftTakeOffRequest(Aircraft aircraft);
    }
}