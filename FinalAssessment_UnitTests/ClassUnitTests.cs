using Microsoft.VisualStudio.TestTools.UnitTesting;
using FinalAssessment.Models;
using System;

namespace FinalAssessment_UnitTests
{
    /// <summary>
    /// These tests all relate to the Customers class, located in the models directory.
    /// </summary>
    [TestClass]
    public class CustomerUnitTests
    {
        [TestMethod]
        public void CidTest()
        {
            // Arrange
            Customers customer = new Customers();

            // Act
            customer.Cid = 1;

            // Assert
            Assert.AreEqual(1, customer.Cid);
        }

        [TestMethod]
        public void NameTest()
        {
            // Arrange
            Customers customer = new Customers();

            // Act
            customer.Name = "John Doe";

            // Assert
            Assert.AreEqual("John Doe", customer.Name);
        }

        [TestMethod]
        public void AgeTest()
        {
            // Arrange
            Customers customer = new Customers();

            // Act
            customer.Age = 1;

            // Assert
            Assert.AreEqual(1, customer.Age);
        }

        [TestMethod]
        public void PhoneTest()
        {
            // Arrange
            Customers customer = new Customers();

            // Act
            customer.Phone = "021123456";

            // Assert
            Assert.AreEqual("021123456", customer.Phone);
        }
    }

    /// <summary>
    /// These tests all relate to the Order class, located in the models directory.
    /// </summary>
    [TestClass]
    public class OrderUnitTests
    {
        [TestMethod]
        public void OidTest()
        {
            // Arrange
            Order order = new Order();

            // Act
            order.Oid = 123;

            // Assert
            Assert.AreEqual(123, order.Oid);
        }

        [TestMethod]
        public void CidTest()
        {
            // Arrange
            Order order = new Order();

            // Act
            order.Cid = 123;

            // Assert
            Assert.AreEqual(123, order.Cid);
        }

        [TestMethod]
        public void PidTest()
        {
            // Arrange
            Order order = new Order();

            // Act
            order.Pid = "123";

            // Assert
            Assert.AreEqual("123", order.Pid);
        }

        [TestMethod]
        public void PurchaseDateTest()
        {
            // Arrange
            Order order = new Order();

            // Act
            order.PurchaseDate = new DateTime(1991, 09, 24);

            // Assert
            Assert.AreEqual(1991, order.PurchaseDate.Year);
            Assert.AreEqual(09, order.PurchaseDate.Month);
            Assert.AreEqual(24, order.PurchaseDate.Day);
        }

        [TestMethod]
        public void PaymentDateTest()
        {
            // Arrange
            Order order = new Order();

            // Act
            order.PaymentDate = new DateTime(1991, 09, 24);

            // Assert
            Assert.AreEqual(1991, order.PaymentDate.Year);
            Assert.AreEqual(09, order.PaymentDate.Month);
            Assert.AreEqual(24, order.PaymentDate.Day);
        }
    }

    /// <summary>
    /// These tests all relate to the Products class, located in the models directory.
    /// </summary>
    [TestClass]
    public class ProductUnitTests
    {
        [TestMethod]
        public void PidTest()
        {
            // Arrange
            Products product = new Products();

            // Act
            product.Pid = "123";

            // Assert
            Assert.AreEqual("123", product.Pid);
        }

        [TestMethod]
        public void ProductNameTest()
        {
            // Arrange
            Products product = new Products();

            // Act
            product.ProductName = "Staples (box of 100)";

            // Assert
            Assert.AreEqual("Staples (box of 100)", product.ProductName);
        }

        [TestMethod]
        public void DescriptionTest()
        {
            // Arrange
            Products product = new Products();

            // Act
            product.Description = "Standard sized staples suitable for any office stapler.";

            // Assert
            Assert.AreEqual("Standard sized staples suitable for any office stapler.", product.Description);
        }

        [TestMethod]
        public void PriceTest()
        {
            // Arrange
            Products product = new Products();

            // Act
            product.Price = 2;

            // Assert
            Assert.AreEqual(2, product.Price);
        }

        [TestMethod]
        public void RatingTest()
        {
            // Arrange
            Products product = new Products();

            // Act
            product.Rating = 10;

            // Assert
            Assert.AreEqual(10, product.Rating);
        }

        [TestMethod]
        public void CategoryTest()
        {
            // Arrange
            Products product = new Products();

            // Act
            product.Category = "Office Supplies";

            // Assert
            Assert.AreEqual("Office Supplies", product.Category);
        }
    }
}
