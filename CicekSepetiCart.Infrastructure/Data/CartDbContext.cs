using CicekSepetiCart.Domain.Data;
using CicekSepetiCart.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CicekSepetiCart.Infrastructure.Data
{
    public class CartDbContext : DbContext, ICartDbContext
    {
        public CartDbContext()
        {

        }

        public CartDbContext(DbContextOptions<CartDbContext> options) : base(options)
        {
        }
        public DbSet<CartItem> CartItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CartItem>(entity =>
            {
                entity.HasKey(t => t.Id);
                entity.HasIndex(e => e.Id);
                entity.Property(e => e.UserId).IsRequired();
                entity.Property(e => e.ProductId).IsRequired();
                entity.Property(e => e.Quantity).IsRequired();
                entity.Property(e => e.Status).IsRequired();
                entity.Property(e => e.CreatedAt).IsRequired();
            });
        }
    }
}
