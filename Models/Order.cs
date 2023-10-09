namespace ShoppingCart.Models;

public class Order
{
    public int? OrderId { get; set; }
    public string? OrderDate { get; set; }
    public int? UserId { get; set; }
    public int? ProductId { get; set; }
    public int? Quantity { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
}