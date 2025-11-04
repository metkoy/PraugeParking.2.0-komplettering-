using System.Text.Json;

namespace PraugeParking.DataAccess
{
    public class Class1
    {

    }
}


using System.Text.Json;
using PragueParking.Core.Services;

namespace PragueParking.DataAccess
{
    public static class FileService
    {
        private static readonly JsonSerializerOptions _options = new() { WriteIndented = true };

        public static void SaveGarage(ParkingGarage garage, string filePath)
        {
            var json = JsonSerializer.Serialize(garage, _options);
            File.WriteAllText(filePath, json);
        }

        public static ParkingGarage LoadGarage(string filePath)
        {
            if (!File.Exists(filePath)) return new ParkingGarage(100);
            var json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<ParkingGarage>(json) ?? new ParkingGarage(100);
        }
    }
}




using System.Text.Json;

namespace PragueParking.DataAccess
{
    public class Config
    {
        public int NumberOfSpots { get; set; }
        public Dictionary<string, int> SpotCapacity { get; set; } = new();
        public Dictionary<string, decimal> Prices { get; set; } = new();
        public int FreeMinutes { get; set; } = 10;
    }

    public static class ConfigService
    {
        public static Config LoadConfig(string path)
        {
            if (!File.Exists(path)) throw new FileNotFoundException("Config file missing!", path);
            var json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<Config>(json)!;
        }
    }
}
