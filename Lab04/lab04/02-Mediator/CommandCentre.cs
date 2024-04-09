namespace _02_Mediator
{
    public class CommandCentre : IMediator
    {
        private readonly List<Runway> _runways = [];
        private readonly List<Aircraft> _aircrafts = [];

        public CommandCentre(Runway[] runways, Aircraft[] aircrafts)
        {
            this._runways.AddRange(runways);
            this._aircrafts.AddRange(aircrafts);
        }

        public void AircraftLandingRequest(Aircraft aircraft)
        {
            Console.WriteLine($"Aircraft {aircraft.Name} requests landing.");

            if (this._runways.Any(r => r.IsBusyWithAircraft == aircraft))
            {
                PrintError($"Aircraft {aircraft.Name} already landed on Runway {aircraft.CurrentRunway!.Id}\n");
                return;
            }

            foreach (var runway in this._runways)
            {
                if (runway.IsAvailable())
                {
                    PrintSuccess($"Runway {runway.Id} is free. Aircraft {aircraft.Name} is landing.\n");
                    runway.IsBusyWithAircraft = aircraft;
                    aircraft.CurrentRunway = runway;
                    aircraft.Land();
                    return;
                }
            }

            PrintError($"All runways are busy. Aircraft {aircraft.Name} cannot land.");
        }

        public void AircraftTakeOffRequest(Aircraft aircraft)
        {
            Console.WriteLine($"Aircraft {aircraft.Name} requests takeoff.");

            var runway = aircraft.CurrentRunway;
            if (runway != null && runway.IsBusyWithAircraft == aircraft)
            {
                PrintSuccess($"Aircraft {aircraft.Name} is taking off from Runway {runway.Id}.");
                runway.IsBusyWithAircraft = null;
                aircraft.TakeOff();
            }
            else
            {
                PrintError($"Aircraft {aircraft.Name} is not on any runway. Cannot takeoff.");
            }
            Console.WriteLine();
        }

        private static void PrintSuccess(string message) =>
            PrintMessageWithColor(message, ConsoleColor.Green);

        private static void PrintError(string message) =>
            PrintMessageWithColor(message, ConsoleColor.Red);

        private static void PrintMessageWithColor(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
