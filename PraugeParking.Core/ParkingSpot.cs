namespace PragueParking.Core
{
    public class ParkingSpot
    {
        public int SpotNumber { get; set; }
        public int Capacity { get; set; }
        public List<Vehicle> Vehicles { get; set; } = new();

        public bool IsFull => Vehicles.Count >= Capacity;

        public bool TryPark(Vehicle vehicle)
        {
            if (IsFull) return false;
            Vehicles.Add(vehicle);
            return true;
        }

        public bool RemoveVehicle(string regNr)
        {
            var v = Vehicles.FirstOrDefault(x => x.RegNr == regNr);
            if (v == null) return false;
            Vehicles.Remove(v);
            return true;
        }
    }
}