using System;
using CakeCompany.Provider;
using NUnit.Framework;
using CakeCompany.Models;
using System.Collections.Generic;

namespace CakeCompany.UnitTest
{
	[TestFixture]
	public class TransportProviderTest
	{
        private TransportProvider _transportProvider;

        [SetUp]
        public void SetUp()
        {
            _transportProvider = new TransportProvider();
        }

        [Test]
        public void CheckForAvailabilityTest_LessThan_1000()
        {
            // Arrange
            List<Product> products = new List<Product>();
            products.Add(new Product { Quantity = 100 });

            // Act
            var result = _transportProvider.CheckForAvailability(products);

            //Assert
            Assert.AreEqual(result, "Van");
        }

        [Test]
        public void CheckForAvailabilityTest_Between_1000_5000()
        {
            // Arrange
            List<Product> products = new List<Product>();
            products.Add(new Product { Quantity = 3000 });

            // Act
            var result = _transportProvider.CheckForAvailability(products);

            //Assert
            Assert.AreEqual(result, "Truck");
        }

        [Test]
        public void CheckForAvailabilityTest_GreaterThan_5000()
        {
            // Arrange
            List<Product> products = new List<Product>();
            products.Add(new Product { Quantity = 5000 });

            // Act
            var result = _transportProvider.CheckForAvailability(products);

            //Assert
            Assert.AreEqual(result, "Ship");
        }
    }
}

