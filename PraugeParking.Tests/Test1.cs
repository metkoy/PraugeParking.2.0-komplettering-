using Microsoft.VisualStudio.TestTools.UnitTesting;
using PragueParking.Core;

namespace PragueParking.Tests
{
    [TestClass]
    public class ParkingGarageTests
    {
        [TestMethod]
        public void ParkVehicle_ShouldAddVehicle()
        {
            var garage = new ParkingGarage(1);
            var car = new Car("ABC123");
            var result = garage.ParkVehicle(car);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void RetrieveVehicle_ShouldReturnVehicle()
        {
            var garage = new ParkingGarage(1);
            var mc = new MC("XYZ789");
            garage.ParkVehicle(mc);
            var result = garage.RetrieveVehicle("XYZ789");
            Assert.IsNotNull(result);
            Assert.AreEqual("XYZ789", result!.RegNr);
        }
    }
}
