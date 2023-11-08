using Microsoft.EntityFrameworkCore;
using MMLTonga.Models;

namespace MMLTonga.Data
{
    public class DbAgentContext :DbContext
    {
        public DbAgentContext(DbContextOptions<DbAgentContext> contextOptions)
    : base(contextOptions)
        {

        }

        //Code- Approach
        public DbSet<AgentDetail> AgentDetails { get; set; }
    }
}
