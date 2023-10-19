namespace ShoppingCart.Models;

public class Cart
{
    public int? CartId { get; set; }
    public int? UserId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int Price { get; set; }
    public string? ImageUrl { get; set; }
}