namespace FirstDb.Models;

public record Product
{
    public int ProductID { get; set; }
    public string ProductName { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int QuantityInStock { get; set; }
};