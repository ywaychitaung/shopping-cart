using ShoppingCart.Models;
using Microsoft.Data.SqlClient;

namespace ShoppingCart.Data;

public class UserData
{
    public static List<User> GetAllUsers()
    {
        // Get ConnectionStrings from appsettings.json file and set it to a local variable
        string conn_str = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("ConnectionStrings")["Default"];

        // Intialize new users object
        List<User> users = new List<User>();
        
        using (SqlConnection conn = new SqlConnection(conn_str))
        {
            // Start connecting to the database
            conn.Open();

            // SQL query
            string sql = @"SELECT id, name, username, password FROM Users";

            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                User user = new User()
                {
                    id = (int)reader["id"],
                    name = (string)reader["name"],
                    username = (string)reader["username"],
                    password = (string)reader["password"]
                };
                users.Add(user);
            }
        }

        return users;
    }
}