using System;
using System.Collections.Generic;
using System.Net;
using System.Reflection.Emit;
using System.Text;
using System.Xml.Linq;

namespace MMABooksBusinessClasses
{
    public class Product
    {
        public Product() { }
        public Product(string productCode, string description, decimal unitPrice, int onHandQuantity)
        {
            ProductCode = productCode;
            Description = description;
            UnitPrice = unitPrice;
            OnHandQuantity = onHandQuantity;
        }

        private string productCode;
        private string description;
        private decimal unitPrice;
        private int onHandQuantity;

        public string ProductCode
        {
            get { return productCode; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length != 10)
                    throw new ArgumentException("ProductCode must be exactly 10 characters.");
                productCode = value.ToUpper(); 
            }
        }

        public string Description
        {
            get { return description; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length > 50)
                    throw new ArgumentException("Description must be between 1 and 50 characters.");
                description = value;
            }
        }

        public decimal UnitPrice
        {
            get { return unitPrice; }
            set
            {
                if (value < 0 || value >= 1000000) 
                    throw new ArgumentException("UnitPrice must be non-negative and less than 1,000,000.");
                unitPrice = Math.Round(value, 4); 
            }
        }

        public int OnHandQuantity
        {
            get { return onHandQuantity; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("OnHandQuantity must be non-negative.");
                onHandQuantity = value;
            }
        }

        public override string ToString()
        {
            return $"Product Code: {ProductCode}, Description: {Description}, Unit Price: {UnitPrice:F4}, On Hand: {OnHandQuantity}";
        }
    }
}

