namespace PragueParking.DataAccess
{
    public class Config
    {
        public int NumberOfSpots { get; set; }
        public Dictionary<string, int> SpotCapacity { get; set; } = new();
        public Dictionary<string, decimal> Prices { get; set; } = new();
        public int FreeMinutes { get; set; } = 10;
    }
}