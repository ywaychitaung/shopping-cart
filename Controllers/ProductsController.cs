using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Models;

namespace ShoppingCart.Controllers;

public class ProductsController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}