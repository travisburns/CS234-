using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;
using MMABooksBusinessClasses;

namespace MMABooksTests
{
    [TestFixture]
    public class CustomerTests
    {
        private Customer def;
        private Customer c;

        [SetUp]
        public void Setup()
        {
            def = new Customer();
            c = new Customer(1, "Donald, Duck", "101 Main Street", "Orlando", "FL", "10001");
        }

        [Test]
        public void TestConstructor()
        {
            Assert.IsNotNull(def);
            Assert.AreEqual(null, def.Name);
            Assert.AreEqual(null, def.Address);
            Assert.AreEqual(null, def.City);
            Assert.AreEqual(null, def.State);
            Assert.AreEqual(null, def.ZipCode);
            Assert.IsNotNull(c);
            Assert.AreNotEqual(null, c.Name);
            Assert.AreNotEqual(null, c.Name);
            Assert.AreNotEqual(null, c.Address);
            Assert.AreNotEqual(null, c.City);
            Assert.AreNotEqual(null, c.State);
            Assert.AreNotEqual(null, c.ZipCode);
        }

        [Test]
        public void TestNameSetter()
        {
            c.Name = "Dasie, Duck";
            Assert.AreNotEqual("Donald, Duck", c.Name);
            Assert.AreEqual("Dasie, Duck", c.Name);
        }

        [Test]
        public void TestAddressSetter()
        {
            c.Address = "202 Duck Lane";
            Assert.AreNotEqual("101 Main Street", c.Address);
            Assert.AreEqual("202 Duck Lane", c.Address);
        }

        [Test]
        public void TestCitySetter()
        {
            c.City = "Miami";
            Assert.AreNotEqual("Orlando", c.City);
            Assert.AreEqual("Miami", c.City);
        }

        [Test]
        public void TestStateSetter()
        {
            c.State = "CA";
            Assert.AreNotEqual("FL", c.State);
            Assert.AreEqual("CA", c.State);
        }

        [Test]
        public void TestZipCodeSetter()
        {
            c.ZipCode = "20001";
            Assert.AreNotEqual("10001", c.ZipCode);
            Assert.AreEqual("20001", c.ZipCode);
        }

        [Test]
        public void TestSettersNameTooLong()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => c.Name = "01234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789");
        }

        [Test]
        public void TestSettersAddressTooLong()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => c.Address = new string('a', 51));
        }

        [Test]
        public void TestSettersCityTooLong()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => c.City = new string('a', 21));
        }

        [Test]
        public void TestSettersStateWrongLength()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => c.State = "ABC");
        }

        [Test]
        public void TestSettersZipWrongLength()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => c.ZipCode = "123456");
        }

        [Test]
        public void TestToString()
        {
            Assert.AreEqual("CustomerID: 1, Name: Donald, Duck, Address: 101 Main Street, City: Orlando, State: FL, ZipCode: 10001", c.ToString());
        }
    }
}
