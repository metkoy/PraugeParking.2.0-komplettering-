namespace PragueParking.Core
{
    public class MC : Vehicle
    {
        public override string VehicleType => "MC";
        public MC(string regNr) : base(regNr) { }
    }
}