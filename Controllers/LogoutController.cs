using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Models;
using ShoppingCart.Data;

namespace ShoppingCart.Controllers;

public class LogoutController : Controller
{
    [HttpPost]
    public IActionResult Index(string username)
    {
        // Get session data
        ISession session = HttpContext.Session;

        // Get all the users from database
        List<User> users = UserData.GetAllUsers();

        // Get all the users from database
        foreach (User user in users)
        {
            if (user.username == username)
            {
                // Clear the session
                session.Remove("username");
            }
        }

        // Redirect to Login page
        return RedirectToAction("Index", "Login");      
    }
}