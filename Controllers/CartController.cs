using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Models;
using ShoppingCart.Data;

namespace ShoppingCart.Controllers;

public class CartController : Controller
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

        List<Cart> carts = CartData.GetCart((int)user.id);

        int totalPrice = CartData.GetTotalPrice((int)user.id);

        // Send it to the view
        ViewBag.carts = carts;
        ViewBag.totalPrice = totalPrice;

        return View();
    }

    [HttpPost]
    public IActionResult AddToCart(int userId, int productId)
    {
        // Check Already Added To Cart or NOT
        bool alreadyAddedToCart = CartData.AlreadyAddedToCart(userId, productId);

        if (alreadyAddedToCart)
        {
            // Update The Cart
            CartData.UpdateTheCart(userId, productId);
        }
        else
        {
            // Add To Cart
            CartData.AddToCart(userId, productId);
        }

        return Redirect("/Product");
    }

    public IActionResult UpdateCart(int userId, int productId, int productQuantity)
    {
        return Redirect("/Product");
    }
}