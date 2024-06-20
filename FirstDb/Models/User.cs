namespace FirstDb.Models;

public record User
{
    public int UserID { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public DateTime RegistrationDate { get; set; }
    public List<Order> Orders { get; set; }
}