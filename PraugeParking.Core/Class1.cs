using PragueParking.Core.Models;

namespace PraugeParking.Core
{
    public class Class1
    {

    }
}


using PragueParking.Core.Models;

namespace PragueParking.Core.Models
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



namespace PragueParking.Core.Models
{
    public class Car : Vehicle
    {
        public override string VehicleType => "Car";
        public Car(string regNr) : base(regNr) { }
    }
}




namespace PragueParking.Core.Models
{
    public class MC : Vehicle
    {
        public override string VehicleType => "MC";
        public MC(string regNr) : base(regNr) { }
    }
}




namespace PragueParking.Core.Models
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



using PragueParking.Core.Models;

namespace PragueParking.Core.Services
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
