namespace FirstDb.Models;

public record Order()
{
    public int OrderId { get; set; }
    public User User { get; set; }
    public DateTime OrderDate { get; set; }
    public int Status { get; set; }
    public List<OrderDetail> OrderDetails { get; set; }
};