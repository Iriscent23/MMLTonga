using Microsoft.EntityFrameworkCore;
using MMLTonga.Models;

namespace MMLTonga.Data
{
    public class DbCustomerContext :DbContext
    {
        public DbCustomerContext(DbContextOptions<DbCustomerContext> Options)
        : base(Options)
        {

        }

        //Code- Approach
        public DbSet<CustomerManagement> Customers { get; set; }
    }
}
