using Microsoft.AspNetCore.Mvc;

namespace ShoppingCart.Controllers;

public class GalleryController : Controller
{
    public IActionResult Index()
    {
        return View();
    } 
}