using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Models;
using ShoppingCart.Data;

namespace ShoppingCart.Controllers;

public class OrderController : Controller
{
    public IActionResult Index()
    {
        // Get session data
        ISession session = HttpContext.Session;
        
        // Get username from session
        string? username = session.GetString("username");

        // Get User from database
        User user = UserData.GetUserByUsername(username);

        // Get order from database
        List<Order> orders = OrderData.GetOrderByUserId((int)user.id);

        // Get activation codes from database
        List<ActivationCode> codes = OrderData.GetActivationCodes((int)user.id);

        ViewBag.user = user;
        ViewBag.orders = orders;
        ViewBag.codes = codes;

        return View();
    }

    public IActionResult Success(int userId = 2)
    {
        List<Cart> carts = CartData.GetCart(userId);

        string orderDate = DateTime.Now.ToString("dd/MM/yyyy");

        OrderData.CreateOrder(orderDate, userId);

        Order order = OrderData.GetOrderId(orderDate, userId);

        int orderId = (int)order.OrderId;

        foreach(var cart in carts)
        {
            OrderData.CreateOrderDetails(orderId, (int)cart.ProductId, (int)cart.Quantity);
            
            for(int qty = 0; qty < cart.Quantity; qty++)
            {
                string ac = orderId.ToString() + cart.ProductId.ToString() + qty.ToString();
                string hash = BCrypt.Net.BCrypt.HashPassword(ac);

                OrderData.CreateActivationCode(orderId, (int)cart.ProductId, hash);
            }
        }

        CartData.DeleteCart(userId);

        return Redirect("/Order");
    }
}