using ShoppingCart.Models;
using Microsoft.Data.SqlClient;

namespace ShoppingCart.Data;

public class ProductData
{
    public static List<Product> GetAllProducts()
    {
        // Intialize new products object
        List<Product> products = new List<Product>();

        using (SqlConnection conn = new SqlConnection(Data.CONNECTION_STRING))
        {
            // Start connecting to the database
            conn.Open();

            // SQL query
            string sql = @"SELECT ProductId, Name, Description, Price, ImageUrl FROM Product";
            
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Product product = new Product()
                {
                    id = (int)reader["ProductId"],
                    name = (string)reader["Name"],
                    description = (string)reader["Description"],
                    price = (int)reader["Price"],
                    imageUrl = (string)reader["ImageUrl"]
                };
                products.Add(product);
            }
        }

        return products;
    }
}