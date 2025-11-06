namespace PragueParking.Core
{
    public class ParkingGarage
    {
        public List<ParkingSpot> Spots { get; set; } = new();

        public ParkingGarage() { }

        public ParkingGarage(int numberOfSpots, int defaultCapacity = 1)
        {
            for (int i = 1; i <= numberOfSpots; i++)
                Spots.Add(new ParkingSpot { SpotNumber = i, Capacity = defaultCapacity });
        }

        public bool ParkVehicle(Vehicle vehicle)
        {
            foreach (var spot in Spots)
            {
                if (spot.TryPark(vehicle)) return true;
            }
            return false;
        }

        public Vehicle? RetrieveVehicle(string regNr)
        {
            foreach (var spot in Spots)
            {
                var v = spot.Vehicles.FirstOrDefault(x => x.RegNr == regNr);
                if (v != null)
                {
                    spot.RemoveVehicle(regNr);
                    return v;
                }
            }
            return null;
        }

        public ParkingSpot? FindVehicleSpot(string regNr)
        {
            return Spots.FirstOrDefault(s => s.Vehicles.Any(v => v.RegNr == regNr));
        }
    }
}