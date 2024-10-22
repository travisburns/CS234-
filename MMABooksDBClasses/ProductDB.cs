using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
using MMABooksBusinessClasses;

namespace MMABooksDBClasses
{
    public static class ProductDB
    {
        public static Product GetProduct(string productCode)
        {
            MySqlConnection connection = MMABooksDB.GetConnection();
            string selectStatement = "SELECT ProductCode, Description, UnitPrice, OnHandQuantity "
                + "FROM Products "
                + "WHERE ProductCode = @ProductCode";
            MySqlCommand selectCommand = new MySqlCommand(selectStatement, connection);
            selectCommand.Parameters.AddWithValue("@ProductCode", productCode);

            try
            {
                connection.Open();
                MySqlDataReader prodReader = selectCommand.ExecuteReader(CommandBehavior.SingleRow);
                if (prodReader.Read())
                {
                    Product product = new Product();
                   product.ProductCode = prodReader["ProductCode"].ToString();
                    product.Description = prodReader["Description"].ToString();
                    product.UnitPrice = (decimal)prodReader["UnitPrice"];
                    product.OnHandQuantity = (int)prodReader["OnHandQuantity"];
                    prodReader.Close();
                    return product;
                }
                else
                {
                    return null;
                }
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        public static List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();
            MySqlConnection connection = MMABooksDB.GetConnection();
            string selectStatement = "SELECT ProductCode, Description, UnitPrice, OnHandQuantity "
                + "FROM Products "
                + "ORDER BY ProductCode";
            MySqlCommand selectCommand = new MySqlCommand(selectStatement, connection);

            try
            {
                connection.Open();
                MySqlDataReader reader = selectCommand.ExecuteReader();
                while (reader.Read())
                {
                    Product product = new Product();
                    product.ProductCode = reader["ProductCode"].ToString();
                    product.Description = reader["Description"].ToString();
                    product.UnitPrice = (decimal)reader["UnitPrice"];
                    product.OnHandQuantity = (int)reader["OnHandQuantity"];
                    products.Add(product);
                }
                reader.Close();
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return products;
        }

        public static void AddProduct(Product product)
        {
            MySqlConnection connection = MMABooksDB.GetConnection();
            string insertStatement =
                "INSERT Products " +
                "(ProductCode, Description, UnitPrice, OnHandQuantity) " +
                "VALUES (@ProductCode, @Description, @UnitPrice, @OnHandQuantity)";
            MySqlCommand insertCommand = new MySqlCommand(insertStatement, connection);
            insertCommand.Parameters.AddWithValue("@ProductCode", product.ProductCode);
            insertCommand.Parameters.AddWithValue("@Description", product.Description);
            insertCommand.Parameters.AddWithValue("@UnitPrice", product.UnitPrice);
            insertCommand.Parameters.AddWithValue("@OnHandQuantity", product.OnHandQuantity);

            try
            {
                connection.Open();
                insertCommand.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        public static bool DeleteProduct(Product product)
        {
            MySqlConnection connection = MMABooksDB.GetConnection();
            string deleteStatement =
                "DELETE FROM Products " +
                "WHERE ProductCode = @ProductCode " +
                "AND Description = @Description " +
                "AND UnitPrice = @UnitPrice " +
                "AND OnHandQuantity = @OnHandQuantity";
            MySqlCommand deleteCommand = new MySqlCommand(deleteStatement, connection);
            deleteCommand.Parameters.AddWithValue("@ProductCode", product.ProductCode);
            deleteCommand.Parameters.AddWithValue("@Description", product.Description);
            deleteCommand.Parameters.AddWithValue("@UnitPrice", product.UnitPrice);
            deleteCommand.Parameters.AddWithValue("@OnHandQuantity", product.OnHandQuantity);

            try
            {
                connection.Open();
                int rowsAffected = deleteCommand.ExecuteNonQuery();
                return rowsAffected == 1;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        public static bool UpdateProduct(Product newProduct)
        {
            MySqlConnection connection = MMABooksDB.GetConnection();
            string updateStatement =
                "UPDATE Products SET " +
                "Description = @NewDescription, " +
                "UnitPrice = @NewUnitPrice, " +
                "OnHandQuantity = @NewOnHandQuantity " +
                "WHERE ProductCode = @ProductCode";

            MySqlCommand updateCommand = new MySqlCommand(updateStatement, connection);
            updateCommand.Parameters.AddWithValue("@NewDescription", newProduct.Description);
            updateCommand.Parameters.AddWithValue("@NewUnitPrice", newProduct.UnitPrice);
            updateCommand.Parameters.AddWithValue("@NewOnHandQuantity", newProduct.OnHandQuantity);

            // Use only the ProductCode for matching
            updateCommand.Parameters.AddWithValue("@ProductCode", newProduct.ProductCode);

            try
            {
                connection.Open();
                int rowsAffected = updateCommand.ExecuteNonQuery();
                return rowsAffected == 1;  // Return true if one row was updated
            }
            catch (MySqlException ex)
            {
                throw ex; // Rethrow or handle the exception as needed
            }
            finally
            {
                connection.Close();
            }
        }
    }
}