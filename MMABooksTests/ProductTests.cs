using System;
using NUnit.Framework;
using MMABooksBusinessClasses;

namespace MMABooksTests
{
    [TestFixture]
    public class ProductTests
    {
        private Product def;
        private Product p;

        [SetUp]
        public void Setup()
        {
            def = new Product();
            p = new Product("1234567890", "Test Product", 9.9999m, 100);
        }

        [Test]
        public void TestConstructor()
        {
            Assert.IsNotNull(def);
            Assert.IsNull(def.ProductCode);
            Assert.IsNull(def.Description);
            Assert.AreEqual(0, def.UnitPrice);
            Assert.AreEqual(0, def.OnHandQuantity);

            Assert.IsNotNull(p);
            Assert.AreEqual("1234567890", p.ProductCode);
            Assert.AreEqual("Test Product", p.Description);
            Assert.AreEqual(9.9999m, p.UnitPrice);
            Assert.AreEqual(100, p.OnHandQuantity);
        }

        [Test]
        public void TestProductCode()
        {
            p.ProductCode = "0987654321";
            Assert.AreEqual("0987654321", p.ProductCode);

            p.ProductCode = "abcdefghij";
            Assert.AreEqual("ABCDEFGHIJ", p.ProductCode); 

            Assert.Throws<ArgumentException>(() => p.ProductCode = "");
            Assert.Throws<ArgumentException>(() => p.ProductCode = "   ");
            Assert.Throws<ArgumentException>(() => p.ProductCode = "123456789");
            Assert.Throws<ArgumentException>(() => p.ProductCode = "12345678901");
        }

        [Test]
        public void TestDescription()
        {
            p.Description = "New Test Product";
            Assert.AreEqual("New Test Product", p.Description);

            Assert.Throws<ArgumentException>(() => p.Description = "");
            Assert.Throws<ArgumentException>(() => p.Description = "   ");
            Assert.Throws<ArgumentException>(() => p.Description = new string('a', 51));
        }

        [Test]
        public void TestUnitPrice()
        {
            p.UnitPrice = 19.9999m;
            Assert.AreEqual(19.9999m, p.UnitPrice);

            p.UnitPrice = 19.99999m;
            Assert.AreEqual(20.0000m, p.UnitPrice); 

            p.UnitPrice = 0;
            Assert.AreEqual(0, p.UnitPrice);

            Assert.Throws<ArgumentException>(() => p.UnitPrice = -1);
            Assert.Throws<ArgumentException>(() => p.UnitPrice = 1000000m);
        }

        [Test]
        public void TestOnHandQuantity()
        {
            p.OnHandQuantity = 200;
            Assert.AreEqual(200, p.OnHandQuantity);

            p.OnHandQuantity = 0;
            Assert.AreEqual(0, p.OnHandQuantity);

            Assert.Throws<ArgumentException>(() => p.OnHandQuantity = -1);
        }

        [Test]
        public void TestToString()
        {
            string expected = "Product Code: 1234567890, Description: Test Product, Unit Price: 9.9999, On Hand: 100";
            Assert.AreEqual(expected, p.ToString());
        }
    }
}