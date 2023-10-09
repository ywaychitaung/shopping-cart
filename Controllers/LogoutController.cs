using Microsoft.AspNetCore.Mvc;

namespace ShoppingCart.Controllers;

public class LogoutController : Controller
{
    public IActionResult Index()
    {
        // Get session data
        ISession session = HttpContext.Session;

        // Clear the session
        session.Clear();

        // Redirect to Login page
        return RedirectToAction("Index", "Login");
    }
}