using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Models;

namespace ShoppingCart.Controllers;

public class AuthController : Controller
{
    // Show Login Form to user
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult Login(string username, string password)
    {
        List<Users> users = GetMockData();

        foreach (Users user in users)
        {
            if (user.username == username && user.password == password)
            {
                
                return Redirect("/");
            }
        }

        return View();
    }

    private List<Users> GetMockData()
    {
        List<Users> users = new List<Users>();

        users.Add(new Users {
            username = "johndoe",
            password = "password1"
        });

        users.Add(new Users {
            username = "janedoe",
            password = "password2"
        });

        return users;
    }
}