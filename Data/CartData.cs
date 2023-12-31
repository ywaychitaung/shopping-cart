using ShoppingCart.Models;
using Microsoft.Data.SqlClient;

namespace ShoppingCart.Data;

public class CartData
{
    public static List<Cart> GetCart(int userId)
    {
        // Intialize new carts object
        List<Cart> carts = new List<Cart>();

        using (SqlConnection conn = new SqlConnection(Data.CONNECTION_STRING))
        {
            // Start connecting to the database
            conn.Open();

            // SQL query
            string sql = @"SELECT C.CartId, C.UserId, C.ProductId, C.Quantity, P.Name, P.Description, P.Price, P.ImageUrl FROM Cart C, Product P WHERE C.ProductId = P.ProductId AND UserId=" + userId;
            
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Cart cart = new Cart()
                {
                    CartId = (int)reader["CartId"],
                    UserId = (int)reader["UserId"],
                    ProductId = (int)reader["ProductId"],
                    Quantity = (int)reader["Quantity"],
                    Name = (string)reader["Name"],
                    Description = (string)reader["Description"],
                    Price = (int)reader["Price"],
                    ImageUrl = (string)reader["ImageUrl"]
                };
                carts.Add(cart);
            }
        }

        return carts;
    }

    public static int GetTotalQuantity(int userId)
    {
        // Initialize an integer totalQuantity
        int totalQuantity = 0;

        // Intialize new carts object
        List<Cart> carts = new List<Cart>();

        using (SqlConnection conn = new SqlConnection(Data.CONNECTION_STRING))
        {
            // Start connecting to the database
            conn.Open();

            // SQL query
            string sql = @"SELECT CartId, UserId, ProductId, Quantity FROM Cart WHERE UserId=" + userId;
            
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Cart cart = new Cart()
                {
                    CartId = (int)reader["CartId"],
                    UserId = (int)reader["UserId"],
                    ProductId = (int)reader["ProductId"],
                    Quantity = (int)reader["Quantity"]
                };
                carts.Add(cart);
            }
        }

        foreach(var cart in carts)
        {
            if (cart != null)
            {
                totalQuantity += cart.Quantity;
            }
            else
            {
                totalQuantity = 0;
            }
        }
        
        return totalQuantity;
    }

    public static bool AlreadyAddedToCart(int userId, int productId)
    {
        using (SqlConnection conn = new SqlConnection(Data.CONNECTION_STRING))
        {
            // Start connecting to the database
            conn.Open();

            // SQL query
            string sql = @"SELECT CartId, UserId, ProductId, Quantity FROM Cart WHERE UserId=" + userId + "AND ProductId=" + productId;
            
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            
            while (reader.Read())
            {
                Cart cart = new Cart()
                {
                    CartId = (int)reader["CartId"],
                    UserId = (int)reader["UserId"],
                    ProductId = (int)reader["ProductId"],
                    Quantity = (int)reader["Quantity"]
                };
                
                if (cart != null)
                {
                    return true;
                }
            }

            // Stop connecting to the database
            conn.Close();
        }

        return false;
    }

    public static Cart GetQuantity(int userId, int productId)
    {    
        // Initialize cart object
        Cart cart = new Cart();

        using (SqlConnection conn = new SqlConnection(Data.CONNECTION_STRING))
        {
            // Start connecting to the database
            conn.Open();

            // SQL query
            string sql = @"SELECT CartId, UserId, ProductId, Quantity FROM Cart WHERE UserId=" + userId + "AND ProductId=" + productId;
            
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            
            while (reader.Read())
            {
                cart = new Cart()
                {
                    CartId = (int)reader["CartId"],
                    UserId = (int)reader["UserId"],
                    ProductId = (int)reader["ProductId"],
                    Quantity = (int)reader["Quantity"]
                };
            }

            conn.Close();
        }

        return cart;
    }

    public static void AddToCart(int userId, int productId)
    {
        using (SqlConnection conn = new SqlConnection(Data.CONNECTION_STRING))
        {
            // Start connecting to the database
            conn.Open();

            // SQL query
            string sql = @"INSERT INTO Cart (UserId, ProductId, Quantity) VALUES (@UserId, @ProductId, 1)";
            
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@UserId", userId);
            cmd.Parameters.AddWithValue("@ProductId", productId);
            cmd.ExecuteNonQuery();

            // Stop connecting to the database
            conn.Close();
        }
    }

    public static void Update(int userId, int productId, int productQuantity)
    {
        using (SqlConnection conn = new SqlConnection(Data.CONNECTION_STRING))
        {
            // Start connecting to the database
            conn.Open();

            // SQL query
            string sql = @"UPDATE Cart SET Quantity=@Quantity WHERE UserId=" + userId + "AND ProductId=" + productId;
            
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Quantity", productQuantity);

            cmd.ExecuteNonQuery();

            // Stop connecting to the database
            conn.Close();
        }
    }

    public static void UpdateTheCart(int userId, int productId)
    {
        Cart cart = GetQuantity(userId, productId);
        cart.Quantity += 1;

        using (SqlConnection conn = new SqlConnection(Data.CONNECTION_STRING))
        {
            // Start connecting to the database
            conn.Open();

            // SQL query
            string sql = @"UPDATE Cart SET Quantity=@Quantity WHERE UserId=" + userId + "AND ProductId=" + productId;
            
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Quantity", cart.Quantity);

            cmd.ExecuteNonQuery();

            // Stop connecting to the database
            conn.Close();
        }
    }

    public static void Decrease(int userId, int productId)
    {
        Cart cart = GetQuantity(userId, productId);
        cart.Quantity -= 1;

        using (SqlConnection conn = new SqlConnection(Data.CONNECTION_STRING))
        {
            // Start connecting to the database
            conn.Open();

            // SQL query
            string sql = @"UPDATE Cart SET Quantity=@Quantity WHERE UserId=" + userId + "AND ProductId=" + productId;
            
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Quantity", cart.Quantity);

            cmd.ExecuteNonQuery();

            // Stop connecting to the database
            conn.Close();
        }
    }

    public static int GetTotalPrice(int userId)
    {
        // Initialize an integer totalQuantity
        int totalPrice = 0;

        // Intialize new carts object
        List<Cart> carts = new List<Cart>();

        using (SqlConnection conn = new SqlConnection(Data.CONNECTION_STRING))
        {
            // Start connecting to the database
            conn.Open();

            // SQL query
            string sql = @"SELECT C.CartId, C.UserId, C.ProductId, C.Quantity, P.Name, P.Description, P.Price, P.ImageUrl FROM Cart C, Product P WHERE C.ProductId = P.ProductId AND UserId=" + userId;
            
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Cart cart = new Cart()
                {
                    CartId = (int)reader["CartId"],
                    UserId = (int)reader["UserId"],
                    ProductId = (int)reader["ProductId"],
                    Quantity = (int)reader["Quantity"],
                    Name = (string)reader["Name"],
                    Description = (string)reader["Description"],
                    Price = (int)reader["Price"],
                    ImageUrl = (string)reader["ImageUrl"]
                };
                carts.Add(cart);
            }
        }
        
        foreach(var cart in carts)
        {
            if (cart != null)
            {
                totalPrice += cart.Price * cart.Quantity;
            }
        }

        return totalPrice;
    }

    public static void RemoveFromCart(int userId, int productId)
    {
        using (SqlConnection conn = new SqlConnection(Data.CONNECTION_STRING))
        {
            // Start connecting to the database
            conn.Open();

            // SQL query
            string sql = @"DELETE FROM Cart WHERE UserId=" + userId + "AND ProductId=" + productId;
            
            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.ExecuteNonQuery();

            // Stop connecting to the database
            conn.Close();
        }
    }

    public static void DeleteCart(int userId)
    {
        using (SqlConnection conn = new SqlConnection(Data.CONNECTION_STRING))
        {
            // Start connecting to the database
            conn.Open();

            // SQL query
            string sql = @"DELETE FROM Cart WHERE UserId=" + userId;
            
            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.ExecuteNonQuery();

            // Stop connecting to the database
            conn.Close();
        }
    }

    public static void ChangeSessionIdToUserId(int userId, int sessionId)
    {
        using (SqlConnection conn = new SqlConnection(Data.CONNECTION_STRING))
        {
            // Start connecting to the database
            conn.Open();

            // SQL query
            string sql = @"UPDATE Cart SET UserId=@UserId WHERE UserId=" + sessionId;
            
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@UserId", userId);

            cmd.ExecuteNonQuery();

            // Stop connecting to the database
            conn.Close();
        }
    }

    public static void MergeDuplicateItems(List<Cart> cart1, List<Cart> cart2)
    {
        foreach (var c1 in cart1)
        {
            foreach (var c2 in cart2)
            {
                if (c1.ProductId == c2.ProductId)
                {
                    c1.Quantity += c2.Quantity;

                    using (SqlConnection conn = new SqlConnection(Data.CONNECTION_STRING))
                    {
                        // Start connecting to the database
                        conn.Open();

                        // SQL query
                        string sql = @"UPDATE Cart SET Quantity=@Quantity WHERE UserId=" + c1.UserId + "AND ProductId=" + c1.ProductId;
                        
                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@Quantity", c1.Quantity);

                        cmd.ExecuteNonQuery();

                        // Stop connecting to the database
                        conn.Close();
                    }

                    RemoveFromCart(c2.UserId, c2.ProductId);
                }
            }
        }
    }
}