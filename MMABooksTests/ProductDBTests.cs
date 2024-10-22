using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using MMABooksBusinessClasses;
using MMABooksDBClasses;

namespace MMABooksTests
{
    [TestFixture]
    public class ProductDBTests
    {
        [Test]
        public void TestGetProduct()
        {
            Product p = ProductDB.GetProduct("1234567891");  
            Assert.IsNotNull(p);
            Assert.AreEqual("1234567891", p.ProductCode);
        }

        [Test]
        public void TestGetProducts()
            //this will not test right unless TestAddProduct and TestUpdateProducts productcode is updated. (As some values are not equal to ten)
        {
            List<Product> products = ProductDB.GetProducts();
            Assert.IsNotNull(products);
            Assert.AreEqual(true, products.Count > 0);
        }

        [Test]
        public void TestAddProduct()
            //in order for test to work you have to enter a new productcode and getProduct each time, as it will lead to duplicate error in testing if not changed 
        {
            Product p = new Product();
            p.ProductCode = "ZZZZZZZ999";   //update each new test
            p.Description = "Test Product";
            p.UnitPrice = 10.00m;
            p.OnHandQuantity = 100;

            ProductDB.AddProduct(p);

            Product addedProduct = ProductDB.GetProduct("ZZZZZZZ999");  
            Assert.IsNotNull(addedProduct);
            Assert.AreEqual("Test Product", addedProduct.Description);
        }

        [Test]
        public void TestUpdateProduct()
        //in order for test to work you have to enter a new productcode each time, as it will lead to duplicate error in testing if not changed 
        {
            // Step 1: Add the original product
            Product originalProduct = new Product
            {
                ProductCode = "CS10999996", //update each new test
                Description = "Original Product",
                UnitPrice = 20.00m,
                OnHandQuantity = 50
            };

            ProductDB.AddProduct(originalProduct); 

            // Step 2: Create a new product instance for the update
            Product updatedProduct = new Product
            {
                ProductCode = originalProduct.ProductCode,
                Description = "Updated Test Product", 
                UnitPrice = 20.00m,
                OnHandQuantity = 50
            };

            // Step 3: Update the product
            bool updateResult = ProductDB.UpdateProduct(updatedProduct);

            // Assert that the update was successful
            Assert.IsTrue(updateResult, "Product should have been updated successfully.");

            // Step 4: Verify that the product has been updated
            Product retrievedProduct = ProductDB.GetProduct("CS10999996");
            Assert.IsNotNull(retrievedProduct, "Updated product should exist.");
            Assert.AreEqual("Updated Test Product", retrievedProduct.Description, "Product description should match the updated value.");
            Assert.AreEqual(20.00m, retrievedProduct.UnitPrice, "Product unit price should match the updated value.");
            Assert.AreEqual(50, retrievedProduct.OnHandQuantity, "Product on-hand quantity should match the updated value.");
        }

        [Test]
        
        public void TestDeleteProduct()
        {
            // Step 1: Add the product directly before deletion - this seemed to work better, then previous way I tried. 
            Product testProduct = new Product
            {
                ProductCode = "ct80999999",
                Description = "Test Product",
                UnitPrice = 10.00m,
                OnHandQuantity = 100
            };

            ProductDB.AddProduct(testProduct); // Ensure the product exists

            // Step 2: Get the product
            Product p = ProductDB.GetProduct("ct80999999");
            Assert.IsNotNull(p, "The product should exist after being added.");

            // Step 3: Delete the product
            bool result = ProductDB.DeleteProduct(p);

            // Assert that the deletion was successful
            Assert.IsTrue(result, "Product should have been deleted successfully.");

            // Step 4: Verify that the product no longer exists
            Product deletedProduct = ProductDB.GetProduct("ct80999999");
            Assert.IsNull(deletedProduct, "Product should be null after deletion.");
        }
    }
}