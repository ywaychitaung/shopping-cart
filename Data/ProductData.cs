using ShoppingCart.Models;
using Microsoft.Data.SqlClient;

namespace ShoppingCart.Data;

public class ProductData
{
    public static List<Product> GetAllProducts()
    {
        // Get ConnectionStrings from appsettings.json file and set it to a local variable
        string conn_str = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("ConnectionStrings")["Default"];

        // Intialize new products object
        List<Product> products = new List<Product>();

        using (SqlConnection conn = new SqlConnection(conn_str))
        {
            // Start connecting to the database
            conn.Open();

            // SQL query
            string sql = @"SELECT id, name, description, price, imageUrl FROM Product";
            
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Product product = new Product()
                {
                    id = (int)reader["id"],
                    name = (string)reader["name"],
                    description = (string)reader["description"],
                    price = (int)reader["price"],
                    imageUrl = (string)reader["imageUrl"]
                };
                products.Add(product);
            }
        }

        return products;
    }
}