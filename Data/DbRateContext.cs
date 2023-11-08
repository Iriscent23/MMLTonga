using Microsoft.EntityFrameworkCore;
using MMLTonga.Models;

namespace MMLTonga.Data
{
    public class DbRateContext :DbContext
    {
        public DbRateContext(DbContextOptions<DbRateContext> options)
            : base(options)
        {
        
        }

        //Code- Approach
        public DbSet<ExchangeRate> ExchangeRates { get; set; }
    }
}
