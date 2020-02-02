using System.Collections.Generic;
using Moq;
using NUnit.Framework;

namespace TheLibrary.Tests
{
    [TestFixture]
    public class VehiclesViewModelTests
    {
        [Test]
        public void AllVehiclesFromCallBackEndUpInProperty()
        {
            var vehiclesMock = new Mock<IVehicles>();
            vehiclesMock.Setup(x => x.ListVehicles(It.IsAny<string>(), It.IsAny<MyAsyncCompletedEventHandler>())).Callback<string, MyAsyncCompletedEventHandler>(
                (s, c) =>
                {
                    c = (sender, args) =>
                        args.Result = new List<Vehicle>
                        {
                            new Vehicle {Name = "TR3B"},
                            new Vehicle {Name = "Aurora"},
                            new Vehicle {Name = "HAUC"}
                        }.ToArray();
                });
            var testee = new VehiclesViewModel(vehiclesMock.Object);
            Assert.AreEqual(3,testee.VehicleRows.Count);
        }
    }
}