using ShoppingCart.Models;
using Microsoft.Data.SqlClient;

namespace ShoppingCart.Data;

public class OrderData
{
    public static List<Order> GetOrderByUserId(int userId)
    {
        // Intialize new orders object
        List<Order> orders = new List<Order>();
        
        using (SqlConnection conn = new SqlConnection(Data.CONNECTION_STRING))
        {
            // Start connecting to the database
            conn.Open();

            // SQL query
            string sql = @"SELECT [Order].UserId, [Order].OrderDate, [Order].OrderId, OD.ProductId, OD.Quantity, [Product].Name, [Product].Description, [Product].ImageUrl FROM [Order], OrderDetails OD, [Product] WHERE OD.ProductId = [Product].ProductId AND [Order].OrderId = OD.OrderId AND UserId=" + userId + "ORDER BY [Order].OrderDate DESC";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Order order = new Order()
                {
                    UserId = (int)reader["UserId"],
                    OrderDate = (string)reader["OrderDate"],
                    OrderId = (int)reader["OrderId"],
                    ProductId = (int)reader["ProductId"],
                    Quantity = (int)reader["Quantity"],
                    Name = (string)reader["Name"],
                    Description = (string)reader["Description"],
                    ImageUrl = (string)reader["ImageUrl"]
                };
                orders.Add(order);
            }
        }

        return orders;
    }

    public static List<ActivationCode> GetActivationCodes(int userId)
    {
        // Intialize new codes object
        List<ActivationCode> codes = new List<ActivationCode>();
        
        using (SqlConnection conn = new SqlConnection(Data.CONNECTION_STRING))
        {
            // Start connecting to the database
            conn.Open();

            // SQL query
            string sql = @"SELECT [Order].OrderId, [Order].UserId, AC.ProductId, AC.Code, [Order].OrderDate FROM [Order], ActivationCode AC WHERE [Order].OrderId = AC.OrderId AND UserId=" + userId + "ORDER BY OrderDate DESC";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                // Create "order" object reference by ActivationCode Model
                ActivationCode code = new ActivationCode()
                {
                    OrderId = (int)reader["OrderId"],
                    ProductId = (int)reader["ProductId"],
                    Code = (string)reader["Code"],
                    OrderDate = (string)reader["OrderDate"]
                };

                // Add "code" object to "codes" object
                codes.Add(code);
            }
        }

        // Return all activation codes
        return codes;
    }

    public static void CreateOrder(string orderDate, int userId)
    {
        using (SqlConnection conn = new SqlConnection(Data.CONNECTION_STRING))
        {
            // Start connecting to the database
            conn.Open();

            // SQL query
            string sql = @"INSERT INTO [Order] (OrderDate, UserId) Values (@OrderDate, @UserId)";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@OrderDate", orderDate);
            cmd.Parameters.AddWithValue("@UserId", userId);
            cmd.ExecuteNonQuery();
        }
    }

    public static Order GetOrderId(string orderDate, int userId)
    {
        Order order = null;

        using (SqlConnection conn = new SqlConnection(Data.CONNECTION_STRING))
        {
            // Start connecting to the database
            conn.Open();

            // SQL query
            string sql = @"SELECT OrderId FROM [Order] WHERE UserId=" + userId;
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                order = new Order()
                {
                    OrderId = (int)reader["OrderId"]
                };
            }
        }

        return order;
    }

    public static void CreateOrderDetails(int orderId, int productId, int quantity)
    {
        using (SqlConnection conn = new SqlConnection(Data.CONNECTION_STRING))
        {
            // Start connecting to the database
            conn.Open();

            // SQL query
            string sql = @"INSERT INTO OrderDetails (OrderId, ProductId, Quantity) Values (@OrderId, @ProductId, @Quantity)";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@OrderId", orderId);
            cmd.Parameters.AddWithValue("@ProductId", productId);
            cmd.Parameters.AddWithValue("@Quantity", quantity);
            cmd.ExecuteNonQuery();
        }
    }

    public static void CreateActivationCode(int orderId, int productId, string hash)
    {
        using (SqlConnection conn = new SqlConnection(Data.CONNECTION_STRING))
        {
            // Start connecting to the database
            conn.Open();

            // SQL query
            string sql = @"INSERT INTO ActivationCode (OrderId, ProductId, Code) Values (@OrderId, @ProductId, @Code)";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@OrderId", orderId);
            cmd.Parameters.AddWithValue("@ProductId", productId);
            cmd.Parameters.AddWithValue("@Code", hash);
            cmd.ExecuteNonQuery();
        }
    }
}