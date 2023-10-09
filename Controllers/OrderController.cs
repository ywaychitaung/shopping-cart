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
}