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

        // Send it to the view
        ViewData["products"] = products;

        // Return view
        return View();
    } 
}