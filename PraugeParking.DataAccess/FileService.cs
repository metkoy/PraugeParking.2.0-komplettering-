using System.Text.Json;
using PragueParking.Core;

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
