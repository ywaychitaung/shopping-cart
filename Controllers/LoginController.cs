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
        // Get session data
        ISession session = HttpContext.Session;

        // Check if already logged in and Redirect to Product page
        if (session.GetString("username") != null)
            return RedirectToAction("Index", "Product");
        
        return View();
    }
    
    [HttpPost]
    public IActionResult Index(string username, string password)
    {
        // Get all the users from database
        List<User> users = UserData.GetAllUsers();

        // Declare empty error message string
        string errorMessage = "";

        if (username == null && password == null)
        {
            ViewBag.usernameRequired = "Please enter a username!";
            ViewBag.passwordRequired = "Please enter a password!";
            ViewBag.oldUsername = "";
            ViewBag.oldPassword = "";
            return View();
        }
        else if (username == null)
        {
            ViewBag.usernameRequired = "Please enter a username!";
            ViewBag.oldUsername = "";
            ViewBag.oldPassword = password;
            return View();
        }
        else if (password == null)
        {
            ViewBag.oldUsername = username;
            ViewBag.oldPassword = "";
            ViewBag.passwordRequired = "Please enter a password!";
        }
        else
        {
            // Get all the users from database
            foreach (User user in users)
            {
                // Validate user credentials
                if (user.username == username && user.password == password)
                {
                    ISession session = HttpContext.Session;
                    session.SetString("username", username);

                    // Redirect to Product page
                    return RedirectToAction("Index", "Product");
                }
                    
                // Set the error message
                errorMessage = "You've entered wrong credentials!";
            }
        }
        
        // Send the error message to View and Return View
        ViewBag.errorMessage = errorMessage;
        return View();
    }   
}