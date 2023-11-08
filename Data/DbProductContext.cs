using Microsoft.EntityFrameworkCore;
using MMLTonga.Models;

namespace MMLTonga.Data
{
    public class DbProductContext : DbContext
    {
        public DbProductContext(DbContextOptions<DbProductContext> Options)
        : base(Options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        public DbSet<ExchangeRate> ExchangeRates { get; set; }
    }
}
