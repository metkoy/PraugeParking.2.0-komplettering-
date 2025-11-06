namespace PragueParking.Core
{
    public abstract class Vehicle
    {
        public string RegNr { get; set; }
        public DateTime ArrivalTime { get; set; }
        public abstract string VehicleType { get; }

        public Vehicle(string regNr)
        {
            RegNr = regNr.ToUpper();
            ArrivalTime = DateTime.Now;
        }

        public TimeSpan GetParkedTime() => DateTime.Now - ArrivalTime;
    }
}