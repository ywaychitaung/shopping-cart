using ShoppingCart.Models;
using Microsoft.Data.SqlClient;

namespace ShoppingCart.Data;

public class UserData
{
    public static List<User> GetAllUsers()
    {
        // Intialize new users object
        List<User> users = new List<User>();
        
        using (SqlConnection conn = new SqlConnection(Data.CONNECTION_STRING))
        {
            // Start connecting to the database
            conn.Open();

            // SQL query
            string sql = @"SELECT UserId, Name, Username, Password FROM [User]";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                User user = new User()
                {
                    id = (int)reader["UserId"],
                    name = (string)reader["Name"],
                    username = (string)reader["Username"],
                    password = (string)reader["Password"]
                };
                users.Add(user);
            }
        }

        return users;
    }

    public static User GetUserByUsername(string username)
    {   
        // Intialize new users object
        User user = null;
        
        using (SqlConnection conn = new SqlConnection(Data.CONNECTION_STRING))
        {
            // Start connecting to the database
            conn.Open();

            // SQL query
            string sql = "SELECT UserId, Name, Username, Password FROM [User] WHERE Username='" + username + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                user = new User()
                {
                    id = (int)reader["UserId"],
                    name = (string)reader["Name"],
                    username = (string)reader["Username"],
                    password = (string)reader["Password"]
                };
            }

            return user;
        }        
    }
}