using _02_Mediator;
using DemoClassLibrary;

namespace DemoConsoleApp.Demos
{
    public class MediatorDemo : Demo
    {
        protected override string Name => "Mediator";

        protected override void Implementation()
        {
            Runway[] runways = [new(), new()];

            var aircraft1 = new Aircraft("Plane1");
            var aircraft2 = new Aircraft("Plane2");
            var aircrafts = new Aircraft[] { aircraft1, aircraft2 };

            var commandCentre = new CommandCentre(runways, aircrafts);

            Console.WriteLine("Land and takeoff:");
            commandCentre.AircraftLandingRequest(aircraft1);
            commandCentre.AircraftTakeOffRequest(aircraft1);

            Console.WriteLine("Cant takeoff:");
            commandCentre.AircraftTakeOffRequest(aircraft2);

            Console.WriteLine("Land and takeoff:");
            commandCentre.AircraftLandingRequest(aircraft2);
            commandCentre.AircraftTakeOffRequest(aircraft2);

            Console.WriteLine("Already landed:");
            commandCentre.AircraftLandingRequest(aircraft1);
            commandCentre.AircraftLandingRequest(aircraft1);

            Console.WriteLine("No available runways:");
            commandCentre.AircraftLandingRequest(aircraft2);
            var aircraft3 = new Aircraft("Plane3");
            commandCentre.AircraftLandingRequest(aircraft3);
        }
    }
}
