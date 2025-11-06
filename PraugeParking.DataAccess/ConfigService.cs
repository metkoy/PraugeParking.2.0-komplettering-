using PragueParking.Core;
using System.Text.Json;
namespace PragueParking.DataAccess
{
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
