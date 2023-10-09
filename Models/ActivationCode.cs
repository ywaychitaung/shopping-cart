namespace ShoppingCart.Models;

public class ActivationCode
{
    public int? OrderId { get; set; }
    public int? ProductId { get; set; }
    public string? Code { get; set; }
    public string? OrderDate { get; set; }
}