using System;
using CakeCompany.Provider;
using NUnit.Framework;
using CakeCompany.Models;

namespace CakeCompany.UnitTest
{
	[TestFixture]
	public class ShipmentProviderTest
	{
        private ShipmentProvider _shipmentProvider;

        [SetUp]
        public void SetUp()
        {
            _shipmentProvider = new ShipmentProvider();
        }

        [Test]
        public void GetShipmentTest()
        {
            // Arrange
            Order[] orders = new Order[1];
            Order newOrder = new("MyTest", DateTime.Now, 1, Cake.Chocolate, 3000);
            orders[0] = newOrder;

            // Act
            var result = _shipmentProvider.GetShipment(orders);

            //Assert
            Assert.AreEqual(result, "Shipment Successful...");
        }
    }
}

