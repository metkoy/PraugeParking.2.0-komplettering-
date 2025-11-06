namespace PragueParking.Core
{
    public class Car : Vehicle
    {
        public override string VehicleType => "Car";
        public Car(string regNr) : base(regNr) { }
    }
}
