using FirstDb.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstDb.Interfaces;

public interface IApplicationDbContext
{
    DbSet<User> Users { get; }
    DbSet<Order> Orders { get; }
    DbSet<OrderDetail> OrderDetails { get; }
    DbSet<Product> Products { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}