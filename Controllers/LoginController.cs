using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Models;
using ShoppingCart.Data;

namespace ShoppingCart.Controllers;

public class LoginController : Controller
{
    // Show Login Form to user
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult Index(string username, string password)
    {
        // Get all the users from database
        List<User> users = UserData.GetAllUsers();

        // Get all the users from database
        foreach (User user in users)
        {
            // Validate user credentials
            if (user.username == username && user.password == password)
            {
                // Redirect to Home route
                return Redirect("/");
            }
        }
        
        return View();
    }   
}