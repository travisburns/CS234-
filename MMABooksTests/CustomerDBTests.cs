using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using MMABooksBusinessClasses;
using MMABooksDBClasses;

namespace MMABooksTests
{
    [TestFixture]
    public class CustomerDBTests
    {
        [Test]
        public void TestGetCustomer()
        {
            Customer c = CustomerDB.GetCustomer(2);
            Assert.AreEqual(2, c.CustomerID);
        }

        [Test]
        public void TestCreateCustomer()
        {
            Customer c = new Customer();
            c.Name = "Mickey Mouse";
            c.Address = "101 Main Street";
            c.City = "Orlando";
            c.State = "FL";
            c.ZipCode = "10101";
            int customerID = CustomerDB.AddCustomer(c);
            c = CustomerDB.GetCustomer(customerID);
            Assert.AreEqual("Mickey Mouse", c.Name);
        }

        [Test]
        public void TestUpdateCustomer()
        {
            // Get existing customer
            Customer oldCustomer = CustomerDB.GetCustomer(2);
            Customer newCustomer = CustomerDB.GetCustomer(2);
            newCustomer.Name = "Donald Duck";

            bool result = CustomerDB.UpdateCustomer(oldCustomer, newCustomer);
            Assert.IsTrue(result);
        }

        [Test]
        public void TestDeleteCustomer()
        {
            // Create customer to delete
            Customer c = new Customer();
            c.Name = "Temp Customer";
            c.Address = "101 Main Street";
            c.City = "Orlando";
            c.State = "FL";
            c.ZipCode = "10101";
            int customerID = CustomerDB.AddCustomer(c);

            c = CustomerDB.GetCustomer(customerID);
            bool result = CustomerDB.DeleteCustomer(c);
            Assert.IsTrue(result);
        }
    }
}