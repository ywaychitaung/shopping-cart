namespace ShoppingCart.Models;

public class Product
{
    public int? id { get; set; }
    public string? name { get; set; }
    public string? description { get; set; }
    public int? price { get; set; }
    public string? imageUrl { get; set; }
}