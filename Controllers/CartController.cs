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

        int? sessionId = null;

        if (username == null)
        {
            sessionId = session.GetInt32("sessionId");

            if (sessionId == null)
            {
                // Create sessionId
                sessionId = Guid.NewGuid().GetHashCode();

                // Set sessionId to session
                session.SetInt32("sessionId", sessionId.Value);
            }
        }
        
        List<Cart> carts = new List<Cart>();
        int totalPrice = 0;

        if (username != null)
        {
            // Get User from database
            User user = UserData.GetUserByUsername(username);
            ViewBag.user = user;

            carts = CartData.GetCart(user.id);

            totalPrice = CartData.GetTotalPrice(user.id);
        }
        else if (sessionId != null)
        {
            carts = CartData.GetCart(sessionId.Value);

            totalPrice = CartData.GetTotalPrice(sessionId.Value);
        }

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

        return RedirectToAction("Index", "Product");
    }

    public IActionResult UpdateCart(int userId, int productId, int productQuantity)
    {
        return RedirectToAction("Index", "Product");
    }

    [HttpPost]
    public IActionResult Remove(int userId, int productId)
    {
        CartData.RemoveFromCart(userId, productId);

        return RedirectToAction("Index", "Cart");
    }

    [HttpPost]
    public IActionResult Increase(int userId, int productId)
    {
        CartData.UpdateTheCart(userId, productId);

        return RedirectToAction("Index", "Cart");
    }

     [HttpPost]
    public IActionResult Decrease(int userId, int productId, int productQuantity)
    {
        if (productQuantity > 1)
        {
            CartData.Decrease(userId, productId);
        }
        else
        {
            CartData.RemoveFromCart(userId, productId);
        }

        return RedirectToAction("Index", "Cart");
    }

    [HttpPost]
    public IActionResult Update(int userId, int productId, int productQuantity)
    {
        if (productQuantity == 0 || productQuantity < 0)
        {
            CartData.RemoveFromCart(userId, productId);
        }
        else
        {
            CartData.Update(userId, productId, productQuantity);
        }

        return RedirectToAction("Index", "Cart");
    }
}