namespace FirstDb.Models;

public record OrderDetail
{
    public int OrderDetailID { get; set; }
    public Order Order { get; set; }
    public Product Product { get; set; }
    public int Quantity { get; set; }
    public int TotalCost { get; set; }
};