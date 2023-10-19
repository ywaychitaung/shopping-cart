using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Models;
using ShoppingCart.Data;

namespace ShoppingCart.Controllers;

public class ProductController : Controller
{
    public IActionResult Index(string searchString)
    {
        // Get all products from database
        List<Product> products = ProductData.GetAllProducts();

        ViewBag.searchString = searchString;

        if (ViewBag.searchString != null)
        {
            // Filter Products
            ViewBag.products = FilterBySearchString(searchString, products);
        }
        else
        {
            ViewBag.products = products;
        }

        // Get session data
        ISession session = HttpContext.Session;

        // Get username from session
        string? username = session.GetString("username");

        User? user = new User();
        int totalQuantity = 0;

        // Get User from database
        if (username != null)
        {
            user = UserData.GetUserByUsername(username);
            totalQuantity = CartData.GetTotalQuantity(user.id);

            // Send it to the view
            ViewBag.user = user;
            ViewBag.totalQuantity = totalQuantity;
        }

        // Return view
        return View();
    }

    private List<Product> FilterBySearchString(string searchString, List<Product> products)
	{
		List<Product> filteredProducts = new List<Product>();

		foreach (Product product in products) {
			if (product.name != null) {
				if (product.name.ToLower().IndexOf(
					searchString.ToLower()) != -1)
				{
					filteredProducts.Add(product);
				}
			}
		}

		return filteredProducts;
	}
}