using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Models;
using ShoppingCart.Data;

namespace ShoppingCart.Controllers;

public class ProductController : Controller
{
    public IActionResult Index()
    {
        // Get all products from database
        List<Product> products = ProductData.GetAllProducts();

        // Get session data
        ISession session = HttpContext.Session;

        // Get username from session
        string? username = session.GetString("username");

        // Get User from database
        User user = UserData.GetUserByUsername(username);

        int totalQuantity = CartData.GetTotalQuantity((int)user.id);

        // Send it to the view
        ViewBag.user = user;
        ViewData["products"] = products;
        ViewBag.totalQuantity = totalQuantity;

        // Return view
        return View();
    }
}