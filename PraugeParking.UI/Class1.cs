using PragueParking.Core;
using PragueParking.DataAccess;
using Spectre.Console;


namespace PraugeParking.UI
{
    public class Class1
    {



        private static void Main(string[] args)

        {



            string configPath = "../../../config.json";
            string dataPath = "../../../garage.json";

            var config = ConfigService.LoadConfig(configPath);
            var garage = FileService.LoadGarage(dataPath);
            //if (garage.Spots.Count < 100)
            //{
            //    for (int i = garage.Spots.Count; i < 100; i++)
            //    {
            //        garage.Spots[i] = new ParkingSpot();
            //    }
            //}

            AnsiConsole.MarkupLine("[bold yellow]Welcome to Prague Parking 2.0[/]");

            bool running = true;
            while (running)
            {
                AnsiConsole.Clear();
                var choice = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                    .Title("[green]Choose an option:[/]")
                    .AddChoices("Park Vehicle", "Retrieve Vehicle", "Show Map", "Exit"));

                switch (choice)
                {
                    case "Park Vehicle":

                        var reg = AnsiConsole.Ask<string>("Enter registration number:");
                        var type = AnsiConsole.Prompt(
                            new SelectionPrompt<string>().Title("Choose type:").AddChoices("Car", "MC"));

                        Vehicle v = type == "Car" ? new Car(reg) : new MC(reg);
                        if (garage.ParkVehicle(v))
                        {
                            AnsiConsole.MarkupLine("[green]Vehicle parked successfully![/]");
                            FileService.SaveGarage(garage, dataPath);
                        }
                        else
                        {
                            AnsiConsole.MarkupLine("[red]No available spots![/]");
                        }
                        break;

                    case "Retrieve Vehicle":
                        var regNr = AnsiConsole.Ask<string>("Enter registration number:");
                        var vehicle = garage.RetrieveVehicle(regNr);
                        if (vehicle == null)
                            AnsiConsole.MarkupLine("[red]Vehicle not found![/]");
                        else
                        {
                            var time = vehicle.GetParkedTime();
                            decimal rate = config.Prices[vehicle.VehicleType];
                            decimal cost = time.TotalMinutes <= config.FreeMinutes ? 0 : (decimal)Math.Ceiling(time.TotalHours) * rate;
                            AnsiConsole.MarkupLine($"[green]{vehicle.VehicleType} {vehicle.RegNr} retrieved. Cost: {cost} CZK[/]");
                        }
                        break;

                    case "Show Map":
                        foreach (var spot in garage.Spots)
                        {
                            string content = spot.Vehicles.Count == 0
                                ? "[green]Empty[/]"
                                : string.Join(", ", spot.Vehicles.Select(v => v.RegNr));
                            AnsiConsole.MarkupLine($"Spot {spot.SpotNumber}: {content}");
                        }
                        break;

                    case "Exit":
                        FileService.SaveGarage(garage, dataPath);
                        running = false;
                        break;
                }

                if (running)
                {
                    AnsiConsole.MarkupLine("[grey]Press any key to continue...[/]");
                    Console.ReadKey(true);
                }
            }
        }
    }
}